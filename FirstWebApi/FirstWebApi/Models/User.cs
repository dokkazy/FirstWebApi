using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength (250)]
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
