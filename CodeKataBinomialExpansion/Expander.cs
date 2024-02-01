using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKataBinomialExpansion
{
    public static class Expander
    {
        public static string Expand(string expr)
        {
            return "";
        }

        public static decimal[] Parse(string v)
        {
            var x = 0;
            var y = 0;
            var n = 0;
            for(var i=0; i<v.Length; i++)
            {
                switch(v[i])
                {
                    case '(':
                        break;
                    case ')':
                        break;
                    case '^':
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
