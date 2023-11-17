using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string phoneNumber { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }





    }
}
