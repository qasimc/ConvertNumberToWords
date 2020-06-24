using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConvertNumberToWordsUI.Models;
using ConvertNumberToWords.Service.Interfaces;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ConvertNumberToWordsUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IConvertNumbersToWords NumbersToWordsConverter;
        readonly IStoreConvertedNumbersToDatabase ConvertedNumberToDatabaseStorage;
        public HomeController(IConvertNumbersToWords numbersToWordsConverter, IStoreConvertedNumbersToDatabase convertedNumbersToDatabaseStorage)
        {
            NumbersToWordsConverter = numbersToWordsConverter;
            ConvertedNumberToDatabaseStorage = convertedNumbersToDatabaseStorage;
        }


        public IActionResult ConvertToWords([FromBody] string numberValue)
        {
            var conversionResult = NumbersToWordsConverter.Convert(numberValue);

            if (!conversionResult.IsOk)
            {
                var response = new JsonResult(string.Join(",", conversionResult.Errors.Select(x => x.ErrorType.Title)))
                {
                    StatusCode = 500

                };
                return response;
            }
            else
            {

                var storageResult = ConvertedNumberToDatabaseStorage.StoreToDatabase(numberValue, conversionResult.Value);

                if (!storageResult.IsOk)
                {
                    var response = new JsonResult(string.Join(",", storageResult.Errors.Select(x => x.ErrorType.Title)))
                    {
                        StatusCode = 500

                    };
                    return response;
                }
            }

            return Json(conversionResult.Value);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
