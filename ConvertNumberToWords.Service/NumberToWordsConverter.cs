using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConvertNumberToWords.Service.Interfaces;
using ConvertNumberToWords.Domain.Models;
using System.Linq;
using ConvertNumberToWords.RepositoryInterfaces;

namespace ConvertNumberToWords.Services
{
    public class NumberToWordsConverter : IConvertNumbersToWords
    {

        public ResultValue<string> Convert(string number)
        {
            try
            {
                bool isNegativeNumber = false;
                number = number.Replace(",", "");
                if (!Decimal.TryParse(number, out decimal outputNumber))
                {
                    return Result.Failed<string>(Error.CreateFrom("InvalidNumber", ErrorType.InvalidNumber));
                }
                if (number.Contains('-'))
                {
                    isNegativeNumber = true;
                    number = number.Replace("-", "");
                }
                List<string> splitNumber = new List<string>();
                if (number.Contains('.'))
                {
                    splitNumber = number.Split('.').ToList();
                }
                else
                {
                    splitNumber.Add(number);
                }

                string[] iterationMapping = { "", " thousand ", " million ", " billion ", " trillion ", " quadrillion ", " quintillion ", " sextillion ", " septillion ", " octillion " };
                string word = string.Empty;

                for (int i = 0; i < splitNumber.Count; i++)
                {
                    string numberString = CreateNumberLengthToMultipleOfThree(Decimal.Parse(splitNumber[i]));

                    int index = numberString.Length;
                    int currentIteration = 0;
                    string tempWord = "";
                    while (index > 0)
                    {
                        string val = numberString.Substring(index - 3, 3);
                        tempWord = ConvertTriplet(int.Parse(val)) + iterationMapping[currentIteration] + tempWord;
                        index -= 3;
                        currentIteration++;
                    }
                    word += tempWord;
                    if (splitNumber.Count > 1 && !word.Contains("point"))
                        word += " point ";
                }
                if (isNegativeNumber)
                    word = "Minus " + word;
                return Result.Ok(word);
            }catch(Exception ex)
            {
                return Result.Failed<string>(Error.CreateFrom("InternalServerError", ErrorType.InternalServerError, ex.Message));
            }
        }


        public string CreateNumberLengthToMultipleOfThree(decimal number)
        {
            string numberString = number.ToString();

            while (numberString.Length % 3 != 0)
                numberString = "0" + numberString;

            return numberString;
        }

        public string ConvertTriplet(int number)
        {
            string res = ConvertOnes(number);
            res = ConvertTens(number) + " " + res;
            string hundreds = ConvertHunderds(number);
            res = string.Concat(hundreds, (hundreds != "" && res.Trim() != "") ? "and " : "", res);

            return res;
        }

        public string ConvertHunderds(int number)
        {
            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            number /= 100;

            return string.Concat(ones[number], number == 0 ? "" : " hundred ");
        }

        public string ConvertOnes(int number)
        {

            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int remainder = number % 100;
            int result = remainder / 10;
            if(result != 1) { 
                remainder = number % 10;
                return ones[remainder];
            }
            return "";
        }

        public string ConvertTens(int number)
        {

            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tees = { "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            int remainder = number % 100;

                int ten = remainder / 10;
                if (ten > 1)
                {
                    return tees[ten - 1];
                }
                else
                {
                    return ten == 0 ? "" : teens[number % 10];
                }
        }
    }
}
