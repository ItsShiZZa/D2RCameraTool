using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace D2RCameraTool
{
    internal class FloatValue
    {
        public long BaseAddress;
        public string BaseString;
        public byte[] DefaultBytes;
        public float LastValue;

        public FloatValue(byte[]? defaultBytes = null) {
            if (defaultBytes == null || defaultBytes.Length <= 0) {
                defaultBytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            }
            DefaultBytes = defaultBytes;
            LastValue = Read();
        }

        public void Reset() => Write(DefaultBytes);
        public void Write() => Write(DefaultBytes);

        public string ReadHex() => Program.FloatToHex(Read());

        public void UpdateBase(long baseAddr) {
            BaseAddress = baseAddr;
            BaseString = "0x" + baseAddr.ToString("X");
        }

        public float Read() {
            if (BaseAddress <= 0)
                return 0;

            var read = Program.MemLib.ReadFloat(BaseString, round: false);
            LastValue = read;
            return read;
        }

        public void Write(byte[] bytes) {
            if (BaseAddress <= 0 || bytes == null || bytes.Length <= 0)
                return;

            Program.MemLib.WriteBytes((UIntPtr)BaseAddress, bytes);
        }

        public bool Write(float newValue) {
            if (BaseAddress <= 0)
                return false;

            if (Program.MemLib.WriteMemory(BaseString, "float", newValue.ToString())) {
                LastValue = newValue;
                return true;
            } else {
                UpdateBase(0);
                return false;
            }            
        }
    }
}
