using oneXDisconnect.Models.Enums;
using oneXDisconnect.Models.Events;
using oneXDisconnect.Models.Interface;
using SharpDX.DirectInput;

namespace oneXDisconnect.Devices
{
    public class MouseDevice : IDevice
    {
        private DirectInput _directInput;
        private Mouse _mouse;

        private readonly int pollingFrequency;

        public HookedStatusEnum Status { get; set; }
        public MouseOffset? key = null;
        public int? Key { get => (int?)key; set => key = (MouseOffset?)value; }

        public event EventHandler<DeviceKeyEventArgs>? KeyPressed;
        public event EventHandler<DeviceKeyEventArgs>? KeyReleased;

        public MouseDevice(int pollingFrequency)
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
            _mouse = new Mouse(_directInput);
            _mouse.Properties.BufferSize = 64;
        }

        public async Task Hook()
        {
            if (Status == HookedStatusEnum.Hook || !IsConnected())
                return;

            Status = HookedStatusEnum.Hook;
            _mouse.Acquire();

            do
            {
                _mouse.Poll();
                var data = _mouse.GetBufferedData();

                foreach (var state in data)
                {
                    if (!state.IsButton || (int)state.Offset < 12)
                        continue;

                    if (key != null && key != state.Offset) { }
                    else
                    {
                        if (state.Value == 0)
                            KeyReleased?.Invoke(this, new DeviceKeyEventArgs((int)state.Offset));
                        else
                            KeyPressed?.Invoke(this, new DeviceKeyEventArgs((int)state.Offset));
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
                    _mouse.Unacquire();
                    _mouse.Dispose();
                    _directInput.Dispose();
                }
                catch { }
            }
        }

        public void Unhook()
        {
            if (Status == HookedStatusEnum.Hook && IsConnected())
            {
                Status = HookedStatusEnum.None;
                _mouse.Unacquire();
            }
        }

        public bool IsConnected() =>
            _mouse != null && !_mouse.IsDisposed;
    }
}
