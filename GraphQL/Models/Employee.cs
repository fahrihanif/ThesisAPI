using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GraphQL.Models
{
    [Table("tb_m_employee")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name"), MaxLength(50), Required]
        public string FirstName { get; set; }
        [Column("last_name"), MaxLength(50)]
        public string LastName { get; set; }
        [Column("birth_date"), Required]
        public DateTime BirthDate { get; set; }
        [Column("gender"), Required]
        public Gender Gender { get; set; }
        [Column("status"), MaxLength(50), Required]
        public string Status { get; set; }
        [Column("email"), MaxLength(50), Required]
        public string Email { get; set; }
        [Column("email_company"), MaxLength(50)]
        public string EmailCompany { get; set; }
        [Column("phone"), MaxLength(15), Required]
        public string Phone { get; set; }

        [JsonIgnore]
        public virtual ICollection<Interview> Interviews { get; set; }
    }

    public enum Gender
    {
        MALE, FEMALE
    }
}
