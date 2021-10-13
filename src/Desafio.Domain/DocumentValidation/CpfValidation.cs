using System;
using System.Linq;

namespace Desafio.Domain.DocumentValidation
{
    public class CpfValidation
    {
        public const int LengthCpf = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumber = Utils.OnlyNumber(cpf);

            if (!HasValidLength(cpfNumber)) return false;
            return !HasRepeatedDigits(cpfNumber) && HasValidDigits(cpfNumber);
        }

        private static bool HasValidLength(string value)
        {
            return value.Length == LengthCpf;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, LengthCpf - 2);
            var verifyingDigit = new VerifyingDigit(number)
                .WithMultipliersFromTo(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.CalculateDigit();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthCpf - 2, 2);
        }
    }
}
