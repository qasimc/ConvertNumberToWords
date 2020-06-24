using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNumberToWords.Domain.Models
{
    public static class Result
    {
        public static ResultValue<T> Ok<T>(T value)
        {
            return new ResultValue<T>(value);
        }

        public static ResultValue<T> Ok<T>()
        {
            return new ResultValue<T>();
        }

        public static ResultValue<T> Failed<T>(IEnumerable<Error> errors)
        {
            return new ResultValue<T>(errors);
        }

        public static ResultValue<T> Failed<T>(Error error)
        {
            return new ResultValue<T>(new List<Error> { error });
        }
    }
}
