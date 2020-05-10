using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dopta.API.Domain.Models;
using System.Linq.Expressions;

namespace Dopta.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Specie> Species { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }

       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Category Entity
            base.OnModelCreating(builder);
            builder.Entity<Specie>().ToTable("Species");
            //Fluent API
            builder.Entity<Specie>().HasKey(s => s.Id);
            builder.Entity<Specie>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Specie>().Property(s => s.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Specie>().HasMany(s => s.Pets)
                                    .WithOne(s => s.Specie)
                                    .HasForeignKey(s => s.SpecieId);
            builder.Entity<Specie>().HasData
                (
                    new Specie { Id = 1, Name = "Gatos" },
                    new Specie { Id = 2, Name = "Perros"}
                );
            
            //Pet Entity
            base.OnModelCreating(builder);
            builder.Entity<Pet>().ToTable("Pets");
            builder.Entity<Pet>().HasKey(s => s.Id);
            builder.Entity<Pet>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(s => s.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Pet>().HasData
                (
                new Pet { Id=1,Name="Toñito",SpecieId=1,PostId=1 ,Size=ESize.Medium,Sex=EGender.Male},
                new Pet { Id=2,Name="Roko",SpecieId=2, PostId= 2, Size = ESize.Big , Sex = EGender.Male },
                new Pet { Id=3,Name="Pelusa",SpecieId=1, PostId= 3, Size = ESize.Small , Sex = EGender.Male }
                );
            //Profile Entity
            base.OnModelCreating(builder);
            builder.Entity<UserProfile>().ToTable("Profiles");
            builder.Entity<UserProfile>().HasKey(s => s.Id);
            builder.Entity<UserProfile>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserProfile>().Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Entity<UserProfile>().Property(s => s.LastName).IsRequired().HasMaxLength(100);
            builder.Entity<UserProfile>().Property(s => s.ProfilePickUrl).HasMaxLength(255);
            builder.Entity<UserProfile>().HasOne(p => p.User)
                                   .WithOne(p => p.UserProfile)
                                   .HasForeignKey<UserProfile>(p => p.Id);
            builder.Entity<UserProfile>().HasData
                (
                    new UserProfile { Id=1,Name="Ivan",LastName="Sackuvick",Dni=87654322,UserId=1},
                    new UserProfile { Id = 2, Name = "Felipe", LastName = "Kcomt", Dni = 9876543 ,UserId=2}
                );



            //User Entity
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email_address).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(15);
            builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(15);
            builder.Entity<User>().HasMany(u => u.Posts)
                                   .WithOne(u => u.Poster)
                                   .HasForeignKey(s => s.PosterId);

            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Email_address = "Ivan_Retiro_Lopez@gmail.com", Username = "IvanR", Password = "Retiro" ,},
                    new User { Id = 2, Email_address = "Felipe_Kcomt@gmail.com", Username = "Felipe123", Password = "Dopta" },
                    new User { Id = 3, Email_address = "Alfoncito_Trettenero@gmail.com", Username = "AlfonsoGea", Password = "GeaxSiempre" }
                 );
            //Post Entity
            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Post>().HasOne(p => p.Pet)
                                   .WithOne(p => p.Post)
                                   .HasForeignKey<Post>(p => p.Id);
            builder.Entity<Post>().HasData
            (
                new Post { Id = 1, PosterId = 1, PetId = 3,Description = "blablablbal"},
                new Post { Id = 2, PosterId = 2, PetId = 1,Description = "dafdsdfs" },
                new Post { Id = 3, PosterId = 3, PetId = 2,Description = "gfdxcvb" }
            );

            //Candidate Entity
            builder.Entity<Candidate>().ToTable("Candidates");
            builder.Entity<Candidate>().HasKey(t => new { t.PostId, t.AdopterId });
            builder.Entity<Candidate>().HasOne(pt => pt.Post)
                                       .WithMany(p => p.Candidates)
                                       .HasForeignKey(pt => pt.PostId);
            builder.Entity<Candidate>().HasOne(pt => pt.Adopter)
                                       .WithMany(t => t.Candidates)
                                       .HasForeignKey(pt => pt.AdopterId);
            builder.Entity<Candidate>().HasData
            (
                new Candidate {PostId = 1, AdopterId = 1},
                new Candidate {PostId = 1, AdopterId = 2},
                new Candidate {PostId = 3, AdopterId = 3}
            );



            ApplySnakeCaseNamingConvention(builder);
        }
        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }
}

