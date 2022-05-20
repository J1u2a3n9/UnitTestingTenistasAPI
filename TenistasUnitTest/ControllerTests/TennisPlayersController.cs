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

    public class TennisPlayersControllerTest
    {
        [Fact]
        public void GetTennisPlayer()
        {
            var _mapper = new Mock<IMapper>();
            var _libraryRepository = new Mock<ILibraryRepository>();
            var _tennisPlayersService = new Mock<ITennisPlayersService>(_libraryRepository, _mapper);
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            int id = 1;
            var method = _tennisPlayersController.GetTennisPlayer(id);
            Assert.IsType<ActionResult<TennisPlayerModel>>(method.Result);

        }

    }
   

}
