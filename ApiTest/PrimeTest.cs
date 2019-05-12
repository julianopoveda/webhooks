using Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace ApiTest
{
    public class PrimeTest
    {
        private readonly EventId _eventId;
        private readonly ILogger _logger;

        public PrimeTest()
        {
            _eventId = new EventId();
            _logger = NullLogger<PrimeTest>.Instance;
        }


        [Fact]
        public void PrimeiraPosicaoDeveSer2()
        {
            Prime prime = new Prime() { PrimeIndex = 1 };

            Assert.Equal(2, prime.CalculatePrime(_eventId, _logger));
        }

        [Fact]
        public void SegundaPosicaoDeveSer3()
        {
            Prime prime = new Prime() { PrimeIndex = 2 };

            Assert.Equal(3, prime.CalculatePrime(_eventId, _logger));
        }

        [Fact]
        public void DeveRetornarMenos1SePrimeIndexMenorQue1()
        {
            Prime prime = new Prime() { PrimeIndex = -4 };

            Assert.Equal(-1, prime.CalculatePrime(_eventId, _logger));
        }

        [Fact]
        public void OitavoPrimoDeveSer19()
        {
            Prime prime = new Prime() { PrimeIndex = 8 };

            Assert.Equal(19, prime.CalculatePrime(_eventId, _logger));
        }
    }
}
