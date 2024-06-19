using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Roles")]
    public class Role: DbBase
    {

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<Permission> Permissions { get; set; }
    }
}
