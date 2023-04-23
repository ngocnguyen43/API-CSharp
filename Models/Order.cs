using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Order : AbstractModel
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("order_date")]
        public DateTime OrderDate { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
        [Column("total")]
        public decimal Total
        {
            get;
            //{
            //    if (OrderProducts == null)
            //    {
            //        return 0;
            //    }
            //    else
            //    {
            //        return OrderProducts.Sum(o => o.Quantity * o.Product.Price);
            //    }
            //}
            set;
            //{
            //    if (OrderProducts == null)
            //    {
            //        Total = 0;
            //    }
            //    else
            //    {
            //        Total = OrderProducts.Sum(o => o.Quantity * o.Product.Price);
            //    }
            //}
        }
        public User User { get; set; }
    }
}
