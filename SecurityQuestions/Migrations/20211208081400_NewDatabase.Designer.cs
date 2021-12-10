﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityQuestions.Models;

namespace SecurityQuestions.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20211208081400_NewDatabase")]
    partial class NewDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityQuestions.Models.SecurityQuestion", b =>
                {
                    b.Property<int>("SecurityQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecurityQuestionID");

                    b.ToTable("SecurityQuestion");

                    b.HasData(
                        new
                        {
                            SecurityQuestionID = 1,
                            Description = "In what city were you born?"
                        },
                        new
                        {
                            SecurityQuestionID = 2,
                            Description = "What is the name of your favorite pet?"
                        },
                        new
                        {
                            SecurityQuestionID = 3,
                            Description = "What is your mother's maiden name?"
                        },
                        new
                        {
                            SecurityQuestionID = 4,
                            Description = "What high school did you attend?"
                        },
                        new
                        {
                            SecurityQuestionID = 5,
                            Description = "What was the mascot of your high school?"
                        },
                        new
                        {
                            SecurityQuestionID = 6,
                            Description = "What was the make of your first car?"
                        },
                        new
                        {
                            SecurityQuestionID = 7,
                            Description = "What was your favorite toy as a child?"
                        },
                        new
                        {
                            SecurityQuestionID = 8,
                            Description = "Where did you meet your spouse?"
                        },
                        new
                        {
                            SecurityQuestionID = 9,
                            Description = "What is your favorite meal?"
                        },
                        new
                        {
                            SecurityQuestionID = 10,
                            Description = "Who is your favorite actor / actress?"
                        },
                        new
                        {
                            SecurityQuestionID = 11,
                            Description = "What is your favorite album?"
                        });
                });

            modelBuilder.Entity("SecurityQuestions.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Name = "John"
                        },
                        new
                        {
                            UserID = 2,
                            Name = "David"
                        });
                });

            modelBuilder.Entity("SecurityQuestions.Models.UserSecurityQuestion", b =>
                {
                    b.Property<int>("UserSecurityQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SecurityQuestionAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityQuestionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserSecurityQuestionID");

                    b.ToTable("UserSecurityQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
