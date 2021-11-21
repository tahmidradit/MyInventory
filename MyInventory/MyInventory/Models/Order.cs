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
        public int Count { get; set; }
    }
}
