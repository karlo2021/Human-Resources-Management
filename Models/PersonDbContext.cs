using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options)
    : base(options) { }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Record> Records => Set<Record>();
    public DbSet<Month> Months => Set<Month>();
    public DbSet<Day> Days => Set<Day>();
    public DbSet<Degree> Degrees => Set<Degree>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().HasData(
                    new Person
                    {
                        Id = 1,
                        Name = "Person",
                        Surname = "One",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 1",
                        Workplace = "Workplace 1",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person1@email.com",
                        CvDoc = "/"
                    },
                    new Person
                    {
                        Id = 2,
                        Name = "Person",
                        Surname = "Two",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 2",
                        Workplace = "Workplace 2",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person2@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 3,
                        Name = "Person",
                        Surname = "Three",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 3",
                        Workplace = "Workplace 3",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person3@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 4,
                        Name = "Person 4",
                        Surname = "Four",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 4",
                        Workplace = "Workplace 4",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person4@email.com",
                        CvDoc = "/"
                    },
                    new Person
                    {
                        Id = 5,
                        Name = "Person",
                        Surname = "Five",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 5",
                        Workplace = "Workplace 5",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person5@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 6,
                        Name = "Person",
                        Surname = "Six",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 6",
                        Workplace = "Workplace 6",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person6@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 7,
                        Name = "Person",
                        Surname = "Seven",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 7",
                        Workplace = "Workplace 7",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person7@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 8,
                        Name = "Person",
                        Surname = "Eight",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 8",
                        Workplace = "Workplace 8",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person8@email.com",
                        CvDoc = "/"

                    },
                    new Person
                    {
                        Id = 9,
                        Name = "Person",
                        Surname = "Nine",
                        Birth = new DateTime(2000,12,13),
                        Profession = "Profession 9",
                        Workplace = "Workplace 9",
                        EducationInstitute = "School",
                        EducationDegree = "A",
                        Employment = "Yes",
                        PhoneNumb = "000-888",
                        EmailAddress = "person9@email.com",
                        CvDoc = "/"
                    }
        );
        builder.Entity<Month>().HasData(
            new Month { Id = 1, Name = "primary"},
            new Month { Id = 2, Name = "secondary"},
            new Month { Id = 3, Name = "danger"},
            new Month { Id = 4, Name = "warning"},
            new Month { Id = 5, Name = "dark"},
            new Month { Id = 6, Name = "success"}
        );
        builder.Entity<Day>().HasData(
            new Day { Id = 1, Name = 1, BannerText = "User Dashboard", BackgroundColor = "secondary",
                    SideNavColor = "secondary", CvLocation = @"wwwroot\images"
                }
        );
        builder.Entity<Degree>().HasData(
            new Degree { Id = 1, Name = "A" },
            new Degree { Id = 2, Name = "B" }
        );
        
    }
}
