using System;
using System.Net.Http;
using System.Threading.Tasks;
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
        public void Post([FromBody] PrimeWebHook primeWebHook)
        {
            Prime prime = new Prime() { PrimeIndex = primeWebHook.PrimeIndex };
            
            try
            {
                int calculatedPrime = prime.CalculatePrimeByIndex(_eventId, _logger);                

                if (calculatedPrime < 1)
                    Response.StatusCode = 400;

                HttpClient webhookResponse = new HttpClient();
                webhookResponse.PostAsJsonAsync<int>(primeWebHook.ResponseUrl, calculatedPrime);                
            }
            catch (Exception e)
            {
                _logger.LogDebug(_eventId, e, "Ocorreu um erro ao calcular o primo de posicao {0}", prime.PrimeIndex);

                Response.StatusCode = 400;                
            }
            finally
            {
                _logger.LogInformation(_eventId, "Request para PrimeController método Post efetuado. Retornou status {0}", Response.StatusCode);
            }
        }     
    }
}
