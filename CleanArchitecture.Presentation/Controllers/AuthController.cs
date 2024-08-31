using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
