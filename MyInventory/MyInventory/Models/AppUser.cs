using Microsoft.AspNetCore.Identity;

namespace MyInventory.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
