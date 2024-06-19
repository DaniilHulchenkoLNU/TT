using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;


namespace Domain.Entity
{
    [Table("Employees")]
    public class Employee: DbBase
    {

        public string UserInfoId { get; set; }

        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Subdivision { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Status { get; set; }  // Active/Inactive

        public int? PeoplePartnerId { get; set; }

        [Required]
        public float OutOfOfficeBalance { get; set; }

        public string Photo { get; set; }  // Optional field for photo

        [ForeignKey(nameof(PeoplePartnerId))]
        public virtual Employee PeoplePartner { get; set; }

        public virtual ICollection<Employee> PeoplePartners { get; set; } = new List<Employee>();

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();
    }
}
