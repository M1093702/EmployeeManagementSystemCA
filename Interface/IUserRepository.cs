using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interface
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string userName, string password);
        void Register(string userName, string pasword);
        Task<bool> UserAlreadyExists(string userName);
    }
}
