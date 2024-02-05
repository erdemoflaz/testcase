using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace testcase.Services
{
    public class NumberService
    {
        private readonly ILogger<NumberService> _logger;
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NumberService(ILogger<NumberService> logger, AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public int FindLargestPrimeNumber()
        {
            try
            {
                var allPrimes = _dbContext.primenumbers.Select(p => p.number).ToList();
                int largestPrime = allPrimes.Max();
                return largestPrime;
            }
            catch (Exception ex)
            {
                _logger.LogError("Hata: " + ex.Message);
                return 0;
            }
        }

        public bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public async Task<bool> StorePrimeNumber(int number)
        {
            try
            {
                if (!IsPrime(number))
                {
                    return false;
                }

                int cookieUserId = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["userId"].ToString());
                
                var newPrimeNumber = new PrimeNumber
                {
                    number = number,
                    userId = cookieUserId
                };

                _dbContext.primenumbers.Add(newPrimeNumber);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Number successfully added.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public List<PrimeNumberViewModel> GetLastFivePrimeNumbers()
        {
            try
            {
                var lastFivePrimeNumbers = _dbContext.primenumbers
                    .Include(p => p.User)
                    .OrderByDescending(p => p.id)
                    .Take(5)
                    .Select(p => new PrimeNumberViewModel
                    {
                        Number = p.number,
                        Username = p.User.username
                    })
                    .ToList();

                return lastFivePrimeNumbers;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting the last five prime numbers: " + ex.Message);
                return new List<PrimeNumberViewModel>();
            }
        }
    }
}