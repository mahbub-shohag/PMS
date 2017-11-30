using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Project project { get; set; }
    }
}