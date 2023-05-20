using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneXDisconnect.Models.Events
{
    public class DeviceKeyEventArgs : EventArgs
    {
        public int KeyAsInt { get; set; }

        public DeviceKeyEventArgs(int keyAsInt)
        {
            KeyAsInt = keyAsInt;
        }
    }
}
