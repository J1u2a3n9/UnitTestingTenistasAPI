using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Data.Entities;

namespace TenistasAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        TennisPlayerEntity GetTennisPlayer(int playerId);
        IEnumerable<TennisPlayerEntity> GetTennisPlayers(string orderBy);
        IEnumerable<TennisPlayerEntity> GetTop10(string nationality);
        IEnumerable<TennisPlayerEntity> GetPlayerWithSameResults(int playerId, string searchBy);

        TennisPlayerEntity CreateTennisPlayer(TennisPlayerEntity tennisPlayer);
        bool DeleteTennisPlayer(int playerId);
        bool UpdateTennisPlayer(TennisPlayerEntity tennisPlayer);
        bool VerifyNationality(string nationality);
        TourneyEntity GetTourney(int tourneyId);
        IEnumerable<TourneyEntity> GetTourneys(int playerId);
        TourneyEntity CreateTourney(TourneyEntity tourney);
        bool DeleteTourney(int tourneyId);
        TourneyEntity UpdateTourney(TourneyEntity tourney);
        bool UpdateRankings(int playerId,int newRanking);
    }
}
