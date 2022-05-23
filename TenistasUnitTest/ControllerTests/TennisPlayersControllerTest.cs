using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using TenistasAPI.Controllers;
using TenistasAPI.Data.Repository;
using TenistasAPI.Exceptions;
using TenistasAPI.Models;
using TenistasAPI.Services;
using Xunit;

namespace TenistasUnitTest.ControllerTests
{
    [ExcludeFromCodeCoverage]

    public class TennisPlayersControllerTest
    {
        public TennisPlayerModel getHappyResultFromService()
        {
            var dateString = "06/11/1999 03:59:52 AM";
            DateTime birthdate = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            return new TennisPlayerModel
            {
                Id = 1000,
                Name = "Jose Perez",
                Nationality = "Peruano",
                CurrentRanking = 50,
                BestRanking = 50,
                GrandSlamTitles = 4,
                CareerTitles = 3,
                Birthdate = birthdate
            };
        }
        public Tuple<TennisPlayerModel,bool> getHappyResultFromServiceTuple()
        {
            var dateString = "06/11/1999 03:59:52 AM";
            DateTime birthdate = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            var model = new TennisPlayerModel
            {
                Id = 1000,
                Name = "Jose Perez",
                Nationality = "Peruano",
                CurrentRanking = 50,
                BestRanking = 50,
                GrandSlamTitles = 4,
                CareerTitles = 3,
                Birthdate = birthdate
            };
            bool verdad = true;
            Tuple<TennisPlayerModel, bool> tuple = new Tuple<TennisPlayerModel, bool>(model, verdad);
            return tuple;
        }



        [Fact]
        public void GetTennisPlayerTest()
        {
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            int id = 1;
            var method = _tennisPlayersController.GetTennisPlayer(id);
            Assert.IsType<ActionResult<TennisPlayerModel>>(method);

        }

        [Fact]
        public void GetTennisPlayersTest()
        {
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            var method = _tennisPlayersController.GetTennisPlayers();
            Assert.IsType<ActionResult<IEnumerable<TennisPlayerModel>>>(method);
        }

        [Fact]
        public void GetTennisPlayerBadRequestTest()
        {
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            var method = _tennisPlayersController.GetTennisPlayer(-1);
            Assert.IsNotType<BadRequestOperationException>(method);
        }

        [Fact]
        public void CreateTennisPlayerTest()
        {
            var mock = new Mock<ITennisPlayersService>();
            var controller = new TennisPlayersController(mock.Object);
            var dateString = "06/11/1999 03:59:52 AM";
            DateTime birthdate = DateTime.Parse(dateString,System.Globalization.CultureInfo.InvariantCulture);
            var tennisPlayer=new TennisPlayerModel
            {
                Id = 1000,
                Name = "Jose Perez",
                Nationality="Peruano",
                CurrentRanking=50,
                BestRanking=50,
                GrandSlamTitles=4,
                CareerTitles=3,
                Birthdate= birthdate
            };
            mock.Setup(repo => repo.CreateTennisPlayer(tennisPlayer))
                .Returns(getHappyResultFromService())
                .Verifiable();
            var result =controller.CreateTennisPlayer(tennisPlayer);
            Assert.IsType<ActionResult<TennisPlayerModel>>(result);
        }
        [Fact]
        public void DeleteTennisPlayerTest() 
        {
            var mock = new Mock<ITennisPlayersService>();
            var controller = new TennisPlayersController(mock.Object);
            int id = 6;
            mock.Setup(repo => repo.DeleteTennisPlayer(id))
                .Returns(true)
                .Verifiable();
            var result = controller.DeleteTennisPlayer(id);
            Assert.IsType<ActionResult<bool>>(result);

        }

        [Fact]
        public void UpdateTennisPlayerTest()
        {
            var mock = new Mock<ITennisPlayersService>();
            var controller = new TennisPlayersController(mock.Object);
            int id = 1000;
            var dateString = "06/11/2000 03:59:52 AM";
            DateTime birthdate = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            var tennisPlayerUpdate = new TennisPlayerModel
            {
                Id = 1000,
                Name = "Jose Perez",
                Nationality = "Peruano",
                CurrentRanking = 50,
                BestRanking = 50,
                GrandSlamTitles = 4,
                CareerTitles = 4,
                Birthdate = birthdate
            };
            mock.Setup(repo => repo.UpdateTennisPlayer(id, tennisPlayerUpdate))
                .Returns(getHappyResultFromService)
                .Verifiable();
            var result = controller.UpdateTennisPlayer(id, tennisPlayerUpdate);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTop10Test()
        {
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            var method = _tennisPlayersController.GetTop10();
            Assert.IsType<ActionResult<IEnumerable<TennisPlayerModel>>>(method);

        }

        [Fact]
        public void GetPlayerWithSameResultsTest()
        {
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            int id = 1;
            var method = _tennisPlayersController.GetPlayerWithSameResults(id);
            Assert.IsType<ActionResult<IEnumerable<TennisPlayerModel>>>(method);
        }

        [Fact]
        public void UpdateRankingsTest()
        {
            var mock = new Mock<ITennisPlayersService>();
            var controller = new TennisPlayersController(mock.Object);
            int id = 1000;
            int newRanking = 12;
            mock.Setup(repo => repo.UpdateRankings(id, newRanking))
                .Returns(getHappyResultFromServiceTuple().Item2)
                .Verifiable();
            var result = controller.UpdateRankings(id, newRanking);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);

        }
    }

}
