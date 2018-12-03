using System;

namespace ConverterWcfServiceLibrary
{
    internal class CurrencyConvert
    {
        private readonly string _amount;
        private int _dollars;
        private int _cents;

        public CurrencyConvert(string amount)
        {
            _amount = amount;
        }

        /// <summary>
        /// Convert number amount of currency to text amount
        /// </summary>
        /// <returns>Converted currency amout</returns>
        public string Convert()
        {
            if (!ConvertInputToInts())
                return "Invalid input!";

            //Convert dollars
            string dollars = ConvertNumberToWords(_dollars);

            if (_dollars == 1)
                dollars += " dollar";
            else
            {
                dollars += " dollars";
            }

            //Convert cents
            string cents = String.Empty;

            if (_cents > 0)
            {
                cents = " and " + ConvertNumberToWords(_cents);

                if (_cents == 1)
                    cents += " cent";
                else
                    cents += " cents";
            }

            return dollars + cents;

        }

        /// <summary>
        /// Parse currency amount string to integers
        /// </summary>
        /// <returns>true => parsing is succesfull</returns>
        private bool ConvertInputToInts()
        {
            var dollarsCents = _amount.Split(',');

            //parse dollars to int
            string dollars = dollarsCents[0];
            bool parse = int.TryParse(dollars, out _dollars);
            if (!parse)
                return false;
            if(_dollars < 0 || _dollars > 999999999)
                return false;

            //parse cents to int
            if (dollarsCents.Length > 1)
            {
                string cents = dollarsCents[1];
                if (cents.Length == 1)
                    cents += "0"; // convert eg. 9,1 => 9,10
                if(cents.Length > 2)
                    return false; //eg. 3,001 is wrong

                parse = int.TryParse(cents, out _cents);
                if (!parse) return false;
                if (_cents < 0 || _cents > 99)
                    return false;
            }

            return true;

        }

        /// <summary>
        /// Convert number value to text value
        /// </summary>
        /// <param name="number">number to be converted</param>
        /// <returns>converted value</returns>
        private string ConvertNumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertNumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertNumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                var unitValues = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensValues = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitValues[number];
                else
                {
                    words += tensValues[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitValues[number % 10];
                }
            }

            return words;
        }
    }
}
