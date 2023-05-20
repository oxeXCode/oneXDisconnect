using MaterialSkin.Controls;
using oneXDisconnect.Devices;
using oneXDisconnect.Models.Enums;
using oneXDisconnect.Models.Events;
using oneXDisconnect.Models.Interface;
using oneXDisconnect.Models.View;
using SharpDX.DirectInput;
using System.Diagnostics;

namespace oneXDisconnect
{
    public partial class Form1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        private static readonly ConfigManager<Rootobject> configManager = new("config.json");
        private static Firewall.Command? firewallManager = null;

        private EventHandler<DeviceKeyEventArgs>? keyPressedHandler;
        private EventHandler<DeviceKeyEventArgs>? keyReleasedHandler;

        private readonly Dictionary<DeviceEnum, IDevice> deviceMap = new()
        {
            { DeviceEnum.Keyboard, new KeyboardDevice(configManager.ConfigData.settings.pollingFrequency)
                { Key = configManager.ConfigData.device.keyboard } },
            { DeviceEnum.Mouse, new MouseDevice(configManager.ConfigData.settings.pollingFrequency)
                { Key = configManager.ConfigData.device.mouse } },
            { DeviceEnum.Controller, new ControllerDevice(configManager.ConfigData.settings.pollingFrequency)
                { Key = configManager.ConfigData.device.controller }
            }
        };

        public Form1()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            if (configManager.ConfigData == null)
                return;

