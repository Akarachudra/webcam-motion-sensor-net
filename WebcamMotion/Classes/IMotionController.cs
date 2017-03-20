using System.Collections.Generic;
using AForge.Video;

namespace WebcamMotion.Classes
{
    public interface IMotionController
    {
        bool IsActive { get; }

        event NewFrameEventHandler OnFrameProcess;

        void SelectDevice(string deviceName);
        void SelectDevice(int index);
        void StartWithDelay(int minutesDelay = 0);
        void Stop();
        List<string> DevicesList { get; }
    }
}