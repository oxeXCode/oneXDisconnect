using oneXDisconnect.Models.Enums;
using oneXDisconnect.Models.Events;
using oneXDisconnect.Models.Interface;
using SharpDX.DirectInput;

namespace oneXDisconnect.Devices
{
    internal class KeyboardDevice : IDevice
    {
        private DirectInput _directInput;
        private Keyboard _keyboard;

        private readonly int pollingFrequency;

        public HookedStatusEnum Status { get; set; }
        private Key? key = null;
        public int? Key { get => (int?)key; set => key = (Key?)value; }

        public event EventHandler<DeviceKeyEventArgs>? KeyPressed;
        public event EventHandler<DeviceKeyEventArgs>? KeyReleased;

        public KeyboardDevice(int pollingFrequency)
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
            _keyboard = new Keyboard(_directInput);
            _keyboard.Properties.BufferSize = 128;
        }

        public async Task Hook()
        {
            if (Status == HookedStatusEnum.Hook || !IsConnected())
                return;

            Status = HookedStatusEnum.Hook;
            _keyboard.Acquire();

            do
            {
                _keyboard.Poll();
                var data = _keyboard.GetBufferedData();

                foreach (var state in data)
                {
                    if (key != null && key != state.Key) { }
                    else
                    {
                        if (state.IsReleased)
                            KeyReleased?.Invoke(this, new DeviceKeyEventArgs((int)state.Key));
                        if (state.IsPressed)
                            KeyPressed?.Invoke(this, new DeviceKeyEventArgs((int)state.Key));
                    }
                }

                await Task.Delay(pollingFrequency);
            } while (Status == HookedStatusEnum.Hook && IsConnected());
        }
        public void Unhook()
        {
            if (Status == HookedStatusEnum.Hook && IsConnected())
            {
                Status = HookedStatusEnum.None;
                _keyboard.Unacquire();
            }
        }

        public void Dispose()
        {
            if (IsConnected())
            {
                try
                {
                    _keyboard.Unacquire();
                    _keyboard.Dispose();
                    _directInput.Dispose();
                }
                catch { }
            }
        }

        public bool IsConnected() =>
            _keyboard != null && !_keyboard.IsDisposed;
    }
}
