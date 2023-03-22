using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }

    }
}