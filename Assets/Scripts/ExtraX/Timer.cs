using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class Timer
    {
        private double startTime;


        public Timer()
        {
            startTime = Time.realtimeSinceStartupAsDouble;
        }

        public void Start()
        {
            startTime = Time.realtimeSinceStartupAsDouble;
        }


        public double GetElapsedTime()
        {
            return Time.realtimeSinceStartupAsDouble - startTime;
        }

        public bool IsElapse(double time)
        {
            return Time.realtimeSinceStartupAsDouble - startTime > time;
        }

    }
}

