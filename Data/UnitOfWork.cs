using EmployeeManagementSystem.Data.Repo;
using EmployeeManagementSystem.Interface;

namespace EmployeeManagementSystem.Data
{
    public class UnitOfWork : IUnitofWork
    {
        private EmployeeDBContext dBContext;
        public UnitOfWork(EmployeeDBContext dBContext)
        {
            this.dBContext = dBContext;
                
        }

        public IUserRepository UserRepository => new UserRepository(dBContext);

        public async Task<bool> SaveAsync()
        {
            return await dBContext.SaveChangesAsync() > 0;
        }
    }
}
