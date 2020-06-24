using NUnit.Framework;
using System;

namespace ConvertNumberToWords.Services.UnitTests
{
    public class NumberToWordsConverterUnitTests
    {
        [Test]
        public void CreateNumberLengthToMultipleOfThree_OriginalLengthLessThanThree()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            decimal numberToTest = 23;

            var result = converter.CreateNumberLengthToMultipleOfThree(numberToTest);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("023", result);
        }

        [Test]

        public void CreateNumberLengthToMultipleOfThree_OriginalLengthIsZero()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            decimal numberToTest = 0;

            var result = converter.CreateNumberLengthToMultipleOfThree(numberToTest);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("000", result);
        }

        [Test]

        public void GetOnes()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            int numberToTest = 224;

            string result = converter.ConvertOnes(numberToTest);

            Assert.AreEqual("four", result);
        }

        [Test]
        public void GetTens_Teens()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            int numberToTest = 214;

            string result = converter.ConvertTens(numberToTest);

            Assert.AreEqual("fourteen", result);
        }

        [Test]
        public void GetTens_Tees()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            int numberToTest = 224;

            string result = converter.ConvertTens(numberToTest);

            Assert.AreEqual("twenty", result);
        }

        [Test]
        public void GetHundreds()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            int numberToTest = 224;

            string result = converter.ConvertHunderds(numberToTest);

            Assert.AreEqual("two hundred ", result);
        }

        [Test]
        public void ConvertTripletToWord()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            int numberToTest = 224;

            string result = converter.ConvertTriplet(numberToTest);

            Assert.AreEqual("two hundred and twenty four", result);
        }

        [Test]
        public void ConvertThousandsToWord()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            string numberToTest = "2224";

            var result = converter.Convert(numberToTest);

            Assert.AreEqual(true, result.IsOk);
            Assert.AreEqual(" two thousand two hundred and twenty four", result.Value);
        }

        [Test]
        public void ConvertHundredThousandsToWord()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            string numberToTest = "222224";

            var result = converter.Convert(numberToTest);

            Assert.AreEqual(true, result.IsOk);
            Assert.AreEqual("two hundred and twenty two thousand two hundred and twenty four", result.Value);
        }

        [Test]
        public void ConvertMillionsToWord()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            string numberToTest = "3222224";

            var result = converter.Convert(numberToTest);

            Assert.AreEqual(true, result.IsOk);
            Assert.AreEqual(" three million two hundred and twenty two thousand two hundred and twenty four", result.Value);
        }

        [Test]
        public void ConvertHundredMillionsToWord()
        {
            NumberToWordsConverter converter = new NumberToWordsConverter();

            string numberToTest = "223222224";

            var result = converter.Convert(numberToTest);

            Assert.AreEqual(true, result.IsOk);
            Assert.AreEqual("two hundred and twenty three million two hundred and twenty two thousand two hundred and twenty four", result.Value);
        }
    }
}