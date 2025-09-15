namespace DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepo EmployeeRepo { get; }
        public IDepartmentRepo DepartmentRepo { get; }
        int SaveChanges();
    }
}
