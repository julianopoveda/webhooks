using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathematicController: ControllerBase
    {
        private static int _calculatedPrime;

        [HttpPost]
        public async Task Post(Prime prime)
        {
            HttpClient request = new HttpClient(); 
            
            request.PostAsJsonAsync<object>(new Uri("http://localhost:5000/api/Primes"), new {
                PrimeIndex = prime.PrimeIndex,
                ResponseUrl = "http://localhost:5000/api/Mathematic/CalculatedPrime"
                });            
        }

        [HttpPost("CalculatedPrime")]
        public void Post([FromBody]dynamic CalculatedPrime)
        {
            _calculatedPrime = (int)CalculatedPrime;
        }

        [HttpGet]
        public string GetCalculatedPrime()
        {
            return $"O primo calculado foi: {_calculatedPrime}";
        }
    }
}