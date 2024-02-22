using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RCameraTool
{
    internal class CameraPreset
    {
        public double Throttle;
        public float Sensitivity;

        public float Pitch;
        public float Yaw;
        public float Roll;
        public float Height;

        public float Zoom;

        public Keys PanHotKey;
        public Keys ZoomHotKey;

        public CameraPreset() {
            Throttle = MainForm.DEFAULT_THROTTLE_SECONDS;
            Sensitivity = MainForm.DEFAULT_SENSITIVITY;

            Pitch   = -0.892399f;
            Yaw     = 0.369644f;
            Roll    = 0.099046f;
            Height  = 0.239118f;

            Zoom    = 0f;

            ZoomHotKey = Keys.Z;
            PanHotKey = Keys.Space;
        }
    }
}
