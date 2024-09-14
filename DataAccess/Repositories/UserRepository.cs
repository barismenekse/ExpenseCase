using ExpenseCase.DataAccess.Context;
using ExpenseCase.DataAccess.Entities;
using ExpenseCase.DataAccess.Repositories.Abstracts;
using ExpenseCase.DataAccess.Repositories.Interfaces;

namespace ExpenseCase.DataAccess.Repositories;

public class UserRepository : EfRepositoryBase<User>, IUserRepository
{
    public UserRepository(MyDbContext context) : base(context)
    {
    }
}