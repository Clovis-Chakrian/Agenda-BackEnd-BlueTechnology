using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Agenda.API.Controllers;
using Agenda.API.Models;
using Agenda.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Agenda.UnitTests.Controllers
{
    public class ContactControllerTest
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (OkObjectResult)await controller.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvolkesContactsServiceExactllyOnce()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            mockContactService.Verify(service => service.GetAllContacts(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfContacts()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>(){
                new Contact(){
                    Id = 1,
                    Name = "Clóvis",
                    LastName = "Chakrian",
                    Email = "clovischakrian@gmail.com",
                    Phone = "81985444683"
                }
            });
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().BeOfType<List<Contact>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_ReturnsStringWithDescritiveMessage()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().Be("Nenhum contato cadastrado ainda.");
        }

        [Fact]
        public async Task GetById_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetContactById(1)).ReturnsAsync(new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            });
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().BeOfType<Contact>();
        }

        [Fact]
        public async Task GetById_OnSuccess_InvolkesContactServiceExactlyOnce()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetContactById(1)).ReturnsAsync(new Contact());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            mockContactService.Verify(service => service.GetContactById(1), Times.Once());
        }

        [Fact]
        public async Task GetById_OnNoUserFound_ReturnsStatusCode404()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetContactById(1)).ReturnsAsync((Contact)null);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
            objectResult.Value.Should().Be("Não foi encontrado nenhum contato para o Id recebido.");
        }

        [Fact]
        public async Task Post_OnSuccess_ReturnsStatusCode201()
        {
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.CreateContact(contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Post(contact);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            var objResult = (CreatedResult)result;
            objResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Post_OnSuccess_InvolkesContactServiceExactlyOnce()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.CreateContact(contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Post(contact);

            // Assert
            mockContactService.Verify(service => service.CreateContact(contact), Times.Once());
        }

        [Fact]
        public async Task Post_OnSuccess_ReturnsReceivedData()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.CreateContact(contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Post(contact);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            var objResult = (CreatedResult)result;
            objResult.Value.Should().Be(contact);
        }

        [Fact]
        public async Task Post_OnFail_ReturnsBadRequest()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.CreateContact(contact)).ReturnsAsync(false);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Post(contact);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
            var objResult = (BadRequestResult)result;
            objResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Put_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.UpdateContact(1, contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (OkObjectResult)await controller.Update(1, contact);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Put_OnSuccess_InvolkesContactServiceExactlyOnce()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.UpdateContact(1, contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Update(1, contact);

            // Assert
            mockContactService.Verify(service => service.UpdateContact(1, contact), Times.Once());
        }

        [Fact]
        public async Task Put_OnSuccess_ReturnsContactUpdated()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.UpdateContact(1, contact)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Update(1, contact);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().Be(contact);
        }

        [Fact]
        public async Task Put_OnFail_ReturnsBadRequest()
        {
            // Arrange
            var contact = new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            };
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.UpdateContact(1, contact)).ReturnsAsync(false);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (BadRequestResult)await controller.Update(1, contact);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Delete_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.DeleteContact(id)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Delete(id);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_OnSuccess_InvolkesContactServiceExactlyOnce()
        {
            // Arrange
            int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.DeleteContact(id)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Delete(id);

            // Assert
            mockContactService.Verify(service => service.DeleteContact(id), Times.Once());
        }

        [Fact]
        public async Task Delete_OnSuccess_ReturnsDescritiveMessageWithTheContactIdDeleted()
        {
            // Arrange
            int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.DeleteContact(id)).ReturnsAsync(true);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (OkObjectResult)await controller.Delete(id);

            // Assert
            result.Value.Should().Be($"Usuário de id {id} foi deletado com sucesso.");
        }

        [Fact]
        public async Task Delete_OnFail_ReturnsBadRequest()
        {
            // Arrange
            int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.DeleteContact(id)).ReturnsAsync(false);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Delete(id);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var objResult = (BadRequestObjectResult)result;
            objResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Delete_OnFail_ReturnsReceivedIdToDeleteOnBodyMessage()
        {
            // Arrange
            int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.DeleteContact(id)).ReturnsAsync(false);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (BadRequestObjectResult)await controller.Delete(id);

            // Assert
            result.Value.Should().Be($"Não foi possível deletar o contato de id {id}. Tente novamente mais tarde!");

        }
    }
}