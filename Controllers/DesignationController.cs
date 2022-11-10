using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesignationController : Controller
    {
        private readonly EmployeeDBContext _dbcontext;
        public DesignationController(EmployeeDBContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var designation =await _dbcontext.Designations.ToListAsync();
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation([FromBody] Designation designationRequest)
        {
            designationRequest.Id = new int();
            await _dbcontext.Designations.AddAsync(designationRequest);
            await _dbcontext.SaveChangesAsync();
            return Ok(designationRequest);
        }
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDesignation([FromRoute] int id)
        {
            var designation = await _dbcontext.Designations.FirstOrDefaultAsync(x => x.Id == id);
            if (designation == null)
            {
                return NotFound();
            }
            return Ok(designation);
        }
        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDesignation([FromRoute] int id, Designation updateDesignationRequest)
        {
            var designation = await _dbcontext.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            designation.DesignationName = updateDesignationRequest.DesignationName;
            designation.Department = updateDesignationRequest.Department;
           
            await _dbcontext.SaveChangesAsync();
            return Ok(designation);
        }
        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            var designation = await _dbcontext.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            _dbcontext.Designations.Remove(designation);
            await _dbcontext.SaveChangesAsync();
            return Ok(designation);
        }

    }
}
