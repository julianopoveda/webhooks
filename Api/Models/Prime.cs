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
        public int CalculatePrime(EventId eventId, ILogger logger)
        {
            if (PrimeIndex < 1)
                return -1;
            else if (PrimeIndex == 1)
                return 2;
            else
            {
                int prime = 1;
                try
                {
                    for (int i = 1, j = 1; j < PrimeIndex; i++)
                    {
                        int primeCandidate = 2 * i + 1;
                        int squareRoot = (int)Math.Floor(Math.Sqrt(primeCandidate));
                        for (int divisonAttemp = 0; divisonAttemp < squareRoot; divisonAttemp++)
                        {
                            if (primeCandidate % divisonAttemp != 0)
                                prime = primeCandidate;
                            else
                                break;//Caso exista um divisor o número não é primo e não há motivos para seguir no teste.
                        }

                        if (prime == primeCandidate)
                            j++;
                    }
                    return prime;
                }
                finally
                {
                    logger.LogInformation(eventId, "Finalizando método CalculatePrime com o primo {0}", prime);
                }
            }
        }
    }
}
