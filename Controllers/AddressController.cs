using ClientesApi.DataModel;
using ClientesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private CustomerdbContext _context;

        public AddressController(CustomerdbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Customer>> GetAddresses(int id)
        {
            var addresses = _context.Addresses.Where(t => t.CustomerId == id)
                                                    .ToList();
            return Ok(addresses);
        }


        [HttpDelete("delete/{addressId}")]

        public async Task<ActionResult> Delete(int addressId)
        {
            var affectedRows = await _context.Addresses.Where(a => a.AddressId == addressId).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddresses), new { id = address.AddressId }, address);
        }


        [HttpPut]
        public ActionResult<Address> Update([FromBody] Address address)
        {
            _context.Update(address);
            _context.SaveChanges();

            return Ok(address);
        }




    }
}
