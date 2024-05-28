using System;

namespace StopwatchApp.Models
{
    public class LapTime
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime RecordedAt { get; set; }

        public LapTime()
        {
            RecordedAt = DateTime.Now;
        }
    }
}
