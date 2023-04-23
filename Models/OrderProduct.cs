using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class OrderProduct:AbstractModel
    {
        [Column("order_id")]
        public string OrderId { get; set; }
        [Column("product_id")]
        public string ProductId { get; set; }
        [Column("quatity")]
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
