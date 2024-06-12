using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportingAPI_DotNet8_EF.Data;
using ReportingAPI_DotNet8_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingAPI_DotNet8_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderHeader>>> GetSalesOrderHeaders()
        {
            return await _context.SalesOrderHeaders.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderHeader>> GetSalesOrderHeader(int id)
        {
            var salesOrderHeader = await _context.SalesOrderHeaders.FindAsync(id);

            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return salesOrderHeader;
        }

        // GET: api/Customer/GetSalesOrdersByDateRange
        [HttpGet("GetSalesOrdersByDateRange")]
        public async Task<ActionResult<IEnumerable<SalesOrderHeader>>> GetSalesOrdersByDateRange([FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (!DateTime.TryParse(startDate, out DateTime startDateTime) || !DateTime.TryParse(endDate, out DateTime endDateTime))
            {
                return BadRequest("Invalid date format. Please use YYYY-MM-DD format.");
            }

            // Set endDateTime to the end of the day to include the entire end date
            endDateTime = endDateTime.Date.AddDays(1).AddTicks(-1);

            // Log the dates being used for the query
            Console.WriteLine($"Querying sales data from {startDateTime} to {endDateTime}");

            var salesOrderHeaders = await _context.SalesOrderHeaders
                .Where(h => h.OrderDate >= startDateTime && h.OrderDate <= endDateTime)
                .ToListAsync();

            // Log the number of records found
            Console.WriteLine($"Found {salesOrderHeaders.Count} sales order headers");

            if (!salesOrderHeaders.Any())
            {
                return NotFound("No sales orders found for the specified date range.");
            }

            return Ok(salesOrderHeaders);
        }
    }
}
