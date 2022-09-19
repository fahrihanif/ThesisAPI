using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Models
{
    [Table("tb_tr_interview")]
    public class Interview
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("interview_datetime"), Required]
        public DateTime InterviewDatetime { get; set; }
        [Column("notes"), MaxLength(50), Required]
        public string Notes { get; set; }
        [Column("department"), MaxLength(25), Required]
        public string Department { get; set; }
        [Column("status"), Required]
        public Status Status { get; set; }
        [Column("created_by"), MaxLength(50), Required]
        public string CreatedBy { get; set; }
        [Column("create_date"), Required]
        public DateTime CreateDate { get; set; }
        [Column("updated_by"), MaxLength(50)]
        public string UpdatedBy { get; set; }
        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }
        [Column("employee")]
        public int? EmployeeId { get; set; }
        [Column("job_description")]
        public int? JobDescriptionId { get; set; }
        [Column("interviewer_email"), MaxLength(50), Required]
        public string InterviewerEmail { get; set; }
        [Column("interviewer_name"), MaxLength(100), Required]
        public string InterviewerName { get; set; }
        [Column("interview_type"), Required]
        public InterviewType InterviewType { get; set; }
        [Column("interview_location"), MaxLength(255), Required]
        public string InterviewLocation { get; set; }
        [Column("placement")]
        public int? PlacementId { get; set; }

        [ForeignKey("JobDescriptionId")]
        public virtual JobDescription? JobDescription { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("PlacementId")]
        public virtual Placement? Placement { get; set; }
    }

    [System.ComponentModel.DefaultValue(0)]
    public enum Status
    {
        Interview = 0,
        Accept = 1,
        Reject = 2,
        Onboard = 3
    }

    public enum InterviewType
    {
        Online, Offline
    }

}
