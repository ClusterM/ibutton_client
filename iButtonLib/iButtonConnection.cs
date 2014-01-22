using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster.iButtonLib
{
    public class iButtonConnection
    {
        public string Port { get; set; }

        public iButtonConnection(string port)
        {
            Port = port;
        }

        private SerialPort OpenPort()
        {
            SerialPort sPort;
            sPort = new SerialPort();
            sPort.PortName = Port;
            sPort.WriteTimeout = 500; sPort.ReadTimeout = 3000;
            sPort.BaudRate = 19200;
            sPort.Parity = Parity.None;
            sPort.DataBits = 8;
            sPort.StopBits = StopBits.One;
            sPort.Handshake = Handshake.None;
            sPort.DtrEnable = false;
            sPort.RtsEnable = false;
            sPort.NewLine = System.Environment.NewLine;
            sPort.Open();
            return sPort;
        }

        public bool Test()
        {
            bool result = false;
            SerialPort port = null;
            try
            {
                port = OpenPort();
                port.Write("\r\nname\r\n");
                while (true)
                {
                    var line = port.ReadLine().Trim();
                    if (line.Contains("iButton"))
                    {
                        result = true;
                    }
                }
            }
            catch { }
            finally
            {
                if (port != null)
                    port.Close();
            }
            return result;
        }

        public iButtonKey[] ReadKeys()
        {
            var port = OpenPort();
            try
            {
                var result = new List<iButtonKey>();
                port.Write("\r\nread\r\n");
                int keyCount = 1;
                do
                {
                    var line = port.ReadLine().Trim();
                    if (line.StartsWith("Count: "))
                    {
                        keyCount = byte.Parse(line.Substring(7), NumberStyles.AllowHexSpecifier);
                    }
                    else if (line.StartsWith("Key: "))
                    {
                        string keyLine = line.Substring(8);
                        result.Add(new iButtonKey(keyLine));
                    }
                } while (result.Count < keyCount);
                return result.ToArray();
            }
            finally
            {
                port.Close();
            }            
        }

        public void Erase()
        {
            var port = OpenPort();
            try
            {
                port.Write("\r\nerase\r\n");
                while (true)
                {
                    var line = port.ReadLine().Trim();
                    if (line == "Done.") return;
                }
            }
            finally
            {
                port.Close();
            }
        }

        public void Write(iButtonKey key)
        {
            var port = OpenPort();
            try
            {
                port.Write("\r\nwrite " + key.ToString() + "\r\n");
                while (true)
                {
                    var line = port.ReadLine().Trim();
                    if (line == "Done.") return;
                }
            }
            finally
            {
                port.Close();
            }
        }

        public void Reboot()
        {
            var port = OpenPort();
            try
            {
                port.Write("\r\nreboot\r\n");
                while (true)
                {
                    var line = port.ReadLine().Trim();
                    if (line == "OK.") return;
                }
            }
            finally
            {
                port.Close();
            }
        }
    }
}
