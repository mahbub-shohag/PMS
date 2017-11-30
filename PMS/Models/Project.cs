using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PMS.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public DateTime PossibleStartDate { get; set; }
        public DateTime PossibleEndDate { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<ProjectFile> files { get; set; }
        public bool Status { get; set; }
    }
}
