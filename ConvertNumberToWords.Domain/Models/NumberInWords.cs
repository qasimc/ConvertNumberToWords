using System;
namespace ConvertNumberToWords.Domain.Models
{
    public class NumberInWords
    {
        public readonly decimal Number;
        public readonly string InWords;
        public NumberInWords(decimal number, string inWords)
        {
            Number = number;
            InWords = inWords;
        }
    }
}
