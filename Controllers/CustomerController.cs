using ClientesApi.DataModel;
using ClientesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ClientesApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerdbContext _context;

        public CustomerController(CustomerdbContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IEnumerable<Customer> Get() => _context.Customers.ToList();

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(a => a.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        [HttpDelete("delete/{customerId}")]

        public async Task<ActionResult> Delete(int customerId)
        {
            var affectedRows = await _context.Customers.Where(a => a.CustomerId == customerId).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
