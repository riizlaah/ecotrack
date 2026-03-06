using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EcoTrackDesktop.Models
{
    public partial class EcoTrackContext : DbContext
    {
        public EcoTrackContext()
            : base("name=EcoTrack")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public User currUser = null;
        public string lastUserPhoneNum = "";

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
