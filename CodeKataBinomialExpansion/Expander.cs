using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeKataBinomialExpansion
{
    public static class Expander
    {
        public static string Expand(string expr)
        {
            var variables = Parse(expr);
            var x = variables[0];
            var y = variables[1];
            var n = variables[2];
            if (variables.LastOrDefault() == 0) return "1";
            var coefficients = FindCoefficients((int)n);
            var output = String.Empty;
            for(var i=0; i<=n; i++)
            {
                var sign = coefficients[i] < 0 ? "-" : "+";
                var coefficient = (coefficients[i] != 1 && n-i != 0) ? coefficients[i].ToString() : n-i==0 ? "1" : "";
                var variable = (coefficients[i] != 0 && n-i > 1) ? "x^" : (coefficients[i] != 0 && n-i > 0) ? "x" : "";
                var exponent = (coefficients[i] != 0 && n-i > 1) ? (n - i).ToString() : "";
                output += $"{sign}{coefficient}{variable}{exponent}";
            }
            return output.Trim('+');
        }

        public static int Factorialize(int f)
        {
            var fFact = 1;
            for(var i=2; i<=f; i++)
            {
                fFact *= i;
            }
            return fFact;
        }

        public static int[] FindCoefficients(int n)
        {
            var nFact = Factorialize(n);
            var coefficients = new int[n+1];
            for(var k=0; k <= n; k++)
            {
                var kFact = Factorialize(k);
                var nkFact = Factorialize(n-k);
                if (kFact * nkFact == 0) coefficients[k] = 1;
                else coefficients[k] = nFact / (kFact * nkFact);
            }
            return coefficients;
        }

        public static decimal[] Parse(string v)
        {
            var x = Regex.Match(v, "(?<=\\()(.*)(?=x)");
            var y = Regex.Match(v, "(?<=x)(.*)(?=\\))");
            var n = Regex.Match(v, "[^^]*$");
            
            return new decimal[] { Decimal.Parse(x.Value != "" ? x.Value : "1"), Decimal.Parse(y.Value != "" ? y.Value : "0"), Decimal.Parse(n.Value != "" ? n.Value : "0") };
        }
    }

}
