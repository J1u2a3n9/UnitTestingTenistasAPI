using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Data.Entities;
using Xunit;

namespace TenistasUnitTest.General
{
    [ExcludeFromCodeCoverage]
    public class TennisPlayerEntityTest
    {
        [Fact]
        public void IdTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                Id = 1
            };
            Assert.Equal(1, tennisPlayer.Id);
        }
        [Fact]
        public void FullNameTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                FullName = "Jose"
            };
            Assert.Equal("Jose", tennisPlayer.FullName);

        }
        [Fact]
        public void NationalityTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                Nationality = "Argentino"
            };
            Assert.Equal("Argentino", tennisPlayer.Nationality);
        }
        [Fact]
        public void RankingTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                Ranking = 5
            };
            Assert.Equal(5, tennisPlayer.Ranking);
        }
        [Fact]
        public void BestRankingTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                BestRanking = 10
            };
            Assert.Equal(10, tennisPlayer.BestRanking);
        }
        [Fact]
        public void GrandSlamTitlesTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                GrandSlamTitles = 10
            };
            Assert.Equal(10, tennisPlayer.GrandSlamTitles);
        }
        [Fact]
        public void TotalTitlesTest()
        {
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                TotalTitles = 10
            };
            Assert.Equal(10, tennisPlayer.TotalTitles);
        }
        [Fact]
        public void BirthdateTest()
        {
            var dateTime = "06/11/1999 03:59:52 AM";
            var BirthdateTime = DateTime.Parse(dateTime, System.Globalization.CultureInfo.InvariantCulture);
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                Birthdate = DateTime.Parse(dateTime, System.Globalization.CultureInfo.InvariantCulture)
            };
            Assert.Equal(BirthdateTime, tennisPlayer.Birthdate);
        }

        [Fact]
        public void TourneysTest()
        {
            TourneyEntity[] _tourneys = new TourneyEntity[2]
            {
                new TourneyEntity()
                {
                    Id=1,
                    Name="Copa",
                    Country="Brasil",
                    playerId=4

                },
                new TourneyEntity()
                {
                    Id=2,
                    Name="Copas",
                    Country="Ecuador",
                    playerId=5

                }
            };
            TennisPlayerEntity tennisPlayer = new TennisPlayerEntity()
            {
                Tourneys = _tourneys
            };

            Assert.Equal(_tourneys, tennisPlayer.Tourneys);


        }
    }
}
