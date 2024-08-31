using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed record LoginCommand(
    string userNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
