using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Data.Entities;
using TenistasAPI.Models;

namespace TenistasAPI.Services
{
    public interface ITourneyService
    {
        TourneyModel GetTourney(int tourneyId,int playerId);
        IEnumerable<TourneyModel> GetTourneys(int playerId);

        TourneyModel CreateTourney(int playerId,TourneyModel tourney);
        bool DeleteTourney(int tourneyId,int playerId);
        TourneyModel UpdateTourney(int tourneyId,int playerId,TourneyModel tourney);
        void ValidatePlayer(int playerId);

    }
}
