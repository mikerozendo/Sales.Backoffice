﻿using Refit;
using Sales.Backoffice.Models.Dto;

namespace Sales.Backoffice.Application.Services;

public interface IBuyerService
{
    Task<ApiResponse<BuyerDto>> PostAsync(BuyerDto buyerDto);
    Task<ApiResponse<List<BuyerDto>>> GetAsync();
}
