using AutoFixture;
using DroneManagement.Controllers;
using DroneManagement.Models;
using DroneManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManagement.Tests
{
    public class ServiceControllerTests
    {
        public Mock<IServiceRepository> _serviceRepository;
        public Fixture _fixture;
        public ServiceControllerTests()
        {
            _serviceRepository = new Mock<IServiceRepository>();
            _fixture = new Fixture();
        }
        [Fact]
        public async Task Get_ServiceIndex_ReturnsOk()
        {
            var serviceList = _fixture.CreateMany<Service>(3).ToList();
            _serviceRepository.Setup(repo => repo.Index()).Returns(serviceList);

            ServiceController serviceController = new(_serviceRepository.Object);
            var result = await serviceController.Index();
            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Get_Service_ReturnsOk()
        {
            var service = _fixture.Create<Service>();
            _serviceRepository.Setup(repo => repo.GetService(It.IsAny<int>())).Returns(service);

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Get(service.Id);
            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }
 
        [Fact]
        public async Task Get_BadService_Returns404()
        {
            _serviceRepository.Setup(repo => repo.GetService(It.IsAny<int>())).Throws(new Exception());

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Get(3);
            var obj = result as NotFoundResult;

            Assert.Equal(404, obj.StatusCode);
        }
        [Fact]
        public async Task Post_Service_ReturnsCreated()
        {
            var service = _fixture.Create<Service>();
            _serviceRepository.Setup(repo => repo.CreateService(It.IsAny<int>())).Returns(service);

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Create(1);
            var obj = result as CreatedResult;

            Assert.Equal(201, obj.StatusCode);
        }

        [Fact]
        public async Task Put_Service_ReturnsOk()
        {
            var service = _fixture.Create<Service>();
            _serviceRepository.Setup(repo => repo.UpdateService(It.IsAny<Service>())).Returns(service);

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Update(service);
            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);

        }


        [Fact]
        public async Task Delete_Service_ReturnsOk()
        {
            var service = _fixture.Create<Service>();
            _serviceRepository.Setup(repo => repo.DeleteService(service.Id)).Returns(true);

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Delete(service.Id);
            var obj = result as OkResult;

            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Delete_BadService_Returns404()
        {
            var service = _fixture.Create<Service>();
            _serviceRepository.Setup(repo => repo.DeleteService(service.Id + 1)).Returns(false);

            ServiceController serviceController = new(_serviceRepository.Object);

            var result = await serviceController.Delete(service.Id + 1);
            var obj = result as NotFoundResult;

            Assert.Equal(404, obj.StatusCode);

        }
    }
}

