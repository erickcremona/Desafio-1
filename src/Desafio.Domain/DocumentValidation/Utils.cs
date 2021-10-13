namespace Desafio.Domain.DocumentValidation
{
    public class Utils
    {
        public static string OnlyNumber(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
