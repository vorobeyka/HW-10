using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumbers.Server.Services
{
    public class PrimesService : IPrimesService
    {
        public async Task<IEnumerable<int>> FromRange(int from, int to)
        {
            await Task.Delay(100);

            if (from > to || to < 2)
            {
                return Enumerable.Empty<int>();
            }

            var primes = Enumerable.Range(from, to - from + 1).Where(x => IsPrime(x));
            return primes;
        }

        public async Task<bool> IsPrimeNumber(int number)
        {
            await Task.Delay(100);
            return IsPrime(number);
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
