﻿namespace PasswordGeneratorMvc.Models
{
    public class PasswordOptions
    {
        public int Length { get; set; } = 12;
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = true;
    }
}

