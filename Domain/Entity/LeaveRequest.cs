using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("LeaveRequests")]
    public class LeaveRequest: DbBase
    {


        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string AbsenceReason { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [DefaultValue("New")]
        public string Status { get; set; }  // Status updated by actions

        public string Comment { get; set; }  // Optional field for comment

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();
    }
}
