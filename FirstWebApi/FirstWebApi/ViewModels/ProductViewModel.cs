using FirstWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int UnitInStock { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
