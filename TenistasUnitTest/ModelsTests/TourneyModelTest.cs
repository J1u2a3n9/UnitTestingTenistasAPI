using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Models;
using Xunit;

namespace TenistasUnitTest.General
{
    [ExcludeFromCodeCoverage]

    public class TourneyModelTest
    {
        [Fact]
        public void IdTest()
        {
            TourneyModel _tourney = new TourneyModel()
            {
                Id = 1
            };
            Assert.Equal(1, _tourney.Id);
        }

        [Fact]
        public void NameTest()
        {
            TourneyModel _tourney = new TourneyModel()
            {
                Name = "Torneo"
            };
            Assert.Equal("Torneo", _tourney.Name);
        }
        [Fact]
        public void CountryTest()
        {
            TourneyModel _tourney = new TourneyModel()
            {
                Country = "Brasil"
            };
            Assert.Equal("Brasil", _tourney.Country);
        }
        [Fact]
        public void PlayerIdTest()
        {
            TourneyModel _tourney = new TourneyModel()
            {
                playerId = 2
            };
            Assert.Equal(2, _tourney.playerId);
        }
    }
}
