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
    public class TourneyServiceTestTest
    {
        [Fact]
        public void CreateTourneyService()
        {
            var mapperMock = new Mock<IMapper>();
            var mock = new Mock<ILibraryRepository>();
            var service = new TourneyService(mock.Object, mapperMock.Object);
            Assert.IsType<TourneyService>(service);
        }
        [Fact]
        public void ValidatePlayerBadResquest()
        {
            var repomock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            TennisPlayerEntity TennisPlayerEntity = null;

            repomock.Setup(repo => repo.GetTennisPlayer(1))
                .Returns(TennisPlayerEntity)
                .Verifiable();
            var service = new TourneyService(repomock.Object, mapperMock.Object);
            Assert.ThrowsAsync<BadRequestOperationException>(() => { service.ValidatePlayer(1); return System.Threading.Tasks.Task.CompletedTask; });
        }


        [Fact]
         public void CreateTourneyServiceFromService()
         {
             var repoMock = new Mock<ILibraryRepository>();
             var mapperMock = new Mock<IMapper>();
             var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal" };
             var TourneyEntity = new TourneyEntity() { Id = 1, Name= "RolandGal" };
             var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TourneyEntity>(Tourney))
                 .Returns(TourneyEntity)
                 .Verifiable();

             mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                 .Returns(Tourney)
                 .Verifiable();

             repoMock.Setup(repo => repo.CreateTourney(TourneyEntity))
                 .Returns(TourneyEntity)
                 .Verifiable();
             repoMock.Setup(repo => repo.GetTennisPlayer(1))
                 .Returns(TennisPlayerEntity)
                 .Verifiable();
            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
             var result = servicio.CreateTourney(1,Tourney);
             Assert.IsType<TourneyModel>(result);
         }
        [Fact]
        public void DeleteTourney()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal", playerId = 1 };
            var TourneyEntity = new TourneyEntity() { Id = 1, Name = "RolandGal", playerId = 1 };

            var ListTourney = new List<TourneyEntity>();
            ListTourney.Add(TourneyEntity);
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };



            mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                .Returns(Tourney)
                .Verifiable();


            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetTourney(1))
               .Returns(TourneyEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.DeleteTourney(1))
                .Returns(validSaveElement())
                .Verifiable();



            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            var result = servicio.DeleteTourney(1, 1);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void GetTourneyBadRequestPlayerNull()
        {  
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal" , playerId = 2 };
            var TourneyEntity = new TourneyEntity() { Id = 1, Name = "RolandGal", playerId = 2 };
            TennisPlayerEntity TennisPlayerEntity = null;

            mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                .Returns(Tourney)
                .Verifiable();


            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetTourney(1))
               .Returns(TourneyEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.DeleteTourney(1))
                .Returns(validSaveElement())
                .Verifiable();
            


            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(() => { servicio.GetTourney(1,2); return System.Threading.Tasks.Task.CompletedTask; });
        }
        [Fact]
        public void GetTourneyBadRequestTourneyNull()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal", playerId = 2 };
            TourneyEntity TourneyEntity = null;
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                .Returns(Tourney)
                .Verifiable();


            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetTourney(1))
               .Returns(TourneyEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.DeleteTourney(1))
                .Returns(validSaveElement())
                .Verifiable();



            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(() => { servicio.GetTourney(1, 1); return System.Threading.Tasks.Task.CompletedTask; });
        }
        [Fact]
        public void GetTourneyBadRequestIdDiferentl() 
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal" };
            var TourneyEntity = new TourneyEntity() { Id = 1, Name = "RolandGal" };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };


            mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                .Returns(Tourney)
                .Verifiable();


            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetTourney(1))
               .Returns(TourneyEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.DeleteTourney(1))
                .Returns(validSaveElement())
                .Verifiable();



            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<BadRequestOperationException>(() => { servicio.GetTourney(1, 1); return System.Threading.Tasks.Task.CompletedTask; });
        }

        [Fact]
        public void GetTourneys()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal",playerId=1 };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };
            var TourneyEntity = new List<TourneyEntity>();

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TourneyModel>>(TourneyEntity))
               .Returns(new List<TourneyModel>())
               .Verifiable();

            repoMock.Setup(repo => repo.GetTourneys(1))
               .Returns(getOkResultFromService)
               .Verifiable();



            repoMock.Setup(repo => repo.GetTennisPlayer(1))
             .Returns(TennisPlayerEntity)
             .Verifiable();


            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            var result = servicio.GetTourneys(1);
            Assert.IsType<List<TourneyModel>>(result);

        }
        [Fact]
        public void GetTourneysBadRequest()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();
            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal" };
            var TourneyEntity = new TourneyEntity() { Id = 1, Name = "RolandGal" };
            TennisPlayerEntity TennisPlayerEntity =null;

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<TourneyModel>>(TourneyEntity))
               .Returns(new List<TourneyModel>())
               .Verifiable();


            repoMock.Setup(repo => repo.GetTourneys(1))
               .Returns(getOkResultFromService)
               .Verifiable();

            

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
             .Returns(TennisPlayerEntity)
             .Verifiable();


            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            Assert.ThrowsAsync<NotFoundOperationException>(() => { servicio.GetTourneys(1); return System.Threading.Tasks.Task.CompletedTask; });

        }

        [Fact] 
        public void UpdateTourney()
        {
            var repoMock = new Mock<ILibraryRepository>();
            var mapperMock = new Mock<IMapper>();

            var Tourney = new TourneyModel() { Id = 1, Name = "RolandGal", playerId = 1 };
            var TourneyEntity = new TourneyEntity() { Id = 1, Name = "RolandGal", playerId = 1 };
            var TennisPlayerEntity = new TennisPlayerEntity() { Id = 1, FullName = "Koller" };

            mapperMock.Setup(mapper => mapper.Map<TourneyModel>(TourneyEntity))
                .Returns(Tourney)
                .Verifiable();
            mapperMock.Setup(mapper => mapper.Map<TourneyEntity>(Tourney))
                .Returns(TourneyEntity)
                .Verifiable();

            repoMock.Setup(repo => repo.GetTennisPlayer(1))
               .Returns(TennisPlayerEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.GetTourney(1))
               .Returns(TourneyEntity)
               .Verifiable();
            repoMock.Setup(repo => repo.DeleteTourney(1))
                .Returns(validSaveElement())
                .Verifiable();
            repoMock.Setup(repo => repo.UpdateTourney(TourneyEntity))
             .Returns(TourneyEntity)
             .Verifiable();


            var servicio = new TourneyService(repoMock.Object, mapperMock.Object);
            var result = servicio.UpdateTourney(1,1, Tourney);
            Assert.IsType<TourneyModel>(result);
        }
        public bool validSaveElement() { return true; }
        public bool invalidSaveElement() { return true; }
        public IEnumerable<TourneyEntity> getOkResultFromService() { return new List<TourneyEntity>(); }

    }
}
