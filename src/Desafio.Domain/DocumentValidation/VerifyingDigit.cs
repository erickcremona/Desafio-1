using System.Collections.Generic;

namespace Desafio.Domain.DocumentValidation
{
    public class VerifyingDigit
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacements = new Dictionary<int, string>();
        private bool _moduleComplementer = true;

        public VerifyingDigit(string number)
        {
            _number = number;
        }

        public VerifyingDigit WithMultipliersFromTo(int firstMultiplier, int lastMultiplier)
        {
            _multipliers.Clear();
            for (var i = firstMultiplier; i <= lastMultiplier; i++)
                _multipliers.Add(i);

            return this;
        }

        public VerifyingDigit Replacing(string substitute, params int[] digits)
        {
            foreach (var i in digits)
            {
                _replacements[i] = substitute;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, digit);
        }

        public string CalculateDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += produto;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % Module);
            var resul = _moduleComplementer ? Module - mod : mod;

            return _replacements.ContainsKey(resul) ? _replacements[resul] : resul.ToString();
        }
    }
}
