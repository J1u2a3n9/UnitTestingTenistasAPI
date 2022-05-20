using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenistasAPI.Exceptions;
using TenistasAPI.Models;
using TenistasAPI.Services;

namespace TenistasAPI.Controllers
{
    [Route("api/[controller]")]
    public class TennisPlayersController : ControllerBase
    {
        private ITennisPlayersService _tennisPlayerService;
        public TennisPlayersController(ITennisPlayersService tennisPlayersService)
        {
            _tennisPlayerService = tennisPlayersService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TennisPlayerModel>> GetTennisPlayers(string orderBy = "Id")
        {
            try
            {
                return Ok(_tennisPlayerService.GetTennisPlayers(orderBy));
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
        [HttpGet("{playerId:int}", Name = "GetTennisPlayer")]
        public ActionResult<TennisPlayerModel> GetTennisPlayer(int playerId)
        {
            try
            {
                return Ok(_tennisPlayerService.GetTennisPlayer(playerId));
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
        public ActionResult<TennisPlayerModel> CreateTennisPlayer([FromBody] TennisPlayerModel tennisPlayer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var url = HttpContext.Request.Host;
                var newPlayer = _tennisPlayerService.CreateTennisPlayer(tennisPlayer);
                return CreatedAtRoute("GetTennisPlayer", new { playerId = newPlayer.Id }, newPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpDelete("{playerId:int}")]
        public ActionResult<bool> DeleteTennisPlayer(int playerId)
        {
            try
            {
                return Ok(_tennisPlayerService.DeleteTennisPlayer(playerId));
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
        [HttpPut("{playerId:int}")]
        public IActionResult UpdateTennisPlayer(int playerId, [FromBody] TennisPlayerModel tennisPlayer)
        {
            try
            {
                return Ok(_tennisPlayerService.UpdateTennisPlayer(playerId, tennisPlayer));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpGet("Top10")]
        public ActionResult<IEnumerable<TennisPlayerModel>> GetTop10(string nationality="all")
        {
            try
            {
                return Ok(_tennisPlayerService.GetTop10(nationality));
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
        [HttpGet("PlayersWithSameResults/{playerId:int}")]
        public ActionResult<IEnumerable<TennisPlayerModel>>GetPlayerWithSameResults(int playerId,string searchBy="CareerTitles")
        {
            try
            {
                return Ok(_tennisPlayerService.GetPlayerWithSameResults( playerId, searchBy));
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
        [HttpPut("{playerId:int}/Rankings")]
        public IActionResult UpdateRankings(int playerId,int newRanking=0 )
        {
            try
            {
                return Ok(_tennisPlayerService.UpdateRankings(playerId, newRanking));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
