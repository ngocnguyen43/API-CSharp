using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi2.Models
{
    public abstract class AbstractModel
    {
        [Column("id")]
        public string Id { get; set; }
    }
}
