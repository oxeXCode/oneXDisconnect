using oneXDisconnect.Models.Enums;
using oneXDisconnect.Models.Events;
using oneXDisconnect.Models.Interface;
using SharpDX.DirectInput;
using System.Diagnostics;

namespace oneXDisconnect.Devices
{
    public class ControllerDevice : IDevice
    {
        private DirectInput _directInput;
        private Joystick? _joystick;

        private readonly int pollingFrequency;

        public HookedStatusEnum Status { get; set; }
        public JoystickOffset? key = null;
        public int? Key { get => (int?)key; set => key = (JoystickOffset?)value; }

        public event EventHandler<DeviceKeyEventArgs>? KeyPressed;
        public event EventHandler<DeviceKeyEventArgs>? KeyReleased;

        public ControllerDevice(int pollingFrequency)
        {
            this.pollingFrequency = pollingFrequency;

            Initialize();
        }

        public void Initialize()
        {
            if (Status == HookedStatusEnum.Hook)
                return;
            Dispose();

            _directInput = new DirectInput();
            var devices = _directInput.GetDevices();
            _joystick = devices
                .Where(x => x.Type == DeviceType.Gamepad || x.Type == DeviceType.Joystick)
                .Select(x => new Joystick(_directInput, x.InstanceGuid))
                .FirstOrDefault();
            if (_joystick == null)
            {
                Status = HookedStatusEnum.NotConnected;
                return;
            }
            _joystick.Properties.BufferSize = 64;
        }

        public async Task Hook()
        {
            if (Status is HookedStatusEnum.Hook or HookedStatusEnum.NotConnected || !IsConnected())
                return;

            Status = HookedStatusEnum.Hook;
            _joystick.Acquire();

            do
            {
                _joystick.Poll();
                var data = _joystick.GetBufferedData();

                foreach (var state in data)
                {
                    if (!state.Offset.ToString().Contains("Button"))
                        continue;

                    if (key != null && key != state.Offset) { }
                    else
                    {
                        if (state.Value == 0)
                            KeyReleased?.Invoke(this, new DeviceKeyEventArgs((int)state.Offset));
                        else
                            KeyPressed?.Invoke(this, new DeviceKeyEventArgs((int)state.Offset));

                        Debug.WriteLine(state.Sequence + " " + state.Value);
                    }
                }

                await Task.Delay(pollingFrequency);
            } while (Status == HookedStatusEnum.Hook && IsConnected());
        }

        public void Dispose()
        {
            if (IsConnected())
            {
                try
                {
                    _joystick.Unacquire();
                    _joystick.Dispose();
                    _directInput.Dispose();
                }
                catch { }
            }
        }

        public bool IsConnected() =>
            _joystick != null && !_joystick.IsDisposed;

        public void Unhook()
        {
            if (Status == HookedStatusEnum.Hook && IsConnected())
            {
                Status = HookedStatusEnum.None;
                _joystick.Unacquire();
            }
        }
    }
}
