using oneXDisconnect.Models.Enums;
using oneXDisconnect.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneXDisconnect.Models.Interface
{
    public interface IDevice : IDisposable
    {
        void Initialize();
        Task Hook();
        void Unhook();

        int? Key { get; set; }
        HookedStatusEnum Status { get; set; }

        event EventHandler<DeviceKeyEventArgs> KeyPressed;
        event EventHandler<DeviceKeyEventArgs> KeyReleased;
    }
}
