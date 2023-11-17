using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesApi.Models
{
    public class Address
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public string House_Apt { get; set; }
        public string Street { get; set; } 
        public string City { get; set; } 
        public string State { get; set; }
        public string PostalCode { get; set; }  
        public string Country { get; set; } 



        

    }
}
