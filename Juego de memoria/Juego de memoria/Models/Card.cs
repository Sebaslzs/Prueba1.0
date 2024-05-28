using System;

namespace MemoryGameApp.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMatched { get; set; }
        public bool IsFaceUp { get; set; }
    }
}
