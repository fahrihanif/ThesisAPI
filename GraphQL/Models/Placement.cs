using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GraphQL.Models
{
    [Table("tb_tr_placement")]
    public class Placement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("department"), MaxLength(50), Required]
        public string Departement { get; set; }
        [Column("start_date"), Required]
        public DateTime StartDate { get; set; }
        [Column("finish_date")]
        public DateTime? FinishDate { get; set; }
        [Column("notes"), MaxLength(100)]
        public string Notes { get; set; }
        [Column("created_by"), MaxLength(50), Required]
        public string CreatedBy { get; set; }
        [Column("create_date"), Required]
        public DateTime CreateDate { get; set; }
        [Column("customer"), Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
