using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Data.Entities;
using TenistasAPI.Models;

namespace TenistasAPI.Services
{
    public interface ITennisPlayersService
    {
        TennisPlayerModel GetTennisPlayer(int playerId);
        IEnumerable<TennisPlayerModel> GetTennisPlayers(string orderBy);

        TennisPlayerModel CreateTennisPlayer(TennisPlayerModel tennisPlayer);
        bool DeleteTennisPlayer(int playerId);
        TennisPlayerModel UpdateTennisPlayer(int playerId,TennisPlayerModel tennisPlayer);
        IEnumerable<TennisPlayerModel> GetTop10(string nationality);
        IEnumerable<TennisPlayerModel>GetPlayerWithSameResults(int playerId, string searchBy);
        bool UpdateRankings(int playerId, int newRanking);
    }
}
