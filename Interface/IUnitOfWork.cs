namespace EmployeeManagementSystem.Interface
{
    public interface IUnitofWork
    {
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}
