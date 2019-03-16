using System.Data.Entity;
using UserProfileAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UserProfileAPIDemo.DAL
{
    public class UserProfileContext : DbContext
    {
        public UserProfileContext() : base("UserProfileContext")
        {
        }

        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}