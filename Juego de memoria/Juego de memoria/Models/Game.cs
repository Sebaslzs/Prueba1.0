using System;
using System.Collections.Generic;

namespace MemoryGameApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public List<Card> Cards { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Score { get; set; }
    }
}
