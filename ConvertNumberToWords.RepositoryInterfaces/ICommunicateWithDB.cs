using ConvertNumberToWords.Domain.Models;
using System;

namespace ConvertNumberToWords.RepositoryInterfaces
{
    public interface ICommunicateWithDB
    {
        ResultValue<string> InsertToDB(string inputNumber, string convertedText);
    }
}
