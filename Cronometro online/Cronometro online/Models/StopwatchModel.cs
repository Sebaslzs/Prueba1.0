using System;
using System.Collections.Generic;

namespace StopwatchApp.Models
{
    public class StopwatchModel
    {
        public TimeSpan ElapsedTime { get; private set; }
        public bool IsRunning { get; private set; }
        public List<LapTime> Laps { get; private set; }

        private DateTime _startTime;
        private TimeSpan _pausedTime;

        public StopwatchModel()
        {
            Laps = new List<LapTime>();
        }

        public void Start()
        {
            if (!IsRunning)
            {
                _startTime = DateTime.Now;
                IsRunning = true;
            }
        }

        public void Pause()
        {
            if (IsRunning)
            {
                _pausedTime += DateTime.Now - _startTime;
                IsRunning = false;
            }
        }

        public void Reset()
        {
            ElapsedTime = TimeSpan.Zero;
            _pausedTime = TimeSpan.Zero;
            IsRunning = false;
            Laps.Clear();
        }

        public void Lap()
        {
            if (IsRunning)
            {
                ElapsedTime = DateTime.Now - _startTime + _pausedTime;
                Laps.Add(new LapTime { Time = ElapsedTime });
                _startTime = DateTime.Now;
            }
        }

        public void UpdateElapsedTime()
        {
            if (IsRunning)
            {
                ElapsedTime = DateTime.Now - _startTime + _pausedTime;
            }
        }
    }
}
