using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TenistasAPI.Controllers;
using TenistasAPI.Data.Repository;
using TenistasAPI.Models;
using TenistasAPI.Services;
using Xunit;
namespace TenistasUnitTest.ControllerTests
{
    public class TourneyControllerTest
    {
        [Fact]
        public void GetTourneys()
        {

            Mock<ITourneyService> _tourneyService = new Mock<ITourneyService>();
            TourneyController _tourneyController = new TourneyController(_tourneyService.Object);
            int id = 1;
            var method = _tourneyController.GetTourneys(id);
            Assert.IsType<ActionResult<IEnumerable<TourneyModel>>>(method);
        }
        [Fact]
        public void GetTourney()
        {

            Mock<ITourneyService> _tourneyService = new Mock<ITourneyService>();
            TourneyController _tourneyController = new TourneyController(_tourneyService.Object);
            int id = 1;
            int tourneyId= 1;
            var method = _tourneyController.GetTourney(id,tourneyId);
            Assert.IsType<ActionResult<TourneyModel>>(method);
        }
        [Fact]
        public void CreateTourney()
        {
            Mock<ITourneyService> _tourneyService = new Mock<ITourneyService>();
            TourneyController _tourneyController = new TourneyController(_tourneyService.Object);
            int id = 1;
            var tourney = new TourneyModel();
            var method = _tourneyController.CreateTourney(id, tourney);
            Assert.IsType<ActionResult<TourneyModel>>(method);
        }
        [Fact]
        public void DeleteTennisPlayer()
        {
            Mock<ITourneyService> _tourneyService = new Mock<ITourneyService>();
            TourneyController _tourneyController = new TourneyController(_tourneyService.Object);
            int id = 1;
            int tourneyId = 3;
            var method = _tourneyController.DeleteTennisPlayer(id,tourneyId);
            Assert.IsType<ActionResult<bool>>(method);
        }
        [Fact]
        public void UpdateTennisPlayer()
        {
            Mock<ITourneyService> _tourneyService = new Mock<ITourneyService>();
            TourneyController _tourneyController = new TourneyController(_tourneyService.Object);
            int id = 1;
            int tourneyId = 3;
            var tourney = new TourneyModel();
            var method = _tourneyController.UpdateTennisPlayer(tourneyId,tourney,id);
            Assert.IsType<OkObjectResult>(method);
        }
    }
}
