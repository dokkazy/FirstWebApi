using FirstWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.ViewModels
{
    public class CategoryViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
