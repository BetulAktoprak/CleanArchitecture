using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;
public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
    {
        _role = role;
        _userRoleRepository = userRoleRepository;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole =
            _userRoleRepository
            .Where(p => p.AppUserId == userIdClaim.Value)
            .Include(p => p.Role)
            .Any(p => p.Role.Name == _role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
