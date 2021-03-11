using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Auth_Forms.Models;

namespace Auth_Forms
{
    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserDBEntities")
        {
        }

         
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
