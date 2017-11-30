using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
      public class CustomLoginViewMode
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Passwod { get; set; }
    }
}