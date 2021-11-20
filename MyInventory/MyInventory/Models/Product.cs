using System.ComponentModel.DataAnnotations;

namespace MyInventory.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double Price  { get; set; }
    }
}
