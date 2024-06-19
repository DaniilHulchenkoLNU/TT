using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserInfo: IdentityUser
    {
        //[Key, ForeignKey(nameof(Employee ))]
        //public int UserID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
