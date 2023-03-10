// <auto-generated />
using System;
using IdentityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PersonApp.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20230109183655_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IdentityApp.Models.Day", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CvLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<string>("SideNavColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BackgroundColor = "secondary",
                            BannerText = "User Dashboard",
                            CvLocation = "wwwroot\\images",
                            Name = 1,
                            SideNavColor = "secondary"
                        });
                });

            modelBuilder.Entity("IdentityApp.Models.Degree", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "B"
                        });
                });

            modelBuilder.Entity("IdentityApp.Models.Month", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Months");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "primary"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "secondary"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "danger"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "warning"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "dark"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "success"
                        });
                });

            modelBuilder.Entity("IdentityApp.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("CvDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationDegree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationInstitute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workplace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person1@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 1",
                            Surname = "One",
                            Workplace = "Workplace 1"
                        },
                        new
                        {
                            Id = 2L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person2@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 2",
                            Surname = "Two",
                            Workplace = "Workplace 2"
                        },
                        new
                        {
                            Id = 3L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person3@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 3",
                            Surname = "Three",
                            Workplace = "Workplace 3"
                        },
                        new
                        {
                            Id = 4L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person4@email.com",
                            Employment = "Yes",
                            Name = "Person 4",
                            PhoneNumb = "000-888",
                            Profession = "Profession 4",
                            Surname = "Four",
                            Workplace = "Workplace 4"
                        },
                        new
                        {
                            Id = 5L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person5@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 5",
                            Surname = "Five",
                            Workplace = "Workplace 5"
                        },
                        new
                        {
                            Id = 6L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person6@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 6",
                            Surname = "Six",
                            Workplace = "Workplace 6"
                        },
                        new
                        {
                            Id = 7L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person7@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 7",
                            Surname = "Seven",
                            Workplace = "Workplace 7"
                        },
                        new
                        {
                            Id = 8L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person8@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 8",
                            Surname = "Eight",
                            Workplace = "Workplace 8"
                        },
                        new
                        {
                            Id = 9L,
                            Birth = new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CvDoc = "/",
                            EducationDegree = "A",
                            EducationInstitute = "School",
                            EmailAddress = "person9@email.com",
                            Employment = "Yes",
                            Name = "Person",
                            PhoneNumb = "000-888",
                            Profession = "Profession 9",
                            Surname = "Nine",
                            Workplace = "Workplace 9"
                        });
                });

            modelBuilder.Entity("IdentityApp.Models.Record", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"), 1L, 1);

                    b.Property<bool>("Employed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("IdentityApp.Models.Record", b =>
                {
                    b.HasOne("IdentityApp.Models.Person", null)
                        .WithMany("Records")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("IdentityApp.Models.Person", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
