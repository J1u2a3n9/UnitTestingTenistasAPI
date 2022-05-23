using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Models;
using Xunit;

namespace TenistasUnitTest.General
{
    [ExcludeFromCodeCoverage]
    public class TennisPlayerModelTest
    {
        [Fact]
        public void IdTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                Id = 1
            };
            Assert.Equal(1, tennisPlayer.Id);
        }
        [Fact]
        public void FullNameTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                Name = "Jose"
            };
            Assert.Equal("Jose", tennisPlayer.Name);

        }
        [Fact]
        public void NationalityTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                Nationality = "Argentino"
            };
            Assert.Equal("Argentino", tennisPlayer.Nationality);
        }
        [Fact]
        public void RankingTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                CurrentRanking = 5
            };
            Assert.Equal(5, tennisPlayer.CurrentRanking);
        }
        [Fact]
        public void BestRankingTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                BestRanking = 10
            };
            Assert.Equal(10, tennisPlayer.BestRanking);
        }
        [Fact]
        public void GrandSlamTitlesTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                GrandSlamTitles = 10
            };
            Assert.Equal(10, tennisPlayer.GrandSlamTitles);
        }
        [Fact]
        public void TotalTitlesTest()
        {
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                CareerTitles = 10
            };
            Assert.Equal(10, tennisPlayer.CareerTitles);
        }
        [Fact]
        public void BirthdateTest()
        {
            var dateTime = "06/11/1999 03:59:52 AM";
            var BirthdateTime = DateTime.Parse(dateTime, System.Globalization.CultureInfo.InvariantCulture);
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                Birthdate = DateTime.Parse(dateTime, System.Globalization.CultureInfo.InvariantCulture)
            };
            Assert.Equal(BirthdateTime, tennisPlayer.Birthdate);
        }

        [Fact]
        public void TourneysTest()
        {
            TourneyModel[] _tourneys = new TourneyModel[2]
            {
                new TourneyModel()
                {
                    Id=1,
                    Name="Copa",
                    Country="Brasil",
                    playerId=4

                },
                new TourneyModel()
                {
                    Id=2,
                    Name="Copas",
                    Country="Ecuador",
                    playerId=5

                }
            };
            TennisPlayerModel tennisPlayer = new TennisPlayerModel()
            {
                Tourneys = _tourneys
            };

            Assert.Equal(_tourneys, tennisPlayer.Tourneys);


        }
    }
}
