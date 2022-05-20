using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Data.Entities;
using TenistasAPI.Data.Repository;
using TenistasAPI.Exceptions;
using TenistasAPI.Models;

namespace TenistasAPI.Services
{
    public class TennisPlayersService : ITennisPlayersService
    {
        ILibraryRepository _libraryRepository;
        private IMapper _mapper;
        private HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "currentranking",
            "nationality"
        };
        private HashSet<string> allowedParameters = new HashSet<string>()
        {
            "careertitles",
            "grandslams",
        };
        public TennisPlayersService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }
        public TennisPlayerModel CreateTennisPlayer(TennisPlayerModel tennisPlayer)
        {
            var tennisPlayerEntity = _mapper.Map<TennisPlayerEntity>(tennisPlayer);
            var returnedTennisPlayer = _libraryRepository.CreateTennisPlayer(tennisPlayerEntity);
            return _mapper.Map <TennisPlayerModel> (returnedTennisPlayer);
        }

        public bool DeleteTennisPlayer(int playerId)
        {
            GetTennisPlayer(playerId);
            return _libraryRepository.DeleteTennisPlayer(playerId);
        }

        public IEnumerable<TennisPlayerModel> GetPlayerWithSameResults(int playerId, string searchBy)
        {
            GetTennisPlayer(playerId);
            if (!allowedParameters.Contains(searchBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field: {searchBy} is not supported, please use one of these {string.Join(",", allowedParameters)}");
            }
            return _mapper.Map<IEnumerable<TennisPlayerModel>>(_libraryRepository.GetPlayerWithSameResults(playerId, searchBy));
        }

        public TennisPlayerModel GetTennisPlayer(int playerId)
        {
           var tennisPlayer= _libraryRepository.GetTennisPlayer(playerId);
            if(tennisPlayer==null)
            {
                throw new BadRequestOperationException($"The tennis player with id:{playerId} does not exist");
            }
            return _mapper.Map<TennisPlayerModel>(tennisPlayer);

        }

        public IEnumerable<TennisPlayerModel> GetTennisPlayers(string orderBy)
        {
            if (!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field: {orderBy} is not supported, please use one of these {string.Join(",", allowedOrderByParameters)}");
            }
            return _mapper.Map<IEnumerable<TennisPlayerModel>> (_libraryRepository.GetTennisPlayers(orderBy));
        }

        public IEnumerable<TennisPlayerModel> GetTop10(string nationality)
        {
            if(nationality == "all")
                return _mapper.Map<IEnumerable<TennisPlayerModel>>(_libraryRepository.GetTop10(nationality));
            if (_libraryRepository.VerifyNationality(nationality)==false)
            {
                throw new BadRequestOperationException($"none of the players has the nationality: {nationality} (all letter must be in lower case) ");
            }
            return _mapper.Map<IEnumerable<TennisPlayerModel>>(_libraryRepository.GetTop10(nationality));
        }

        public bool UpdateRankings(int playerId, int newRanking)
        {
            if (newRanking <= 0)
                throw new BadRequestOperationException($"Cant put a ranking 0 or a ranking under 0");
            GetTennisPlayer(playerId);
            return _libraryRepository.UpdateRankings(playerId, newRanking);
        }

        public TennisPlayerModel UpdateTennisPlayer(int playerId,TennisPlayerModel tennisPlayer)
        {
            GetTennisPlayer(playerId);
            tennisPlayer.Id = playerId;
            _libraryRepository.UpdateTennisPlayer(_mapper.Map<TennisPlayerEntity>(tennisPlayer));
            return tennisPlayer;
        }
    }
}
