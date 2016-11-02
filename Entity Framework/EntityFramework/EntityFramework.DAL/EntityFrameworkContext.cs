using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.Domain;

namespace EntityFramework.DAL
{
    public class EntityFrameworkContext : DbContext
    {
        //DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Session>  Session { get; set; }

        //Naam van de database meegeven
        public EntityFrameworkContext() : base("EntityFrameworkDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User fluent API
            modelBuilder.Entity<User>().HasKey(k => k.UserId); //PK instellen
            modelBuilder.Entity<User>().Property(k => k.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //PK automatisch laten genereren bij het maken van een nieuwe rij

            //Session fluent API
            modelBuilder.Entity<Session>().HasKey(k => k.SessionId); //PK instellen
            modelBuilder.Entity<Session>().Property(k => k.SessionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //PK automatisch laten genereren bij het maken van een nieuwe rij

            //Fluent API voor relationship
            modelBuilder.Entity<Session>()
                .HasRequired(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);
        }





    }
}
