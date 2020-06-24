using System;
using ConvertNumberToWords.Domain.Models;
namespace ConvertNumberToWords.Service.Interfaces
{
    public interface IConvertNumbersToWords
    {
        ResultValue<string> Convert(string number);
    }
}
