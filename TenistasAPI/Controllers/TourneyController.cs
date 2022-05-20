using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenistasAPI.Exceptions;
using TenistasAPI.Models;
using TenistasAPI.Services;

namespace TenistasAPI.Controllers
{
    [Route("api/TennisPlayers/{tennisPlayerId}/[controller]")]
    public class TourneyController : ControllerBase
    {
        private ITourneyService tourneyService;
        public TourneyController(ITourneyService tourneyService)
        {
            this.tourneyService = tourneyService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TourneyModel>> GetTourneys(int tennisPlayerId)
        {
            try
            {
                return Ok(tourneyService.GetTourneys(tennisPlayerId));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpGet("{tourneyId:int}", Name = "GetTourney")]
        public ActionResult<TourneyModel> GetTourney(int tennisPlayerId,int tourneyId)
        {
            try
            {
                return Ok(tourneyService.GetTourney(tourneyId, tennisPlayerId));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<TourneyModel> CreateTourney(int tennisPlayerId,[FromBody] TourneyModel tourney)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var url = HttpContext.Request.Host;
                var newTourney = tourneyService.CreateTourney(tennisPlayerId, tourney);
                return CreatedAtRoute("GetTennisPlayer", new { playerId = newTourney.Id }, newTourney);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpDelete("{tourneyId:int}")]
        public ActionResult<bool> DeleteTennisPlayer(int tennisPlayerId,int tourneyId)
        {
            try
            {
                return Ok(tourneyService.DeleteTourney(tourneyId,tennisPlayerId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{tourneyId:int}")]
        public IActionResult UpdateTennisPlayer(int tourneyId, [FromBody] TourneyModel tourney,int tennisPlayerId)
        {
            try
            {
                return Ok(tourneyService.UpdateTourney(tourneyId,tennisPlayerId,tourney));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
     
    }
}
