using ConvertNumberToWords.Domain.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace ConverNumberToWords.DomainModels.UnitTests
{
    public class ResultModelTests
    {
        class TestClass
        {
            public int Id { get; set; }

            [Test]
            public void Ok_Should_ReturnResultValue()
            {
                var result = Result.Ok<TestClass>();

                Assert.IsTrue(result.IsOk);
                Assert.IsEmpty(result.Errors);
                Assert.AreEqual(null, result.Value);
            }

            [Test]
            public void OkWithValue_Should_ReturnResultValue()
            {
                var testClass = new TestClass()
                {
                    Id = Int32.MinValue
                };

                var result = Result.Ok<TestClass>(testClass);

                Assert.IsTrue(result.IsOk);
                Assert.IsEmpty(result.Errors);
                Assert.AreEqual(testClass, result.Value);

            }

            [Test]
            public void Failed_Should_ReturnResultValue()
            {
                var error = Error.CreateFrom("expectedSubject", ErrorType.InternalServerError, string.Empty);

                var result = Result.Failed<TestClass>(error);

                Assert.IsFalse(result.IsOk);
                Assert.IsNotEmpty(result.Errors);
                Assert.AreEqual(null, result.Value);
                Assert.Contains(error, result.Errors.ToList());
            }

            [Test]
            public void FailedWithCollection_Should_ReturnResultValue()
            {
                var error1 = Error.CreateFrom("expectedSubject1", ErrorType.InvalidNumber, string.Empty);
                var error2 = Error.CreateFrom("expectedSubject2", ErrorType.LargerThanDecimal, string.Empty);

                var result = Result.Failed<TestClass>(new[] { error1, error2 });

                Assert.IsFalse(result.IsOk);
                Assert.IsNotEmpty(result.Errors);
                Assert.AreEqual(null, result.Value);
                Assert.Contains(error1, result.Errors.ToList());
                Assert.Contains(error2, result.Errors.ToList());
            }

        }

    }
}