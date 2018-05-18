using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class GenericContext<T> : DbContext where T : class
    {
        public GenericContext() { }
        public DbSet<T> Data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(typeof(T).ToString());
            base.OnModelCreating(modelBuilder);
        }
    }

}
