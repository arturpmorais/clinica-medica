using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DB
{
    public enum PasswordStrength
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public static class PasswordCheck
    {
        public static PasswordStrength GetPasswordStrength(string password)
        {
            int score = 0;
            
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password.Trim())) return PasswordStrength.Blank;
            if (!HasMinimumLength(password, 5)) return PasswordStrength.VeryWeak;
            if (HasMinimumLength(password, 8)) score++;
            if (HasUpperCaseLetter(password) && HasLowerCaseLetter(password)) score++;
            if (HasDigit(password)) score++;
            if (HasSpecialChar(password)) score++;

            return (PasswordStrength)score;
        }

        private static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        private static bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        private static bool HasSpecialChar(string password)
        {
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        private static bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        private static bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }
    }
}