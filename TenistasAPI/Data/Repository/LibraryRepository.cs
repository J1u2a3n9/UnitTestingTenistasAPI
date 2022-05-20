using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Data.Entities;

namespace TenistasAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<TourneyEntity> tourneys = new List<TourneyEntity>
        {
            new TourneyEntity(){Id=1,Name="RolandGarros",Country="France",playerId=1 },
            new TourneyEntity(){Id=2,Name="RolandGarros",Country="bol",playerId=1 },
            new TourneyEntity(){Id=3,Name="RolandGarros",Country="sur",playerId=2 },
            new TourneyEntity(){Id=4,Name="RolandGarros",Country="F",playerId=2 },
            new TourneyEntity(){Id=5,Name="RolandGarros",Country="ger",playerId=3 },
            new TourneyEntity(){Id=6,Name="RolandGarros",Country="por",playerId=3 },
            new TourneyEntity(){Id=7,Name="RolandGarros",Country="bar",playerId=1 },
        };
        private List<TennisPlayerEntity> tennisPlayers = new List<TennisPlayerEntity>
        {
            new TennisPlayerEntity(){ Id = 1, FullName = "Rafael Nadal", Nationality ="Spanish", Birthdate = new DateTime(1993,6,3), Ranking=2,BestRanking=1,GrandSlamTitles=19,TotalTitles=85 },
            new TennisPlayerEntity(){ Id = 2, FullName = "Roger Federer", Nationality ="Swiss", Birthdate = new DateTime(1981,8,8), Ranking=4,BestRanking=1,GrandSlamTitles=20,TotalTitles=103},
            new TennisPlayerEntity(){Id=3,FullName= "Novak Djokovic",Nationality="Serbian",Ranking=1,BestRanking=1,GrandSlamTitles= 17,TotalTitles= 81,Birthdate = new DateTime(1987, 5, 22) },
            new TennisPlayerEntity(){Id=4,FullName= "Pete Sampras",Nationality="American",Ranking=null,BestRanking=1,GrandSlamTitles= 15,TotalTitles= 64,Birthdate = new DateTime(1971, 8, 12) },
            new TennisPlayerEntity(){Id=5,FullName= "Andy Murray",Nationality="British",Ranking=129,BestRanking=1,GrandSlamTitles= 3,TotalTitles= 46,Birthdate = new DateTime(1987, 5, 15) },
            new TennisPlayerEntity(){Id=6,FullName="Dominic Thiem", Nationality="Austrian",Ranking=3,BestRanking=3,TotalTitles=18,Birthdate=new DateTime(1993,9,3),GrandSlamTitles=1},
            new TennisPlayerEntity(){Id=7,FullName="Andy Roddick", Nationality="American",Ranking=null,BestRanking=1,TotalTitles=32,Birthdate=new DateTime(1982,8,30),GrandSlamTitles=1},
            new TennisPlayerEntity(){Id=8,FullName="Kei Nishikori", Nationality="Japanese",Ranking=35,BestRanking=4,TotalTitles=12,Birthdate=new DateTime(1989,12,29),GrandSlamTitles=0},
            new TennisPlayerEntity(){Id=9,FullName="Jo-Wilfried Tsonga", Nationality="French",Ranking=49 ,BestRanking=5,TotalTitles=18,Birthdate=new DateTime(1985,8,30),GrandSlamTitles=0},
            new TennisPlayerEntity(){Id=10,FullName="Andre Agassi", Nationality="American",Ranking=null,BestRanking=1,TotalTitles=60 ,Birthdate=new DateTime(1970 ,4,29),GrandSlamTitles=8},
            new TennisPlayerEntity(){Id=11,FullName="Juan Martín del Potro", Nationality="Argentinian",Ranking=139,BestRanking=3,TotalTitles=22 ,Birthdate=new DateTime(1988,8,23),GrandSlamTitles=1},
            new TennisPlayerEntity(){Id=12,FullName="Alexander Zverev", Nationality="German",Ranking=7,BestRanking=3,TotalTitles=11 ,Birthdate=new DateTime(1997,4,20),GrandSlamTitles=1},
            new TennisPlayerEntity(){Id=13,FullName="Roberto Bautista Agut", Nationality="Spanish",Ranking=9,BestRanking=9,TotalTitles=9 ,Birthdate=new DateTime(1988,4,20),GrandSlamTitles=0 },
            new TennisPlayerEntity(){Id=14,FullName="Bernardo  Agut", Nationality="Spanish",Ranking=15,BestRanking=12,TotalTitles=9 ,Birthdate=new DateTime(1989,4,20),GrandSlamTitles=0 }
        };

        public TennisPlayerEntity CreateTennisPlayer(TennisPlayerEntity tennisPlayer)
        {
            int newId;
            if (tennisPlayers.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = tennisPlayers.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }

            tennisPlayer.Id = newId;

            tennisPlayers.Add(tennisPlayer);
            return tennisPlayer;
        }

        public TourneyEntity CreateTourney(TourneyEntity tourney)
        {
            int newId;
            if (tennisPlayers.Count == 0)
            {
                newId = 1;
            }
            else
            {
                newId = tourneys.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }

            tourney.Id = newId;

            tourneys.Add(tourney);
            return tourney;
        }

        public bool DeleteTennisPlayer(int playerId)
        {
            var playerToDelete = GetTennisPlayer(playerId);
            tennisPlayers.Remove(playerToDelete);
            return true;
        }

        public bool DeleteTourney(int tourneyId)
        {
            var tourney = GetTourney(tourneyId);
            tourneys.Remove(tourney);
            return true;
        }

        public IEnumerable<TennisPlayerEntity> GetPlayerWithSameResults(int playerId, string searchBy)
        {
            var player =GetTennisPlayer(playerId);
            switch (searchBy)
            {
                case "careertitles":
                    return tennisPlayers.Where(p => p.TotalTitles == player.TotalTitles);
                case "grandslams":
                    return tennisPlayers.Where(p => p.GrandSlamTitles == player.GrandSlamTitles);
                default:
                    return tennisPlayers.Where(p => p.GrandSlamTitles == player.GrandSlamTitles);
            }
           
        }

        public TennisPlayerEntity GetTennisPlayer(int playerId)
        {
            return tennisPlayers.FirstOrDefault(c => c.Id == playerId);
        }

        public IEnumerable<TennisPlayerEntity> GetTennisPlayers(string orderBy)
        {
            foreach(var player in tennisPlayers)
            {
                player.Tourneys = tourneys.Where(t => t.playerId == player.Id);
            }
            return tennisPlayers;
          
        }

        public IEnumerable<TennisPlayerEntity> GetTop10(string nationality)
        {

            var orderedByRanking = GetTennisPlayers("currentranking");
            if(nationality == "all")
                return orderedByRanking.Where(p => p.Ranking != null&&p.Ranking<=10).Take(10);
            else
                return orderedByRanking.Where(p => p.Ranking != null && p.Nationality.ToLower()== nationality).Take(10);

        }

        public TourneyEntity GetTourney(int tourneyId)
        {
            return tourneys.FirstOrDefault(c => c.Id == tourneyId);
        }

        public IEnumerable<TourneyEntity> GetTourneys(int playerId)
        {
            return tourneys.Where(t => t.playerId == playerId);
        }

        public bool UpdateRankings(int playerId,int newRanking)
        {
            
            var playerToUpdate =GetTennisPlayer(playerId);
            var playersAbove = tennisPlayers.Where(t => t.Ranking < playerToUpdate.Ranking);
            var playerList = playersAbove.Where(t => t.Ranking >= newRanking && t.Ranking != null);
            foreach (var player in playerList)
            {
                player.Ranking++;
            }
            playerToUpdate.Ranking = newRanking;
            return true;
        }

        public bool UpdateTennisPlayer(TennisPlayerEntity tennisPlayer)
        {
            var playerToUpdate = GetTennisPlayer(tennisPlayer.Id);
            playerToUpdate.Nationality = tennisPlayer.Nationality ?? playerToUpdate.Nationality;
            playerToUpdate.FullName = tennisPlayer.FullName ?? playerToUpdate.FullName;
            playerToUpdate.GrandSlamTitles = tennisPlayer.GrandSlamTitles ?? playerToUpdate.GrandSlamTitles;
            playerToUpdate.TotalTitles = tennisPlayer.TotalTitles ?? playerToUpdate.TotalTitles;
            playerToUpdate.BestRanking = tennisPlayer.BestRanking ?? playerToUpdate.BestRanking;
            playerToUpdate.Birthdate = tennisPlayer.Birthdate ?? playerToUpdate.Birthdate;
            playerToUpdate.Ranking = tennisPlayer.Ranking ?? playerToUpdate.Ranking;

            return true;
        }

        public TourneyEntity UpdateTourney(TourneyEntity tourney)
        {
            var tourneyToUpdate = GetTourney(tourney.Id);
            tourneyToUpdate.Country = tourney.Country ?? tourneyToUpdate.Country;
            tourneyToUpdate.Name = tourney.Name ?? tourneyToUpdate.Name;
            tourneyToUpdate.playerId = tourney.playerId ?? tourneyToUpdate.playerId;
            return tourneyToUpdate;
        }

        public bool VerifyNationality(string nationality)
        {
            if (tennisPlayers.FirstOrDefault(p => p.Nationality.ToLower() == nationality) == null)
                return false;
            else
                return true;
        }
    }
}
