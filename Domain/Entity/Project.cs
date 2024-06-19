using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Projects")]
    public class Project: DbBase
    {


        [Required]
        public string ProjectType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }  // Optional field for end date

        [Required]
        public int ProjectManagerId { get; set; }

        [Required]
        public string Status { get; set; }  // Active/Inactive

        public string Comment { get; set; }  // Optional field for comment

        [ForeignKey("ProjectManagerId")]
        public virtual Employee ProjectManager { get; set; }
    }
}
