using System;
using System.Collections.Generic;

namespace ConvertNumberToWords.Domain.Models
{
    public class ResultValue<T>
    {
        public readonly bool IsOk;
        public readonly T Value;
        public readonly IEnumerable<Error> Errors;

        internal ResultValue(IEnumerable<Error> errors)
        {
            IsOk = false;
            Value = default(T);
            Errors = errors;
        }

        internal ResultValue()
        {
            IsOk = true;
            Value = default(T);
            Errors = new List<Error>();
        }

        internal ResultValue(T value)
        {
            IsOk = true;
            Value = value;
            Errors = new List<Error>();
        }

    }
}
