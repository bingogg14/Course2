using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class UserContext : DbContext
    {
        public UserContext() { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Users");
            base.OnModelCreating(modelBuilder);
        }
    }
}
