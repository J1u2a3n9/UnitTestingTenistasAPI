using AutoMapper;
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
    public class TourneyService : ITourneyService
    {
        private ILibraryRepository _libraryRepository;
        private IMapper _mapper;
        public TourneyService(ILibraryRepository libraryRepository,IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public TourneyModel CreateTourney(int playerId,TourneyModel tourney)
        {
            ValidatePlayer(playerId);
            var player=_libraryRepository.GetTennisPlayer(playerId);
            tourney.playerId = playerId;
            var tourneyEntity = _mapper.Map<TourneyEntity>(tourney);     
            return _mapper.Map<TourneyModel>(_libraryRepository.CreateTourney(tourneyEntity)); 

        }

        public bool DeleteTourney(int tourneyId,int playerId)
        {
            var player = _libraryRepository.GetTennisPlayer(playerId);
            var tourney = GetTourney(tourneyId,playerId);
            if (player.Id!=tourney.playerId)
            {
                throw new BadRequestOperationException($"Cant erase a tourney from another player");
            }
            return _libraryRepository.DeleteTourney(tourneyId);
        }

        public TourneyModel GetTourney(int tourneyId,int playerId)
        {
            var player = _libraryRepository.GetTennisPlayer(playerId);
            var tourney = _libraryRepository.GetTourney(tourneyId);
            if (player == null)
                throw new NotFoundOperationException($"the player with id {playerId} does not exist");
            if (tourney==null)
                throw new NotFoundOperationException($"the tourney with id {tourneyId} does not exist");
            if (player.Id != tourney.playerId)
            {
                throw new BadRequestOperationException($"the player didnt play that tourney");
            }
            return _mapper.Map<TourneyModel>(tourney);
        }

        public IEnumerable<TourneyModel> GetTourneys(int playerId)
        {
            var player = _libraryRepository.GetTennisPlayer(playerId);
            if (player == null)
                throw new NotFoundOperationException($"the player with id {playerId} does not exist");
            return _mapper.Map<IEnumerable<TourneyModel>>(_libraryRepository.GetTourneys(playerId));
        }

        public TourneyModel UpdateTourney(int tourneyId,int playerId, TourneyModel tourney)
        {
            GetTourney(tourneyId, playerId);
            tourney.Id = tourneyId;
            tourney.playerId = playerId;
            var tourneyEntity = _mapper.Map<TourneyEntity>(tourney);
            return _mapper.Map<TourneyModel>(_libraryRepository.UpdateTourney(tourneyEntity));
        }

        public void ValidatePlayer(int playerId)
        {
            var player = _libraryRepository.GetTennisPlayer(playerId);
            if (player == null)
                throw new NotFoundOperationException($"the player with id {playerId} does not exist");
        }
    }
}
