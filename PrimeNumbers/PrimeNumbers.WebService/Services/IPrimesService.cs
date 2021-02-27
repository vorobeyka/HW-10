using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumbers.Server.Services
{
    public interface IPrimesService
    {
        Task<bool> IsPrimeNumber(int number);
        Task<IEnumerable<int>> FromRange(int from, int to);
    }
}
