using System.ComponentModel.DataAnnotations;

namespace MyInventory.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Items must be more than or equal to {1}")]
        public int Count { get; set; }
    }
}
