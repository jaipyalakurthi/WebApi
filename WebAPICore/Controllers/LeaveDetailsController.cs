using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.Data;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class LeaveDetailsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public LeaveDetailsController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<LeaveDetails> GetLeaveDetails()
        {
            return _context.LeaveDetails;
        }

        [HttpPost]
        public async Task<IActionResult> PostLeaveDetails([FromBody] LeaveDetails leaveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeaveDetails.Add(leaveDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveDetails", new { id = leaveDetails.LeaveID }, leaveDetails);
        }
    }
}