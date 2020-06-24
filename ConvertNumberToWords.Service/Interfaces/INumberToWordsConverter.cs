using System;
namespace ConvertNumberToWords.Services
{
    public interface INumberToWordsConverter
    {
        string CreateNumberLengthToMultipleOfThree(decimal number);
        string ConvertTriplet(int number);
        string ConvertHunderds(int number);
        string ConvertOnes(int number);
        string ConvertTens(int number);
    }
}
