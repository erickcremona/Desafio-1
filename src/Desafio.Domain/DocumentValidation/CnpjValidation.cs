using System;
using System.Linq;

namespace Desafio.Domain.DocumentValidation
{
    public class CnpjValidation
    {
        public const int LengthCnpj = 14;

        public static bool Validate(string cpnj)
        {
            var cnpjNumber = Utils.OnlyNumber(cpnj);

            if (!HasValidLength(cnpjNumber)) return false;
            return !HasRepeatedDigits(cnpjNumber) && HasValidDigits(cnpjNumber);
        }

        private static bool HasValidLength(string value)
        {
            return value.Length == LengthCnpj;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, LengthCnpj - 2);

            var verifyingDigit = new VerifyingDigit(number)
                .WithMultipliersFromTo(2, 9)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.CalculateDigit();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthCnpj - 2, 2);
        }
    }
}
