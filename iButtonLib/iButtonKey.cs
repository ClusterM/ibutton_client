using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster.iButtonLib
{
    public class iButtonKey
    {
        public byte Type { get; private set; }
        public string Key { get; private set; }
        public byte CRC { get; private set; }
        //public string Raw { get; private set; }

        public iButtonKey(string data)
        {
            Type = byte.Parse(data.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            if (Type == 0xFF)
            {
                Key = data.Substring(2, 2) + "-" + data.Substring(4, 2);
                CRC = 0;
            }
            else if (Type == 0xFE)
            {
                Key = data.Substring(2, 2) + "-" + data.Substring(4, 2) + "-" + data.Substring(6, 2) + "-" + data.Substring(8, 2);
                CRC = 0;
            }
            else
            {
                Key = data.Substring(12, 2) + "-" + data.Substring(10, 2) + "-" + data.Substring(8, 2) +
                    "-" + data.Substring(6, 2) + "-" + data.Substring(4, 2) + "-" + data.Substring(2, 2);
                CRC = byte.Parse(data.Substring(14, 2), NumberStyles.AllowHexSpecifier);
            }
        }
        public iButtonKey(byte[] data, int offset)
        {
            Type = data[offset];
            if (Type == 0xFF)
            {
                Key = string.Format("{0:X2}{1:X2}", data[1 + offset], data[2 + offset]);
                CRC = 0;
            }
            else if (Type == 0xFE)
            {
                Key = string.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2}", data[1 + offset], data[2 + offset] + data[3 + offset] + data[4 + offset]);
                CRC = 0;
            }
            else
            {
                Key = string.Format("{5:X2}-{4:X2}-{3:X2}-{2:X2}-{1:X2}-{0:X2}", data[1 + offset], data[2 + offset], data[3 + offset],
                    data[4 + offset], data[5 + offset], data[6 + offset]);
                CRC = data[7 + offset];
            }
        }
        public iButtonKey(byte type, string key, byte crc)
        {
            Type = type;
            Key = key;
            CRC = crc;
        }
        public override string ToString()
        {
            var key = Key.Replace("-", "");
            if (Type == 0xFF)
            {
                return string.Format("{0:X2}{1}", Type, key);
            }
            if (Type == 0xFE)
            {
                return string.Format("{0:X2}{1}{2}{3}{4}", Type, key.Substring(0, 2), key.Substring(2, 2), key.Substring(4, 2), key.Substring(6, 2));
            }
            else
            {
                return string.Format("{0:X2}{6}{5}{4}{3}{2}{1}{7:X2}", Type, key.Substring(0, 2), key.Substring(2, 2), key.Substring(4, 2), key.Substring(6, 2), key.Substring(8, 2), key.Substring(10, 2), CRC);
            }
        }
        public byte[] ToArray()
        {
            byte[] result = new byte[8];
            var str = ToString().Replace("-", "");
            for (int i = 0; i < 8; i++)
            {
                if (i * 2 <= str.Length - 2)
                    result[i] = byte.Parse(str.Substring(i * 2, 2), NumberStyles.AllowHexSpecifier);
                else result[i] = 0;
            }
            return result;
        }
    }
}
