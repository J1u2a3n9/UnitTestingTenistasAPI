using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Data.Entities;
using Xunit;

namespace TenistasUnitTest.General
{
    [ExcludeFromCodeCoverage]

    public class TourneyEntityTest
    {
        [Fact]
        public void IdTest()
        {
            TourneyEntity _tourney = new TourneyEntity()
            {
                Id = 1
            };
            Assert.Equal(1, _tourney.Id);
        }

        [Fact]
        public void NameTest()
        {
            TourneyEntity _tourney = new TourneyEntity()
            {
                Name = "Torneo"
            };
            Assert.Equal("Torneo", _tourney.Name);
        }
        [Fact]
        public void CountryTest()
        {
            TourneyEntity _tourney = new TourneyEntity()
            {
                Country = "Brasil"
            };
            Assert.Equal("Brasil", _tourney.Country);
        }
        [Fact]
        public void PlayerIdTest()
        {
            TourneyEntity _tourney = new TourneyEntity()
            {
                playerId = 2
            };
            Assert.Equal(2, _tourney.playerId);
        }
    }
}
