using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeesController(EmployeeDBContext employeeDBContext)
        {
            _dbContext = employeeDBContext;

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employee=await _dbContext.Employees.ToListAsync();
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeRequest)
        {
            employeeRequest.Id=new Guid();
            await _dbContext.Employees.AddAsync(employeeRequest);
            await _dbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee=await _dbContext.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,Employee updateEmployeeRequest)
        {
            var employee= await _dbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.PhoneNumber = updateEmployeeRequest.PhoneNumber;
            employee.Age = updateEmployeeRequest.Age;
            employee.DateOfJoining = updateEmployeeRequest.DateOfJoining;
            employee.Gender = updateEmployeeRequest.Gender;
            employee.Designation = updateEmployeeRequest.Designation;
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee= await _dbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
