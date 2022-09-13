using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{

    public class Timer
    {
        class TimerUnit
        {
            bool onCountdown;
            int elapsedSteps;
            int totalSteps;
            public TimerUnit(float time)
            {
                onCountdown = false;
                elapsedSteps = 0;
                this.totalSteps = TimeToFixedSteps(time);
            }
            public void Countdown()
            {
                onCountdown = true;
            }
            public void FixedUpdate()
            {
                if (onCountdown && elapsedSteps < totalSteps - 1)
                {
                    elapsedSteps++;
                }
                else
                {
                    onCountdown = false;
                    elapsedSteps = 0;
                }
            }
            public bool IsItDone()
            {
                return !onCountdown;
            }
            public void Reset()
            {
                onCountdown = false;
                elapsedSteps = 0;
            }
            public void SetCountdownTime(float time)
            {
                totalSteps = TimeToFixedSteps(time);
            }

            public float GetElapsedTime()
            {
                return elapsedSteps * Time.fixedDeltaTime;
            }

            public float GetLeftTime()
            {
                return (totalSteps - elapsedSteps) * Time.fixedDeltaTime;
            }

            private static int TimeToFixedSteps(float time)
            {
                return (int)(time / Time.fixedDeltaTime);
            }
        }

        private Dictionary<string, TimerUnit> timerDic;

        internal Timer()
        {
            timerDic = new Dictionary<string, TimerUnit>();
        }

        public void Add(string name, float time)
        {
            timerDic.Add(name, new TimerUnit(time));
        }

        public void Remove(string name)
        {
            timerDic.Remove(name);
        }

        public void Countdown(string name)
        {
            timerDic[name].Countdown();
        }

        public void FixedUpdate()
        {

            foreach (var cd in timerDic.Values)
            {
                cd.FixedUpdate();
            }
        }

        public bool IsItDone(string name)
        {
            return timerDic[name].IsItDone();
        }

        public void Reset(string name)
        {
            timerDic[name].Reset();
        }

        public void SetCountdownTime(string name, float time)
        {
            timerDic[name].SetCountdownTime(time);
        }

        public float GetElapsedTime(string name)
        {
            return timerDic[name].GetElapsedTime();
        }

        public float GetLeftTime(string name)
        {
            return timerDic[name].GetLeftTime();
        }

        public void Destroy()
        {
            TimerManager.Instance?.DestroyTimer(this);
        }
    }

    public class TimerManager : Singleton<TimerManager>
    {
        private List<Timer> timersList;

        public TimerManager()
        {
            timersList = new List<Timer>();
        }

        public Timer CreaterTimer()
        {
            Timer timers = new Timer();
            timersList.Add(timers);
            return timers;
        }

        internal void DestroyTimer(Timer timers)
        {
            timersList.Remove(timers);
        }

        private void FixedUpdate()
        {
            foreach(Timer timers in timersList)
            {
                timers.FixedUpdate();
            }
        }
    }
}

