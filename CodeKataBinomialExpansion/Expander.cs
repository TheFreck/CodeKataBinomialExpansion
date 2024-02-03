using System.Text.RegularExpressions;

namespace CodeKataBinomialExpansion
{
    public static class Expander
    {
        public static string Expand(string expr)
        {
            Console.WriteLine(expr);
            var symbol = Regex.Match(expr, "[A-Za-z]").Value;
            var xMatch = Regex.Match(expr, "(?<=\\()(.*)(?=[A-Za-z])").Value;
            var x = Decimal.Parse(xMatch != "" ? xMatch : "1");
            var yMatch = Regex.Match(expr, "(?<=[A-Za-z])(.*)(?=\\))").Value;
            var y = Decimal.Parse(yMatch != "" ? yMatch : "0");
            var nMatch = Regex.Match(expr, "[^^]*$").Value;
            var n = int.Parse(nMatch != "" ? nMatch : "0");
            if (n == 0) return "1";
            if(n == 1) return Regex.Match(expr,"(?<=\\()(.*)(?=\\))").Value;
            var coefficients = FindCoefficients(n);
            var output = string.Empty;
            for (var i = 0; i <= n; i++)
            {
                var sign = "";
                if (n % 2 == 0)
                {
                    if ((x >= 0 && y >= 0) || (x < 0 && y < 0)) sign = "+";
                    if (x >= 0 && y < 0 && i % 2 == 0) sign = "+";
                    if (x >= 0 && y < 0 && i % 2 != 0) sign = "-";
                    if (x < 0 && y >= 0 && i % 2 == 0) sign = "+";
                    if (x < 0 && y >= 0 && i % 2 != 0) sign = "-";
                }
                else
                {
                    if (x >= 0 && y >= 0) sign = "+";
                    if (x < 0 && y < 0) sign = "-";
                    if (x >= 0 && y < 0 && i % 2 == 0) sign = "+";
                    if (x >= 0 && y < 0 && i % 2 != 0) sign = "-";
                    if (x < 0 && y >= 0 && i % 2 == 0) sign = "-";
                    if (x < 0 && y >= 0 && i % 2 != 0) sign = "+";
                }
                

                var coefficientVal = "";
                var variable = (coefficients[i] != 0 && n - i > 1) ? $"{symbol}^" : (coefficients[i] != 0 && n - i > 0) ? $"{symbol}" : "";
                var exponent = (coefficients[i] != 0 && n - i > 1) ? (n - i).ToString() : "";
                if(x>=0 && y >= 0)
                {
                    if (n - i > 0) coefficientVal = (Math.Pow((double)x, (double)n-i) * Math.Pow((double)y, (double)i) * coefficients[i]).ToString();
                    else coefficientVal = i!=0 ? Math.Pow((double)y,(double)n).ToString() : "";
                    if(coefficientVal == "1" && i != n) coefficientVal = "";
                }
                else if(x<0 && y < 0)
                {
                    coefficientVal = Math.Abs(Math.Pow((double)x, (double)n-i) * Math.Pow((double)y, (double)i) * coefficients[i]).ToString();
                    if (coefficientVal == "1" && i != n) coefficientVal = "";
                }
                else if(x>=0 && y < 0)
                {
                    coefficientVal = Math.Abs(Math.Pow((double)x, (double)n-i) * Math.Pow((double)y, (double)i) * coefficients[i]).ToString();
                    if (coefficientVal == "1" && i != n) coefficientVal = "";
                }
                else if(x<0 && y >= 0)
                {
                    coefficientVal = Math.Abs(Math.Pow((double)x, (double)n-i) * Math.Pow((double)y, (double)i) * coefficients[i]).ToString();
                    if (coefficientVal == "1" && i != n) coefficientVal = "";
                }
                output += $"{sign}{coefficientVal}{variable}{exponent}";
            }
            Console.WriteLine(output.Trim('+'));
            return output.Trim('+');
        }

        public static int Factorialize(int f)
        {
            var fFact = 1;
            for (var i = 2; i <= f; i++)
            {
                fFact *= i;
            }
            return fFact;
        }

        public static int[] FindCoefficients(int n)
        {
            var nFact = Factorialize(n);
            var coefficients = new int[n + 1];
            for (var k = 0; k <= n; k++)
            {
                var kFact = Factorialize(k);
                var nkFact = Factorialize(n - k);
                if (kFact * nkFact == 0) coefficients[k] = 1;
                else coefficients[k] = nFact / (kFact * nkFact);
            }
            return coefficients;
        }

        public static decimal[] Parse(string v)
        {
            var symbol = Regex.Match(v, "[A - Za - z]").Value;
            var x = Regex.Match(v, "(?<=\\()(.*)(?=[A-Za-z])").Value;
            var y = Regex.Match(v, "(?<=[A-Za-z])(.*)(?=\\))").Value;
            var n = Regex.Match(v, "[^^]*$").Value;

            return new decimal[] { Decimal.Parse(x != "" ? x : "1"), Decimal.Parse(y != "" ? y : "0"), Decimal.Parse(n != "" ? n : "0") };
        }
    }

}
