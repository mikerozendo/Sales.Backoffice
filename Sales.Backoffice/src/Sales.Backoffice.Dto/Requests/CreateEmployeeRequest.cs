﻿using FluentResults;
using MediatR;

namespace Sales.Backoffice.Dto.Requests;

public class CreateEmployeeRequest : IRequest<Result>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public DateOnly BirthDate { get; set; }
    public int SexType { get; set; }
    public string ZipCode { get; set; }
}
