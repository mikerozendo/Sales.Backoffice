﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Requests.Queries;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/departments")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class DepartmentsController : ControllerBase
{
	private readonly IMediator _mediator;

	public DepartmentsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("{type}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByType(DepartmentTypeDto type, CancellationToken cancellationToken)
	{
		return await _mediator.Send(new GetDepartmentByTypeRequest(type), cancellationToken);
	}
	
	[HttpPatch("update-base-salary")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> UpdateSalary([FromBody]UpdateDepartmentBaseSalaryRequest request, CancellationToken cancellationToken)
	{
		return await _mediator.Send(request, cancellationToken);
	}
}
