using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly EmployeeDBContext _dbcontext;

        public LeavesController(EmployeeDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leave = await _dbcontext.Leaves.ToListAsync();
            return Ok(leave);
        }
        [HttpPost]
        public async Task<IActionResult> AddLeave([FromBody] Leave leaveRequest)
        {
            leaveRequest.Id = new int();
            await _dbcontext.Leaves.AddAsync(leaveRequest);
            await _dbcontext.SaveChangesAsync();
            return Ok(leaveRequest);
        }
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLeave([FromRoute] int id)
        {
            var leave = await _dbcontext.Leaves.FirstOrDefaultAsync(x => x.Id == id);
            if (leave == null)
            {
                return NotFound();
            }
            return Ok(leave);
        }
        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateLeave([FromRoute] int id, Leave updateLeaveRequest)
        {
            var leave = await _dbcontext.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            leave.StartDate = updateLeaveRequest.StartDate;
            leave.EndDate = updateLeaveRequest.EndDate;
            leave.Type = updateLeaveRequest.Type;
           
            await _dbcontext.SaveChangesAsync();
            return Ok(leave);
        }
        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteLeave([FromRoute] int id)
        {
            var leave = await _dbcontext.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            _dbcontext.Leaves.Remove(leave);
            await _dbcontext.SaveChangesAsync();
            return Ok(leave);
        }








    }
}
