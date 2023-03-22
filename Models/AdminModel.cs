using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}