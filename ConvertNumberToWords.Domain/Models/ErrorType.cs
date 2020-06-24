using System;
namespace ConvertNumberToWords.Domain.Models
{
    public class ErrorType
    {
        public readonly string Type;
        public readonly string Title;

        private ErrorType(string type, string title)
        {
            Type = type;
            Title = title;
        }

        public static readonly ErrorType InvalidNumber = new ErrorType("InvalidNumber", "Invalid number has been input and cannot be converted to words.");
        public static readonly ErrorType LargerThanDecimal = new ErrorType("LargerThanDecimal", "Only numbers between " + decimal.MinValue + " and " + decimal.MaxValue + " can be processed");
        public static readonly ErrorType MissingNumber = new ErrorType("MissingNumber", "No number has been provided for processing");
        public static readonly ErrorType InternalServerError = new ErrorType("InternalServerError", "An internal server error occured while trying to process your request.");
        public static readonly ErrorType DatabaseError = new ErrorType("DatabaseError", "An error occured while trying to store data in the database.");
    }
}
