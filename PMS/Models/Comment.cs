using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project project { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual ProjectTask projectTask { get; set; }
        public int CommentedBy { get; set; }
        [ForeignKey("CommentedBy")]
        public virtual User user { get; set; }
    }
}