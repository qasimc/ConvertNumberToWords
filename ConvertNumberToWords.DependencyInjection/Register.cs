using ConvertNumberToWords.Database;
using ConvertNumberToWords.RepositoryInterfaces;
using ConvertNumberToWords.Service.Interfaces;
using ConvertNumberToWords.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConvertNumberToWords.DependencyInjection
{
    public static class Register
    {
        public static void RegisterInterfaces(IServiceCollection services)
        {
            services.AddScoped<IConvertNumbersToWords, NumberToWordsConverter>();
            services.AddScoped<ICommunicateWithDB, DB>();
            services.AddScoped<IStoreConvertedNumbersToDatabase, ConvertedNumberSaver>();
        }
    }
}
