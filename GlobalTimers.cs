using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Timer = System.Threading.Timer;

namespace D2RCameraTool
{
    internal static class GlobalTimers
    {
        public static Timer ProcessScan;
        public static Timer ValueScan;
        public static Timer ZoomScan;

        public static void Reset() {
            if (ProcessScan != null)
                ProcessScan.Dispose();
            ProcessScan = new Timer(ProcessScanTimerCallback!, null, 1000, 1000);

            if (ValueScan != null)
                ValueScan.Dispose();
            ValueScan = new Timer(ValueScanTimerCallback!, null, 5000, 5000);

            if (ZoomScan != null) {
                ZoomScan.Dispose();
            }
            ZoomScan = new Timer(ZoomScanTimerCallback!, null, 6000, 6000);
        }

        private static void ProcessScanTimerCallback(object state) {
            Program.MainFormInstance.Invoke(Program.ProcessScan_Tick);
        }

        private static void ValueScanTimerCallback(object state) {
            Program.MainFormInstance.Invoke(Program.ValueScan_Tick);
        }
        private static void ZoomScanTimerCallback(object state) {
            Program.MainFormInstance.Invoke(Program.ZoomScan_Tick);
        }
    }
}
