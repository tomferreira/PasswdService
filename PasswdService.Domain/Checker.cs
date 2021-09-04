using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasswdService.Domain
{
    public class Checker
    {
        // Define the minumin lenght of a valid password
        private static readonly int MINIMUM_LENGTH = 9;

        private static readonly Dictionary<Regex, Result> NEGATIVE_CHECKS =
            new Dictionary<Regex, Result>()
            {
                { new Regex(@"[\s]+"), Result.InvalidCharacter },
                { new Regex(@"(.).*\1{1,}"), Result.InvalidRepeatedChar }
            };

        private static readonly Dictionary<Regex, Result> POSITIVE_CHECKS =
            new Dictionary<Regex, Result>()
            {
                { new Regex(@"[\d]+"), Result.InvalidNoneDigit },
                { new Regex(@"[A-Z]+"), Result.InvalidNoneUpperLetter },
                { new Regex(@"[a-z]+"), Result.InvalidNoneLowerLetter },
                { new Regex(@"[!@#\$%\^&\*\(\)\-\+]+"), Result.InvalidNoneSpecialChar}
            };

        public enum Result
        {
            Valid,
            InvalidCharacter,
            InvalidMinimumLenght,
            InvalidNoneDigit,
            InvalidNoneUpperLetter,
            InvalidNoneLowerLetter,
            InvalidNoneSpecialChar,
            InvalidRepeatedChar
        };

        // Premise: The order of verification is not important.
        public static Result IsValid(string password)
        {
            if (password == null || password.Length < MINIMUM_LENGTH)
                return Result.InvalidMinimumLenght;

            foreach (var check in NEGATIVE_CHECKS)
            {
                if (check.Key.IsMatch(password))
                    return check.Value;
            }

            foreach (var check in POSITIVE_CHECKS)
            {
                if (!check.Key.IsMatch(password))
                    return check.Value;
            }

            return Result.Valid;
        }
    }
}
