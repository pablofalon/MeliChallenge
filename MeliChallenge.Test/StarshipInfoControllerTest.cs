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
    }
}