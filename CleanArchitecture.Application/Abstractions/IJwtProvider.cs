using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstractions;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user);
}
