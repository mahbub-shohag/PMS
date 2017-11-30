using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using PMS.Migrations;
using PMS.Models;

namespace PMS
{
    public class PMSDbContext : DbContext
    {
        public System.Data.Entity.DbSet<PMS.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<PMS.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<PMS.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<PMS.Models.UserProject> UserProjects { get; set; }

        public System.Data.Entity.DbSet<PMS.Models.ProjectTask> ProjectTasks { get; set; }

        public System.Data.Entity.DbSet<PMS.Models.Comment> Comments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}