using DataAccess.Data.DbContexts;
using DataAccess.Repositories.Interfaces;


namespace DataAccess.Repositories.Classes
{
    public class EmployeeRepo(AppDbContext dbContext) : GenericRepo<Employee>(dbContext), IEmployeeRepo
    {
    }
}
