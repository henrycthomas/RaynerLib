using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace Rayner.Kinect
{
    public class Controller
    {
        public KinectSensor Sensor { get; set; }
        public KinectAudioSource AudioSource { get; set; }
        public Controller()
        {
            Sensor = KinectSensor.KinectSensors.FirstOrDefault();
            AudioSource = Sensor.AudioSource;
        }
    }
}
