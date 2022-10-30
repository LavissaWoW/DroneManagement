using System.Linq;
using DroneManagement.Controllers;
using DroneManagement.Services;
using DroneManagement.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AutoFixture;

namespace DroneManagement.Tests;

public class DroneControllerTest
{
    public Mock<IDroneRepository> _droneRepository;
    public Fixture _fixture;
    public DroneControllerTest()
    {
        _droneRepository = new Mock<IDroneRepository>();
        _fixture = new Fixture();
    }
    [Fact]
    public async Task Get_DroneIndex_ReturnsOk()
    {
        var droneList = _fixture.CreateMany<Drone>(3).ToList();
        _droneRepository.Setup(repo => repo.GetDrones()).Returns(droneList);

        DroneManagementController droneManagementController = new(_droneRepository.Object);
        var result = await droneManagementController.Index();
        var obj = result as ObjectResult;

        Assert.Equal(200, obj.StatusCode);
    }

    [Fact]
    public async Task Get_Drone_ReturnsOk()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.GetDrone(It.IsAny<int>())).Returns(drone);

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Get(drone.Id);
        var obj = result as ObjectResult;

        Assert.Equal(200, obj.StatusCode);
    }

    [Fact]
    public async Task Get_BadDrone_Returns404()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.GetDrone(It.IsAny<int>())).Throws(new Exception());

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Get(3);
        var obj = result as NotFoundResult;

        Assert.Equal(404, obj.StatusCode);
    }

    [Fact]
    public async Task Post_Drone_ReturnsCreated()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.CreateDrone()).Returns(drone);

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Create();
        var obj = result as CreatedResult;

        Assert.Equal(201, obj.StatusCode);
    }

    [Fact]
    public async Task Put_Drone_ReturnsOk()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.UpdateDrone(It.IsAny<Drone>())).Returns(drone);

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Update(drone);
        var obj = result as ObjectResult;

        Assert.Equal(200, obj.StatusCode);

    }

    [Fact]
    public async Task Delete_Drone_ReturnsOk()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.DeleteDrone(drone.Id)).Returns(true);

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Delete(drone.Id);
        var obj = result as OkResult;

        Assert.Equal(200, obj.StatusCode);

    }

    [Fact]
    public async Task Delete_BadDrone_Returns404()
    {
        var drone = _fixture.Create<Drone>();
        _droneRepository.Setup(repo => repo.DeleteDrone(drone.Id + 1)).Returns(false);

        DroneManagementController droneManagementController = new(_droneRepository.Object);

        var result = await droneManagementController.Delete(drone.Id + 1);
        var obj = result as NotFoundResult;

        Assert.Equal(404, obj.StatusCode);

    }
}