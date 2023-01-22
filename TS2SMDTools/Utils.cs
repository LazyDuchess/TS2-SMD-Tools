using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS2SMDTools
{
    public static class Utils
    {
        /// <summary>
        /// Converts a float to a string, with 6 decimal places, no scientific notation.
        /// </summary>
        /// <param name="number">Number to convert to string.</param>
        /// <returns>String representation of float.</returns>
        public static string FloatString(this float number)
        {
            var str = number.ToString(".######", CultureInfo.InvariantCulture.NumberFormat);
            if (str.StartsWith(".") || str.Length == 0)
                str = "0" + str;
            if (str.StartsWith("-"))
            {
                if (str.Length == 1)
                    str = str + "0";
                else
                {
                    if (str[1] == '.')
                    {
                        str = "-0" + str.Substring(1);
                    }
                }
            }
            var hasDecimalPlace = false;
            if (str.Contains("."))
                hasDecimalPlace = true;
            if (!hasDecimalPlace)
                str += ".000000";
            else
            {
                var decimalIndex = str.IndexOf('.');
                var wholeDecimal = str.Substring(decimalIndex+1);
                var decimalAmount = wholeDecimal.Length;

                for (var i = 0; i < 6 - decimalAmount; i++)
                    str += "0";
            }
            return str;
        }
    }
}
