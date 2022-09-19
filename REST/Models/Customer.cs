using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace REST.Models
{
    [Table("tb_m_customer")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name"), MaxLength(150), Required]
        public string Name { get; set; }
        [Column("address"), MaxLength(150), Required]
        public string Address { get; set; }
        [Column("city"), MaxLength(50), Required]
        public string City { get; set; }

        [JsonIgnore]
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
