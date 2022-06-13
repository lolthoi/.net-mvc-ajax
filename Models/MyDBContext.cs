using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=MyContact") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}