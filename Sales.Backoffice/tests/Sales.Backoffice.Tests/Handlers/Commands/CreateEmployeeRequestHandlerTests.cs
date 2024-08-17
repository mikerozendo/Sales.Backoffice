﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;
using Sales.Backoffice.Dto.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Tests.Handlers.Commands;

public class CreateEmployeeRequestHandlerTests
{
    private readonly ServiceProvider _serviceProvider;
    private readonly ILogger<CreateEmployeeRequestHandler> _logger;

    public CreateEmployeeRequestHandlerTests()
    {
        _serviceProvider = new Helpers().GetServiceProvider();
        var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger<CreateEmployeeRequestHandler>();
    }

    [Fact]
    public async Task Handle_DepartmentDoesNotExist_ReturnsUnprocessableEntity()
    {
        //Arrange 
        Department? department = null;
        var departmentRepositoryMock = new Mock<IDepartmentRepository>();
        departmentRepositoryMock.Setup(x => x.GetByTypeAsync(It.IsAny<DepartmentType>()))
            .ReturnsAsync(department);

        var command = new CreateEmployeeRequest()
        {
            BirthDate = DateTime.Now.AddYears(-18),
            ContractStart = DateTime.Now.AddDays(5),
            DepartmentType = DepartmentTypeDto.Financial,
            DocumentList = new List<CreateDocumentRequest>() { new() { Number = "00.000.000.2", DocumentType = DocumentTypeDto.Rg } },
            Name = "Michael",
            LastName = "Roz",
            PersonContactList = new List<CreatePersonContactListRequest>() { new() { Contact = "xxxx11111xx", ContactType = ContactTypeDto.CellPhone } },
            SexType = SexTypeDto.Male
        };

        var handler = new CreateEmployeeRequestHandler(_logger, 
            new Mock<IEmployeeRepository>().Object, 
            departmentRepositoryMock.Object, 
            new Mock<IDocumentRepository>().Object);


        //Act
        var response = await handler.Handle(command, new CancellationToken());


        //Assert
        Assert.True(response.GetType() == typeof(UnprocessableEntityObjectResult));
    }
}
