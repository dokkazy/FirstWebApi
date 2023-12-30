using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{

    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        [Range(0, int.MaxValue)]
        public int UnitInStock { get; set; }
        
        public string Description { get; set; }
        
        public byte Discount { get; set; }

        public int? CategoryId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Category Category { get; set; }
    }
}
