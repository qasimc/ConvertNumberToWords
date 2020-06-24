using ConvertNumberToWords.Domain.Models;
using ConvertNumberToWords.RepositoryInterfaces;
using ConvertNumberToWords.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertNumberToWords.Services
{
    public class ConvertedNumberSaver : IStoreConvertedNumbersToDatabase
    {

        ICommunicateWithDB NumberToWordsDatabase;

        public ConvertedNumberSaver(ICommunicateWithDB numberToWordsDatabase)
        {
            NumberToWordsDatabase = numberToWordsDatabase;
        }
        public ResultValue<string> StoreToDatabase(string number, string words)
        {
            var result = NumberToWordsDatabase.InsertToDB(number, words);

            return result;
        }
    }
}
