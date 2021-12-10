using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace SecurityQuestions.Models
{
    public class EFContext : DbContext
    {
        //Add connection string to config file later
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SecurityQuestions;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityQuestion>()
                .ToTable("SecurityQuestion");

            modelBuilder.Entity<SecurityQuestion>()
               .HasData(
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 1,
                        Description = "In what city were you born?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 2,
                        Description = "What is the name of your favorite pet?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 3,
                        Description = "What is your mother's maiden name?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 4,
                        Description = "What high school did you attend?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 5,
                        Description = "What was the mascot of your high school?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 6,
                        Description = "What was the make of your first car?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 7,
                        Description = "What was your favorite toy as a child?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 8,
                        Description = "Where did you meet your spouse?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 9,
                        Description = "What is your favorite meal?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 10,
                        Description = "Who is your favorite actor / actress?"
                    },
                    new SecurityQuestion
                    {
                        SecurityQuestionID = 11,
                        Description = "What is your favorite album?"
                    }
                );

                 modelBuilder.Entity<User>()
                 .HasData(
                 new User
                 {
                    UserID = 1,
                    Name = "John",
                 },
                 new User
                 {
                    UserID = 2,
                    Name = "David",
                 }
            ); ;
        }
    }
}
