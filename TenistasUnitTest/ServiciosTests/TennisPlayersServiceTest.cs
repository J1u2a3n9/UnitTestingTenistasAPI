using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TenistasAPI.Data.Entities;
using TenistasAPI.Data.Repository;
using TenistasAPI.Exceptions;
using TenistasAPI.Models;
using TenistasAPI.Services;
using Xunit;

namespace TenistasUnitTest.ControllerTests
{
    [ExcludeFromCodeCoverage]

    public class TennisPlayersServiceTest
    {
        [Fact]
        public void CreateTennisPlayer()
        {
            var mapperMock = new Mock<IMapper>();
            var mock = new Mock<ILibraryRepository>();
            var service = new TennisPlayersService(mock.Object, mapperMock.Object);
            Assert.IsType<TennisPlayersService>(service);
        }
        [Fact]
        public void CreateTennisPlayerFromService()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TennisPlayerEntity>(TennisPlayer))
                .Returns(TennisPlayerEntity)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            repoMock.Setup(repo => repo.CreateTennisPlayer(TennisPlayerEntity))
                .Returns(TennisPlayerEntity)
                .Verifiable();

            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.CreateTennisPlayer(TennisPlayer);
            Assert.IsType<TennisPlayerModel>(result);
        }
        [Fact]
        public void DeleteTennisPlayer()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };



            mapperMock.Setup(mapper => mapper.Map<TennisPlayerEntity>(TennisPlayer))
                .Returns(TennisPlayerEntity)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();

            repoMock.Setup(repo => repo.DeleteTennisPlayer(1))
                .Returns(validSaveElement())
                .Verifiable();

            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.DeleteTennisPlayer(1);
            Assert.IsType<bool>(result);

        }
        [Fact]
        public void GetPlayerWithSameResults()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetPlayerWithSameResults(1, "careertitles"))
               .Returns(getOkResultFromService)
               .Verifiable();



            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetPlayerWithSameResults(1, "careertitles");
            Assert.IsType<List<TennisPlayerModel>>(result);

        }
        [Fact]
        public void GetPlayerWithSameResultsBadRequest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetPlayerWithSameResults(1, "bug.."))
               .Returns(getOkResultFromService)
               .Verifiable();



            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.GetPlayerWithSameResults(1, "bug.."); return System.Threading.Tasks.Task.CompletedTask; });

        }
        [Fact]
        public void GetTennisPlayer()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTennisPlayer(1);
            Assert.IsType<TennisPlayerModel>(result);
        }
        [Fact]
        public void GetTennisPlayerBadRequest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            TennisPlayerEntity TennisPlayerEntity = null ;
            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(-1)   )
               .Returns(TennisPlayerEntity)
               .Verifiable();

            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);

            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.GetTennisPlayer(-1); return System.Threading.Tasks.Task.CompletedTask; });
        }
        [Fact]
        public void GetTennisPlayers()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            repoMock.Setup(repo => repo.GetTennisPlayers("id"))
               .Returns(getOkResultFromService)
               .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();



            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTennisPlayers("id");
            Assert.IsType<List<TennisPlayerModel>>(result);

        }
        [Fact]
        public void GetTennisPlayersBadRequest() 
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.GetTennisPlayers("bug"); return System.Threading.Tasks.Task.CompletedTask; });

        }
        [Fact]
        public void GetTop10toAll()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTop10("all");
            Assert.IsType<List<TennisPlayerModel>>(result);
        }
        [Fact]
        public void GetTop10toNacionalityOther()
        { 
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();
            //playersEntity.Add(new TennisPlayerEntity() { Id=1,FullName="Carlos",Nationality="Spain"});

            repoMock.Setup(repo => repo.VerifyNationality("Spain"))
               .Returns(validSaveElement)
               .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTop10("Spain");
            Assert.IsType<List<TennisPlayerModel>>(result);
        }
        [Fact]

        public void GetTop10toBadRequest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var playersEntity = new List<TennisPlayerEntity>();

            repoMock.Setup(repo => repo.VerifyNationality("Spain"))
               .Returns(invalidSaveElement)
               .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TennisPlayerModel>>(playersEntity))
               .Returns(new List<TennisPlayerModel>())
               .Verifiable();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTop10("Spain");
            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.GetTop10("bug"); return System.Threading.Tasks.Task.CompletedTask; });
        }

        [Fact]
        public void UpdateRankings()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };



            mapperMock.Setup(mapper => mapper.Map<TennisPlayerEntity>(TennisPlayer))
                .Returns(TennisPlayerEntity)
                .Verifiable();

            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();

            repoMock.Setup(repo => repo.UpdateRankings(1,1))
                .Returns(validSaveElement())
                .Verifiable();

            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.UpdateRankings(1,1);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void UpdateRankingsBadRequest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };

            mapperMock.Setup(mapper => mapper.Map<TennisPlayerModel>(TennisPlayerEntity))
                .Returns(TennisPlayer)
                .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();

            repoMock.Setup(repo => repo.UpdateRankings(1, 1))
                .Returns(invalidSaveElement())
                .Verifiable();

            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.UpdateRankings(0,0); return System.Threading.Tasks.Task.CompletedTask; });

        }

        [Fact]
        public void UpdateTennisPlayer()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var TennisPlayer = new TennisPlayerModel() { Id = 1, Name = "Koller" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };

            mapperMock.Setup(mapper => mapper.Map<TennisPlayerEntity>(TennisPlayer))
                .Returns(TennisPlayerEntity)
                .Verifiable();
            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.UpdateTennisPlayer(TennisPlayerEntity))
                .Returns(validSaveElement())
                .Verifiable();
            var servicio = new TennisPlayersService(repoMock.Object, mapperMock.Object);
            var result = servicio.UpdateTennisPlayer(1, TennisPlayer);
            Assert.IsType<TennisPlayerModel>(result);
        }
        public bool validSaveElement(){ return true; }
        public bool invalidSaveElement(){ return true; }
        public IEnumerable<TennisPlayerEntity> getOkResultFromService(){ return new List<TennisPlayerEntity>(); }
    }
}
