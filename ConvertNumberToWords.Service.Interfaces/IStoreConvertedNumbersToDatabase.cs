using ConvertNumberToWords.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertNumberToWords.Service.Interfaces
{
    public interface IStoreConvertedNumbersToDatabase
    {
        ResultValue<string> StoreToDatabase(string number, string words);
    }
}
