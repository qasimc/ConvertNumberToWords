using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConvertNumberToWords.Models;
using ConvertNumberToWords.Service.Interfaces;
using Microsoft.AspNetCore.Routing;

namespace ConvertNumberToWords.Controllers
{
    public class HomeController : Controller
    {
        IConvertNumbersToWords NumbersToWordsConverter;
        public HomeController(IConvertNumbersToWords numbersToWordsConverter)
        {
            NumbersToWordsConverter = numbersToWordsConverter;
        }

        
        public IActionResult ConvertToWords([FromBody]string numberValue)
        {
            var retVal = Json(NumbersToWordsConverter.Convert(Decimal.Parse(numberValue)).Value);
            return retVal;
        }


        public IActionResult Index()
        {
            return View();
        }


    }
}
