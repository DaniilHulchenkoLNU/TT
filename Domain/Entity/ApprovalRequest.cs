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
    [Table("ApprovalRequests")]
    public class ApprovalRequest: DbBase
    {

        [Required]
        public int ApproverId { get; set; }

        [Required]
        public int LeaveRequestId { get; set; }

        [Required]
        [DefaultValue("New")]
        public string Status { get; set; }  

        public string Comment { get; set; }   

        [ForeignKey("ApproverId")]
        public virtual Employee Approver { get; set; }

        [ForeignKey("LeaveRequestId")]
        public virtual LeaveRequest LeaveRequest { get; set; }
    }


    //public string ApproverId { get; set; }

    //[ForeignKey("ApproverId")]
    //public virtual Employee Approver { get; set; }

    //public string LeaveRequestId { get; set; }
    //[ForeignKey("LeaveRequestId")]
    //public virtual LeaveRequest LeaveRequest { get; set; }

    //public string Comment { get; set; }
    //[Required]
    //[DefaultValue("New")]
    //public string Status { get; set; }
}
