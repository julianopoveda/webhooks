using System;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        ///<summary>
        /// Calcula o número primo na posição informada
        /// <param name="primeIndex">Posição do primo desejado</param>
        /// <returns>o número primo calculado</returns>
        ///<summary>
        public int Post([FromBody] Prime prime)
        {            
            if (prime.primeIndex < 1)
            {
                Response.StatusCode = 400;
                return -1;
            }

            if (prime.primeIndex == 1)
                return 2;
            else
            {
                try
                {
                    return CalculatePrime(prime.primeIndex);
                }
                catch (Exception e)
                {
                    //TODO: log error
                    Response.StatusCode = 400;
                    return -1;
                }
                finally
                {
                    //TODO: do someting
                }
            }
        }

        private int CalculatePrime(int primeIndex)
        {
            int prime = 1;
            try
            {
                for (int i = 1, j = 1; j < primeIndex; i++)
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
            catch (Exception e)
            {
                //TODO: log error
                throw;
            }
            finally
            {
                //TODO: log action                
            }
        }

        [HttpGet]
        public string Teste()=>"Hello world";
    }
}
