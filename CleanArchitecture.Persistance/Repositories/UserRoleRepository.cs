using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using GenericRepository;

namespace CleanArchitecture.Persistance.Repositories;
public class UserRoleRepository : Repository<UserRole, AppDbContext>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}
