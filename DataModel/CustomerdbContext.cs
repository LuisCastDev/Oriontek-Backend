
using ClientesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.DataModel
{
    public class CustomerdbContext : DbContext
    {

        public CustomerdbContext(DbContextOptions<CustomerdbContext> options) : base(options) 
        {
            


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address>Addresses { get; set; }

        
    }
}
