using System;
using Microsoft.Extensions.Logging;

namespace Api.Models
{
    public class Prime
    {
        public int PrimeIndex { get; set; }

        //
        /// <summary>
        /// Calcula o primo na posicao informada na propriedade PrimeIndex
        /// </summary>
        /// <param name="eventId">id do evento de log atual</param>
        /// <param name="logger">estrutura de log para possíveis logs de execução</param>
        /// <returns>O primo na posição solicitada</returns>
        public int CalculatePrimeByIndex(EventId eventId, ILogger logger)
        {
            if (PrimeIndex < 1)
                return -1;
            else if (PrimeIndex == 1)
                return 2;
            else if (PrimeIndex == 2)
                return 3;
            else
            {
                int prime = 1;
                try
                {                    
                    for (int primeCandidate = 5, j = 2; j < PrimeIndex; primeCandidate += 2)
                    {                
                        bool isPrime = NumberIsPrime(primeCandidate);

                        if (isPrime)
                        {
                            prime = primeCandidate;
                            j++;
                        }
                    }
                    return prime;
                }
                finally
                {
                    logger.LogInformation(eventId, "Finalizando método CalculatePrime com o primo {0}", prime);
                }
            }
        }

        private bool NumberIsPrime(int primeCandidate)
        {
            int squareRoot = (int)Math.Ceiling(Math.Sqrt(primeCandidate));
            int divisionAttempt = 3;
            bool isNotPrime = false;
            while (divisionAttempt <= squareRoot && !isNotPrime)
            {
                isNotPrime = primeCandidate % divisionAttempt == 0;
                divisionAttempt += 2;
            }

            return !isNotPrime;
        }
    }
}
