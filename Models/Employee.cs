using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime  DateOfJoining { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }

    }
}
