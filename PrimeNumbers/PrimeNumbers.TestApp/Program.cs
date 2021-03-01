using System;
using System.Threading.Tasks;
using PrimeNumbers.TestApp.Models.Tests;

namespace PrimeNumbers.TestApp
{
    class Program
    {
        #region strings for valid requests
        private static readonly string _validRequestForRangeFirst = "/primes?from=1&to=5";
        private static readonly string _validRequestForRangeSecond = "/primes?from=5&to=17";
        private static readonly string _validRequestForRangeThird = "/primes?from=-5&to=1";

        private static readonly string _validRequestForFirstNumber = "/primes/7";
        private static readonly string _validRequestForSecondNumber = "/primes/2";
        private static readonly string _validRequestForThirdNumber = "/primes/11";
        #endregion

        #region strings for invalid requests
        private static readonly string _invalidRequestForRangeFirst = "/primes?to=abc";
        private static readonly string _invalidRequestForRangeSecond = "/primes?from=a&to=5";
        private static readonly string _invalidRequestForRangeThird = "/primes?from=1";

        private static readonly string _invalidRequestForFirstNumber = "/primes/1";
        private static readonly string _invalidRequestForSecondNumber = "/primes/4";
        private static readonly string _invalidRequestForThirdNumber = "/primes/0";
        #endregion

        static async Task Main(string[] args)
        {
            var validator = TestValidator.GetInstance();

            //test for root "/"
            await validator.TestRoot();

            //valid tests
            var validTest = new ValidTest(_validRequestForFirstNumber, _validRequestForRangeFirst);
            await validator.TestRequest(validTest, 7, (1, 5));
            await validator.TestRequest(
                validTest.SetNewRequests(_validRequestForSecondNumber, _validRequestForRangeSecond),
                2, (5, 17));
            await validator.TestRequest(
                validTest.SetNewRequests(_validRequestForThirdNumber, _validRequestForRangeThird),
                11, (-5, 1));

            //invalid tests
            var invalidTest = new InvalidTest(_invalidRequestForFirstNumber, _invalidRequestForRangeFirst);
            await validator.TestRequest(invalidTest, 1, (null, "abc"));
            await validator.TestRequest(
                invalidTest.SetNewRequests(_invalidRequestForSecondNumber, _invalidRequestForRangeSecond),
                4, ("a", 5));
            await validator.TestRequest(
                invalidTest.SetNewRequests(_invalidRequestForThirdNumber, _invalidRequestForRangeThird),
                0, (1, null));
        }
    }
}
