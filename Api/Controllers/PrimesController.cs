using System;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly EventId _eventId = new EventId();

        public PrimesController(ILogger<PrimesController> logger) => _logger = logger;

        // POST api/values
        [HttpPost]
        ///<summary>
        /// Calcula o número primo na posição informada
        /// <param name="primeIndex">Posição do primo desejado</param>
        /// <returns>o número primo calculado</returns>
        ///<summary>
        public int Post([FromBody] Prime prime)
        {
            try
            {
                int calculatedPrime = prime.CalculatePrimeByIndex(_eventId, _logger);

                if (calculatedPrime < 1)
                    Response.StatusCode = 400;

                return calculatedPrime;
            }
            catch (Exception e)
            {
                _logger.LogDebug(_eventId, e, "Ocorreu um erro ao calcular o primo de posicao {0}", prime.PrimeIndex);

                Response.StatusCode = 400;
                return -1;
            }
            finally
            {
                _logger.LogInformation(_eventId, "Request para PrimeController método Post efetuado. Retornou status {0}", Response.StatusCode);
            }
        }

        [HttpGet]
        public string Teste() => "Hello world";
    }
}
