using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumConverter
{
    public static class NumHelper
    {
        /// <summary>
        /// Convert numeric string to System.Int32
        /// </summary>
        /// <param name="stringNumber">input string</param>
        /// <returns>System.Int32 value representing the input string</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Parse(string stringNumber)
        {
            stringNumber = stringNumber.Trim(' ');

            if(stringNumber.Length < 1)
                throw new ArgumentException($"parameter {nameof(stringNumber)} is not valid {typeof(int)}");

            bool isNegative = CheckForNegative(ref stringNumber);

            if (ValidationForInt(stringNumber))
                throw new ArgumentException($"parameter {nameof(stringNumber)} is not valid {typeof(int)}");

            int y;

            try
            {
                y = IntFromString(stringNumber, isNegative);
            }
            catch (OverflowException ex)
            {
                throw new ArgumentException($"parameter {nameof(stringNumber)} is not valid {typeof(int)}", ex);
            }

            return y;
        }

        /// <summary>
        /// Convert numeric string to System.Int32
        /// </summary>
        /// <param name="stringNumber">input string</param>
        /// <param name="result">System.Int32 value representing the input string</param>
        /// <returns>Is process was successful</returns>
        public static bool TryParse(string stringNumber, out int result)
        {
            result = 0;
            stringNumber = stringNumber.Trim(' ');

            if (stringNumber.Length < 1)
                return false;

            bool isNegative = CheckForNegative(ref stringNumber);

            if (ValidationForInt(stringNumber))
                return false;

            try
            {
                result = IntFromString(stringNumber, isNegative);

            }
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        private static bool ValidationForInt(string str)
            => str.Length > 10 || str.Length < 1 || string.IsNullOrEmpty(str) || !str.All(char.IsDigit);

        private static bool CheckForNegative(ref string str)
        {
            if (str.StartsWith("-"))
            {
                str = str.Substring(1);

                return true;
            }

            return false;
        }

        private static int IntFromString(string str, bool isNegative)
        {
            int number = str.Aggregate(0, (cur, nxt) => checked(cur * 10 + (nxt - '0')));

            return isNegative ? number * -1 : number;
        }
    }
}
