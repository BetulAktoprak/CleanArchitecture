using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [RoleFilter("Create")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [RoleFilter("GetAll")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
