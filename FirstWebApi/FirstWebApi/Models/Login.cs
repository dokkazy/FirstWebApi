using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class Login
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(250)]
        public string Password { get; set; }
    }
}
