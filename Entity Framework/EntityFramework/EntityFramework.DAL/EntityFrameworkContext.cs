using EntityFramework.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EntityFramework.DAL
{
    public class EntityFrameworkContext : DbContext
    {
        //DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Credentials> Credentials { get; set; }

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

            //Credentials fluent API
            modelBuilder.Entity<Credentials>().HasKey(k => k.CredentialId); //PK instellen
            modelBuilder.Entity<Credentials>().Property(k => k.CredentialId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //PK automatisch laten genereren bij het mqken vqn een nieuwe rij

            //Fluent API voor relationship tussen Session en User
            modelBuilder.Entity<Session>()
                .HasRequired(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            //Fluent API voor relationshop tussen User en Credentials
            modelBuilder.Entity<Credentials>()
                .HasRequired(c => c.User)
                .WithMany(u => u.Credentials)
                .HasForeignKey(c => c.UserId);

        }





    }
}
