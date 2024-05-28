using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorMvc.Models;
using System;
using System.Text;

namespace PasswordGeneratorMvc.Controllers
{
    public class PasswordController : Controller
    {
        private static readonly Random random = new Random();

        public IActionResult Generate()
        {
            return View(new PasswordOptions());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Generate(PasswordOptions options)
        {
            if (ModelState.IsValid)
            {
                ViewBag.GeneratedPassword = GeneratePassword(options);
            }
            return View(options);
        }

        private string GeneratePassword(PasswordOptions options)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            var characterSet = new StringBuilder();
            if (options.IncludeLowercase) characterSet.Append(lowercase);
            if (options.IncludeUppercase) characterSet.Append(uppercase);
            if (options.IncludeNumbers) characterSet.Append(numbers);
            if (options.IncludeSymbols) characterSet.Append(symbols);

            if (characterSet.Length == 0)
                throw new ArgumentException("At least one character type must be included.");

            var password = new StringBuilder();
            for (int i = 0; i < options.Length; i++)
            {
                var index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            return password.ToString();
        }
    }
}
