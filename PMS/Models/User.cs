using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DefaultPassword { get; set; }
        public bool UserStatus { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role roll { get; set; }
    }
}