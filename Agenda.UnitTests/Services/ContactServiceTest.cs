using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Dtos;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Repository;
using Agenda.API.Services;
using Agenda.UnitTests.Fixtures;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace Agenda.UnitTests.Services
{
    public class ContactServiceTest
    {
        [Fact]
        public async Task CreateContact_OnSucces_ReturnsTrue()
        {
            // Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });

            var mapper = mockMapp.CreateMapper();
            mockContactRepository.Setup(service => service.CreateContact(ContactFixture.GetTestContact()));
            mockContactRepository.Setup(service => service.SaveChangesAsync()).ReturnsAsync(true);
            var contactService = new ContactService(mockContactRepository.Object, mapper);


            // Act
            var result = await contactService.CreateContact(ContactFixture.GetTestContactDto());

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task CreateContact_OnSucces_InvolkesSaveChangesAsyncRepositoryServiceExactlyOnce()
        {
            // Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });

            var mapper = mockMapp.CreateMapper();
            mockContactRepository.Setup(service => service.CreateContact(ContactFixture.GetTestContact()));
            mockContactRepository.Setup(service => service.SaveChangesAsync()).ReturnsAsync(true);
            var contactService = new ContactService(mockContactRepository.Object, mapper);


            // Act
            var result = await contactService.CreateContact(ContactFixture.GetTestContactDto());

            // Assert
            mockContactRepository.Verify(service => service.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateContact_OnFail_ReturnsFalse()
        {
            // Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });

            var mapper = mockMapp.CreateMapper();
            mockContactRepository.Setup(service => service.CreateContact(ContactFixture.GetTestContact()));
            mockContactRepository.Setup(service => service.SaveChangesAsync()).ReturnsAsync(false);
            var contactService = new ContactService(mockContactRepository.Object, mapper);


            // Act
            var result = await contactService.CreateContact(ContactFixture.GetTestContactDto());

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task GetAllContacts_OnSuccess_ReturnsListOfDtoContacts()
        {
            // Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });
            var mapper = mockMapp.CreateMapper();

            mockContactRepository.Setup(service => service.GetContacts()).ReturnsAsync(ContactFixture.GetListOfPureModelTestContacts());
            var contactService = new ContactService(mockContactRepository.Object, mapper);

            // Act
            var result = await contactService.GetAllContacts();

            // Assert
            result.Should().BeEquivalentTo(ContactFixture.GetListOfTestContacts());
        }

        [Fact]
        public async Task GetAllContacts_OnSuccess_InvolkesContactRepositoryExactlyOnce()
        {
            // Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });
            var mapper = mockMapp.CreateMapper();

            mockContactRepository.Setup(service => service.GetContacts()).ReturnsAsync(new List<Contact>());
            var contactService = new ContactService(mockContactRepository.Object, mapper);

            // Act
            var result = await contactService.GetAllContacts();

            // Assert
            mockContactRepository.Verify(service => service.GetContacts(), Times.Once());
        }
    }
}