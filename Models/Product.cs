using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Product : AbstractModel
    {
        [Column("product_name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
