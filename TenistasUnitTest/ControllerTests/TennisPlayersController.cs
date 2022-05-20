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
            /*Mock<IMapper> _mapper = new Mock<IMapper>();
            Mock<ILibraryRepository> _libraryRepository = new Mock<ILibraryRepository>();*/
            Mock<ITennisPlayersService> _tennisPlayersService = new Mock<ITennisPlayersService>();
            TennisPlayersController _tennisPlayersController = new TennisPlayersController(_tennisPlayersService.Object);
            int id = 1;
            var method = _tennisPlayersController.GetTennisPlayer(id);
            Assert.IsType<ActionResult<TennisPlayerModel>>(method);

        }

    }
   

}
