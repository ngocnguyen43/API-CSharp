using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class User : AbstractModel
    {
        [Column("email")]
        public string Email { get; set; }
        [Column("full_name")]
        public string Fullname { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public string Role { get; set; } = "user";


        public virtual ICollection<Order> Orders { get; set; }
    }
}
