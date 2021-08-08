using MeliChallenge.API.Controllers;
using MeliChallenge.API.DTOs;
using MeliChallenge.Domain;
using MeliChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Net;

namespace MeliChallenge.Test
{
    [TestFixture]
    public class StarshipInfoControllerTest
    {
        const string ERROR_MESSAGE = "No se ha podido determinar mensaje o posicion";

        [Test]
        public void Topsecret_WithValidInfo_ReturnSuccess()
        {
            //Arrange           

            var mockService = new Mock<IDecodeInfoService>();
            mockService.Setup(repo => repo.GetInformationAboutStarship(FakeData.GetMessagePositionInfoInputData()))
                .Returns(It.IsAny<Spaceship>);
            var controller = new StarshipInfoController(mockService.Object);

            // Act
            var result = controller.GetInfo(FakeData.GetValidMessageRequestInputData());

            // Assert
            Assert.IsNotNull(result.Result);
        }

        [Test]
        public void Topsecret_WithInvalidInfo_ReturnBadRequest()
        {
            //Arrange

            var mockService = new Mock<IDecodeInfoService>();
            mockService.Setup(repo => repo.GetInformationAboutStarship(FakeData.GetMessagePositionInfoInputData()))
                .Returns((Spaceship)null);
            var controller = new StarshipInfoController(mockService.Object);

            // Act
            var result = controller.GetInfo(FakeData.GetInvalidMessageRequestInputData());

            // Assert
            Assert.IsNotNull(result);           
        }




    }
}