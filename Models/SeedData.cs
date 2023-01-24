using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;

public static class SeedData {
    public static void EnsurePopulated(this IApplicationBuilder app) {
        SeedPersonData(app).GetAwaiter().GetResult();
    }

    private async static Task SeedPersonData(IApplicationBuilder app) {
        using (var scope = app.ApplicationServices.CreateScope()) {

            var context = scope.ServiceProvider.GetService<PersonDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            // if (!context.Persons.Any()) {
            //     context.Persons.AddRange(
            //         new Person
            //         {
            //             Id = 1,
            //             Name = "Kayak",
            //             Price = 275,
            //             Rating = 275,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 2,
            //             Name = "Lifejacket",
            //             Price = 48.95m,
            //             Rating = 48.95m,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 3,
            //             Name = "Soccer Ball",
            //             Price = 19.50m,
            //             Rating = 19.50m,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 4,
            //             Name = "Corner Flags",
            //             Price = 34.95m,
            //             Rating = 34.95m,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 5,
            //             Name = "Stadium",
            //             Price = 79500,
            //             Rating = 79500,
            //             Birth = new DateTime(2000,12,13)

            //         },
            //         new Person
            //         {
            //             Id = 6,
            //             Name = "Thinking Cap",
            //             Price = 16,
            //             Rating = 16,
            //             Birth = new DateTime(2000,12,13)

            //         },
            //         new Person
            //         {
            //             Id = 7,
            //             Name = "Unsteady Chair",
            //             Price = 29.95m,
            //             Rating = 29.95m,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 8,
            //             Name = "Human Chess Board",
            //             Price = 75,
            //             Rating = 75,
            //             Birth = new DateTime(2000,12,13)
            //         },
            //         new Person
            //         {
            //             Id = 9,
            //             Name = "Bling-Bling King",
            //             Price = 1200,
            //             Rating = 1200,
            //             Birth = new DateTime(2000,12,13)
            //         }
            //     );

            //     context.SaveChanges();
            // }
        }
    }
}