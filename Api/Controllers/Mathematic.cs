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
        [HttpPost]
        public async Task Post(Prime prime)
        {
            HttpClient request = new HttpClient(); 
            
            request.PostAsJsonAsync(new Uri("http://localhost:5000/api/Primes"), prime);            
        }
    }
}