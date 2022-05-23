using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Data.Entities;
using TenistasAPI.Data.Repository;
using Xunit;

namespace TenistasUnitTest.General
{
    [ExcludeFromCodeCoverage]

    public class LibraryRepositoryTest
    {
        [Fact]
        public void CreateTennisPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var player = new TennisPlayerEntity() { Id = 11, FullName = "Juan Martín del Potro", Nationality = "Argentinian", Ranking = 139, BestRanking = 3, TotalTitles = 22, Birthdate = new DateTime(1988, 8, 23), GrandSlamTitles = 1 };
            var tennisPlayer = _libraryRepository.CreateTennisPlayer(player);
            Assert.IsType<TennisPlayerEntity>(tennisPlayer);
        }
        [Fact]
        public void CreateTennisPlayerTestId()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var player = new TennisPlayerEntity() { FullName = "Juan Martín del Potro", Nationality = "Argentinian", Ranking = 139, BestRanking = 3, TotalTitles = 22, Birthdate = new DateTime(1988, 8, 23), GrandSlamTitles = 1 };
            var tennisPlayer = _libraryRepository.CreateTennisPlayer(player);
            Assert.Equal(15, tennisPlayer.Id);
        }
        [Fact]
        public void CreateTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var tourney = new TourneyEntity() { Name = "RolandGarros", Country = "France", playerId = 1 };
            var tourneyCreated = _libraryRepository.CreateTourney(tourney);
            Assert.IsType<TourneyEntity>(tourneyCreated);
        }
        [Fact]
        public void CreateTourneyTestId()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var tourney = new TourneyEntity() { Name = "RolandGarros", Country = "France", playerId = 1 };
            var tourneyCreated = _libraryRepository.CreateTourney(tourney);
            Assert.Equal(8, tourneyCreated.Id);
        }
        [Fact]
        public void DeleteTennisPlayerTestAndVerify()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 14;
            var res = _libraryRepository.DeleteTennisPlayer(playerId);
            Assert.True(res);
            var player = _libraryRepository.GetTennisPlayer(playerId);
            Assert.Null(player);
        }
        [Fact]
        public void DeleteTennisPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 14;
            var res = _libraryRepository.DeleteTennisPlayer(playerId);
            Assert.True(res);

        }
        [Fact]
        public void DeleteInexistentTennisPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 20;
            var res = _libraryRepository.DeleteTennisPlayer(playerId);
            Assert.False(res);
        }
        [Fact]
        public void DeleteTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int tourneyId = 5;
            var res = _libraryRepository.DeleteTourney(tourneyId);
            Assert.True(res);
        }
        [Fact]
        public void DeleteTourneyTestAndVerify()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int tourneyId = 5;
            var res = _libraryRepository.DeleteTourney(tourneyId);
            Assert.True(res);
            var tourney = _libraryRepository.GetTourney(tourneyId);
            Assert.Null(tourney);
        }
        [Fact]
        public void DeleteInexistentTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int tourneyId = 20;
            var res = _libraryRepository.DeleteTourney(tourneyId);
            Assert.False(res);
        }
        [Fact]
        public void GetPlayerWithSameResultsTestCareertitles()
        {

            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 13;
            var player = _libraryRepository.GetTennisPlayer(playerId);
            var res = _libraryRepository.GetPlayerWithSameResults(playerId, "careertitles");
            foreach (var i in res)
            {
                Assert.Equal(i.TotalTitles, player.TotalTitles);
            }
        }
        [Fact]
        public void GetPlayerWithSameResultsTestDefault()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 9;
            var player = _libraryRepository.GetTennisPlayer(playerId);
            var res = _libraryRepository.GetPlayerWithSameResults(playerId, "test");
            foreach (var i in res)
            {
                Assert.Equal(i.GrandSlamTitles, player.GrandSlamTitles);
            }

        }
        [Fact]
        public void GetPlayerWithSameResultsTestGrandslams()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 9;
            var player = _libraryRepository.GetTennisPlayer(playerId);
            var res = _libraryRepository.GetPlayerWithSameResults(playerId, "grandslams");
            foreach (var i in res)
            {
                Assert.Equal(i.GrandSlamTitles, player.GrandSlamTitles);
            }
        }
        [Fact]
        public void GetTennisPlayersTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var players = _libraryRepository.GetTennisPlayers("");
            int count = 0;
            foreach (var i in players)
            {
                count++;
            }
            Assert.Equal(14, count);
        }
        [Fact]
        public void GetTop10TestAll()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var top10 = _libraryRepository.GetTop10("all");
            int count = 0;
            foreach (var i in top10)
            {
                count++;
            }
            Assert.Equal(6, count);

        }
        [Fact]
        public void GetTop10TestNationality()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var top10 = _libraryRepository.GetTop10("spanish");
            int count = 0;
            foreach (var i in top10)
            {
                count++;
            }
            Assert.Equal(3, count);
        }
        [Fact]
        public void GetTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int tourneyId = 1;
            var tourney = _libraryRepository.GetTourney(tourneyId);
            Assert.Equal("France", tourney.Country);
            Assert.Equal(tourneyId, tourney.Id);
            Assert.Equal("RolandGarros", tourney.Name);
        }
        [Fact]
        public void GetInexistentTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int tourneyId = 10;
            var tourney = _libraryRepository.GetTourney(tourneyId);
            Assert.Null(tourney);
        }
        [Fact]
        public void GetPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 1;
            var player = _libraryRepository.GetTennisPlayer(playerId);
            Assert.Equal("Rafael Nadal", player.FullName);
            Assert.Equal(playerId, player.Id);
            Assert.Equal("Spanish", player.Nationality);
            Assert.Equal(new DateTime(1993, 6, 3), player.Birthdate);
            Assert.Equal(2, player.Ranking);
            Assert.Equal(1, player.BestRanking);
            Assert.Equal(19, player.GrandSlamTitles);
            Assert.Equal(85, player.TotalTitles);
        }
        [Fact]
        public void GetInexistentPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 20;
            var player = _libraryRepository.GetTennisPlayer(playerId);
            Assert.Null(player);
        }
        [Fact]
        public void GetTourneysTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 1;
            var tourneys = _libraryRepository.GetTourneys(playerId);
            int count = 0;
            foreach (var i in tourneys)
            {
                count++;
            }
            Assert.Equal(3, count);
        }

        [Fact]
        public void GetInexistentTourneysTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 10;
            var tourneys = _libraryRepository.GetTourneys(playerId);
            int count = 0;
            foreach (var i in tourneys)
            {
                count++;
            }
            Assert.Equal(0, count);
        }
        [Fact]
        public void UpdateRankingsTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 1;
            _libraryRepository.UpdateRankings(playerId, 1);
            var player = _libraryRepository.GetTennisPlayer(playerId);
            Assert.Equal(1, player.Ranking);
            int playerAffectedId = 3;
            var playerAffected = _libraryRepository.GetTennisPlayer(playerAffectedId);
            Assert.Equal(2, playerAffected.Ranking);
        }
        [Fact]
        public void UpdateInexistingPlayerRankingsTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            int playerId = 20;
            _libraryRepository.UpdateRankings(playerId, 1);
            var player = _libraryRepository.GetTennisPlayer(playerId);
            Assert.Null(player);
            int playerAffectedId = 3;
            var playerAffected = _libraryRepository.GetTennisPlayer(playerAffectedId);
            Assert.Equal(1, playerAffected.Ranking);
        }
        [Fact]
        public void UpdateTennisPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var player = new TennisPlayerEntity()
            {
                Id = 1,
                FullName = "Juan Martín del Potro",
                Nationality = "Argentinian",
                Ranking = 139,
                BestRanking = 3,
                TotalTitles = 22,
                Birthdate = new DateTime(1988, 8, 23),
                GrandSlamTitles = 1
            };
            _libraryRepository.UpdateTennisPlayer(player);
            var playerEdited = _libraryRepository.GetTennisPlayer(player.Id);
            Assert.Equal("Juan Martín del Potro", playerEdited.FullName);
            Assert.Equal(1, playerEdited.Id);
            Assert.Equal("Argentinian", playerEdited.Nationality);
            Assert.Equal(new DateTime(1988, 8, 23), playerEdited.Birthdate);
            Assert.Equal(139, playerEdited.Ranking);
            Assert.Equal(3, playerEdited.BestRanking);
            Assert.Equal(1, playerEdited.GrandSlamTitles);
            Assert.Equal(22, playerEdited.TotalTitles);
        }
        [Fact]
        public void UpdateInexistentTennisPlayerTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var player = new TennisPlayerEntity() { Id = 20, FullName = "Juan Martín del Potro", Nationality = "Argentinian", Ranking = 139, BestRanking = 3, TotalTitles = 22, Birthdate = new DateTime(1988, 8, 23), GrandSlamTitles = 1 };
            var res = _libraryRepository.UpdateTennisPlayer(player);
            Assert.False(res);
        }
        [Fact]
        public void UpdateTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var tourney = new TourneyEntity() { Name = "Wimbledon", Country = "England", playerId = 2, Id = 1 };
            _libraryRepository.UpdateTourney(tourney);
            var tourneyEdited = _libraryRepository.GetTourney(1);
            Assert.Equal("England", tourneyEdited.Country);
            Assert.Equal("Wimbledon", tourneyEdited.Name);
            Assert.Equal(2, tourneyEdited.playerId);
        }
        [Fact]
        public void UpdateInexistentTourneyTest()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var tourney = new TourneyEntity() { Name = "Wimbledon", Country = "England", playerId = 2, Id = 16 };
            var res = _libraryRepository.UpdateTourney(tourney);
            Assert.Null(res);
        }
        [Fact]
        public void VerifyNationality()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var res = _libraryRepository.VerifyNationality("spanish");
            Assert.True(res);
        }
        [Fact]
        public void VerifyInexistentNationality()
        {
            ILibraryRepository _libraryRepository = new LibraryRepository();
            var res = _libraryRepository.VerifyNationality("Bolivian");
            Assert.False(res);
        }
    }
}
