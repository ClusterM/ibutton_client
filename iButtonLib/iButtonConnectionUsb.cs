using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;

namespace Cluster.iButtonLib
{
    public class iButtonConnectionUsb
    {
        const int VID = 0x0C16;
        const int PID = 0xDF05;

        public iButtonConnectionUsb()
        {
        }

        private HIDDevice OpenDevice()
        {
            return HIDDevice.FindDevice(VID, PID);
        }

        public bool IsPresent()
        {
            var device = OpenDevice();
            var present = device != null;
            if (present)
                device.Dispose();
            return present; 
        }

        public iButtonKey[] ReadKeys()
        {
            var device = OpenDevice();
            byte[] buffer = new byte[9];
            try
            {
                var result = new List<iButtonKey>();
                int keyCount = 0;
                bool initPacket;
                do
                {
                    initPacket = true;
                    device.Read(buffer, 0, 9);
                    for (int i = 2; i < 8; i++)
                    {
                        if (buffer[i] != 0xFF) initPacket = false;
                    }
                } while (!initPacket) ;
                keyCount = buffer[1];
                for (int key = 0; key < keyCount; key++)
                {
                    device.Read(buffer, 0, 9);
                    result.Add(new iButtonKey(buffer, 1));
                }
                return result.ToArray();
            }
            finally
            {
                device.Dispose();
            }            
        }

        public void Erase()
        {
            var device = OpenDevice();
            try
            {
                byte[] buffer = new byte[9] { 0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};
                device.Write(buffer, 0, 9);
            }
            finally
            {
                device.Dispose();
            }
        }

        public void Write(iButtonKey key)
        {
            var device = OpenDevice();
            try
            {
                byte[] buffer = new byte[9];
                buffer[0] = 0;
                var keyBuffer = key.ToArray();
                for (int i = 1; i <= 8; i++)
                    buffer[i] = keyBuffer[i - 1];
                device.Write(buffer, 0, 9);
            }
            finally
            {
                device.Dispose();
            }
        }
    }
}
