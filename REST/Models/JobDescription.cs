using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace REST.Models
{
    [Table("tb_m_job_description")]
    public class JobDescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name"), Required, MaxLength(30)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