            LoadConfiguration();
            SetControlValues();
        }

        private void OnApplicationExit(object? sender, EventArgs e)
        {
            foreach (var item in deviceMap)
                item.Value.Dispose();

            firewallManager?.ExecuteCommandAsync(FirewallActionEnum.Delete);
        }

        private void LoadConfiguration()
        {
            txtAppFilepath.Text = configManager.ConfigData.rule.path;
            chkOut.Checked = configManager.ConfigData.rule.chkOut;
            chkIn.Checked = configManager.ConfigData.rule.chkIn;
        }

        private void SetControlValues()
        {
            SetHookType(configManager.ConfigData.hookType.type);
            comboDevice.SelectedIndex = configManager.ConfigData.device.type;
            comboDevice_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void SetHookType(int type)
        {
            txtHolderTimer.Text = configManager.ConfigData.hookType.holderTimer.ToString();

            switch (type)
            {
                case 1:
                    radioSwitcher.Checked = true;
                    break;
                case 2:
                    radioHolder.Checked = true;
                    break;
                default:
                    radioClamping.Checked = true;
                    break;
            }
        }

        private void btnSetFilepath_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Utilities.OpenFileDialog("Select target path");
                if (string.IsNullOrEmpty(fileName)) return;
                txtAppFilepath.Text = fileName;
                configManager.ConfigData.rule.path = fileName;
                configManager.UpdateConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "1x", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkOut_CheckedChanged(object sender, EventArgs e)
        {
            configManager.ConfigData.rule.chkOut = chkOut.Checked;
            configManager.UpdateConfig();
        }

        private void chkIn_CheckedChanged(object sender, EventArgs e)
        {
            configManager.ConfigData.rule.chkIn = chkIn.Checked;
            configManager.UpdateConfig();
        }

        private void radioClamping_CheckedChanged(object sender, EventArgs e)
        {
            if (radioClamping.Checked)
            {
                configManager.ConfigData.hookType.type = 0;
                configManager.UpdateConfig();
            }
        }

        private void radioSwitcher_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSwitcher.Checked)
            {
                configManager.ConfigData.hookType.type = 1;
                configManager.UpdateConfig();
            }
        }

        private void radioHolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHolder.Checked)
            {
                configManager.ConfigData.hookType.type = 2;
                configManager.UpdateConfig();
            }
        }

        private void txtHolderTimer_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtHolderTimer.Text, out int value))
            {
                configManager.ConfigData.hookType.holderTimer = value;
                configManager.UpdateConfig();
            }
            else
            {
                txtHolderTimer.Text = configManager.ConfigData.hookType.holderTimer.ToString();
                MessageBox.Show("HolderTimer value error", "1x", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var device = (DeviceEnum)comboDevice.SelectedIndex;

            configManager.ConfigData.device.type = comboDevice.SelectedIndex;
            configManager.UpdateConfig();

            if (deviceMap.TryGetValue(device, out var hookedDevice))
            {
                hookedDevice.Initialize();
                txtHotKey.Text = GetDeviceHotKeyText(device);

                if (hookedDevice.Status == HookedStatusEnum.NotConnected)
                {
                    MessageBox.Show("Device connect error", "1x", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboDevice.SelectedIndex = 0;
                    comboDevice_SelectedIndexChanged(sender, e);
                }
            }
        }

        private string? GetDeviceHotKeyText(DeviceEnum device) => device switch
        {
            DeviceEnum.Keyboard => ((Key?)configManager.ConfigData.device.keyboard).ToString(),
            DeviceEnum.Mouse => ((MouseOffset?)configManager.ConfigData.device.mouse).ToString(),
            DeviceEnum.Controller => ((JoystickOffset?)configManager.ConfigData.device.controller).ToString(),
        };

        private void BindDeviceHotKey(DeviceEnum device, int? key)
        {
            Dictionary<DeviceEnum, Action<int?>> deviceActions = new()
            {
                { DeviceEnum.Keyboard, key => configManager.ConfigData.device.keyboard = key },
                { DeviceEnum.Mouse, key => configManager.ConfigData.device.mouse = key },
                { DeviceEnum.Controller, key => configManager.ConfigData.device.controller = key }
            };

            if (deviceActions.ContainsKey(device))
                deviceActions[device].Invoke(key);

            configManager.UpdateConfig();
        }

        private void btnEditHotKey_Click(object sender, EventArgs e)
        {
            var device = (DeviceEnum)comboDevice.SelectedIndex;

            if (deviceMap.TryGetValue(device, out var hookedDevice))
            {
                ToggleHotKeyActions(true);

                hookedDevice.Key = null;
                BindDeviceHotKey(device, null);

                keyReleasedHandler = async (sender, e) => await HookedDevice_KeyReleased(sender, e);
                hookedDevice.KeyReleased += keyReleasedHandler;
                hookedDevice.Hook();
            }
        }

        private async Task HookedDevice_KeyReleased(object? sender, DeviceKeyEventArgs e)
        {
            var device = (DeviceEnum)comboDevice.SelectedIndex;
            var type = (HookTypeEnum)configManager.ConfigData.hookType.type;

            if (!deviceMap.TryGetValue(device, out var hookedDevice))
                return;

            // BIND NEW KEY
            if (txtHotKey.Enabled)
            {
                ToggleHotKeyActions(false);

                hookedDevice.Key = e.KeyAsInt;
                BindDeviceHotKey(device, e.KeyAsInt);

                hookedDevice.KeyReleased -= keyReleasedHandler;
                keyReleasedHandler = null;

                hookedDevice.Unhook();

                txtHotKey.Text = GetDeviceHotKeyText(device);
                return;
            }

            if (firewallManager == null)
                return;

            switch (type)
            {
                case HookTypeEnum.Clamping:
                    await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetAllow);
                    Debug.WriteLine("Connect");
                    break;
            }
        }

        private async Task HookedDevice_KeyPressed(object? sender, DeviceKeyEventArgs e)
        {
            var type = (HookTypeEnum)configManager.ConfigData.hookType.type;

            if (firewallManager == null)
                return;

            switch (type)
            {
                case HookTypeEnum.Clamping:
                    await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetBlock);
                    Debug.WriteLine("Disconnect");
                    break;
                case HookTypeEnum.Switcher:
                    if (firewallManager.isAllow)
                    {
                        await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetBlock);
                        Debug.WriteLine("Disconnect");
                    }
                    else
                    {
                        await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetAllow);
                        Debug.WriteLine("Connect");
                    }
                    break;
                case HookTypeEnum.Holder:
                    if (firewallManager.isAllow)
                    {
                        await Task.Run(async () =>
                        {
                            await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetBlock);
                            Debug.WriteLine("Disconnect");
                            await Task.Delay(TimeSpan.FromSeconds(configManager.ConfigData.hookType.holderTimer));
                            await firewallManager.ExecuteCommandAsync(FirewallActionEnum.SetAllow);
                            Debug.WriteLine("Connect");
                        });
                    }
                    break;
            }
        }

        private void ToggleHotKeyActions(bool enabled)
        {
            comboDevice.Enabled = !enabled;
            btnEditHotKey.Enabled = !enabled;
            btnHook.Enabled = !enabled;
            txtHotKey.Enabled = enabled;
        }

        private void ToggleHookActions(bool enabled)
        {
            panelRuleConfig.Enabled = !enabled;
            panelTypeHook.Enabled = !enabled;
            comboDevice.Enabled = !enabled;
            btnEditHotKey.Enabled = !enabled;
            btnHook.Enabled = !enabled;
            btnUnhook.Enabled = enabled;
        }

        private bool CheckConfigForStart()
        {
            if (!File.Exists(configManager.ConfigData.rule.path) ||
                (!configManager.ConfigData.rule.chkIn && !configManager.ConfigData.rule.chkOut) ||
                (configManager.ConfigData.hookType.type == 2 && configManager.ConfigData.hookType.holderTimer <= 0) ||
                string.IsNullOrEmpty(GetDeviceHotKeyText((DeviceEnum)configManager.ConfigData.device.type)))
                return false;

            return true;
        }

        private async void btnHook_Click(object sender, EventArgs e)
        {
            var device = (DeviceEnum)comboDevice.SelectedIndex;

            if (!CheckConfigForStart() || !deviceMap.TryGetValue(device, out var hookedDevice))
            {
                MessageBox.Show("Some configuration element is specified incorrectly", "1x", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToggleHookActions(true);

            if (firewallManager != null)
            {
                await firewallManager.ExecuteCommandAsync(FirewallActionEnum.Delete);
                firewallManager = null;
            }

            firewallManager = new("oneXDisconnect",
                configManager.ConfigData.rule.path,
                configManager.ConfigData.rule.chkIn,
                configManager.ConfigData.rule.chkOut);
            await firewallManager.ExecuteCommandAsync(FirewallActionEnum.Add);

            keyReleasedHandler = async (sender, e) => await HookedDevice_KeyReleased(sender, e);
            hookedDevice.KeyReleased += keyReleasedHandler;

            keyPressedHandler = async (sender, e) => await HookedDevice_KeyPressed(sender, e);
            hookedDevice.KeyPressed += keyPressedHandler;
            await hookedDevice.Hook();
        }

        private async void btnUnhook_Click(object sender, EventArgs e)
        {
            var device = (DeviceEnum)comboDevice.SelectedIndex;

            if (!deviceMap.TryGetValue(device, out var hookedDevice) || firewallManager == null)
            {
                MessageBox.Show("Unexpected error", "1x", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToggleHookActions(false);

            await firewallManager.ExecuteCommandAsync(FirewallActionEnum.Delete);
            firewallManager = null;

            hookedDevice.KeyReleased -= keyReleasedHandler;
            keyReleasedHandler = null;

            hookedDevice.KeyPressed -= keyPressedHandler;
            keyPressedHandler = null;

            hookedDevice.Unhook();
        }
    }
}