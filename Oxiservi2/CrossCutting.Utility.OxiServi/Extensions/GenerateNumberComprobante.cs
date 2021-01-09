using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Utility.OxiServi.Extensions
{
    public class GenerateNumberComprobante
    {
        public static string GenerateNumber(string number)//000012
        {
            string result = "";
            var count = 0;
            var n = Convert.ToInt32(number);
            n++;
            for(int i = 0; i < number.Length; i++)
            {
                if (i > number.Length - n.ToString().Length - 1)
                {
                    result += n.ToString()[count];
                    count++;
                }
                else
                    result += "0";
            }
            return result;
        }
    }
}
