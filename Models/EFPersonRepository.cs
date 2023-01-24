using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models {
    public class EFPersonRepository : IPersonRepository {
        private PersonDbContext context;
        public EFPersonRepository(PersonDbContext ctx) => context = ctx;
        public IQueryable<Person> Persons => context.Persons
            .Include(p => p.Records);
        
        public IQueryable<Month> Months => context.Months;
        public IQueryable<Day> Days => context.Days;
        public IQueryable<Degree> Degrees => context.Degrees;

        
        public Person GetPerson(string Id) {
            return Persons.FirstOrDefault(p => p.Id == int.Parse(Id));
        }
        public async Task<Person> GetPersonByIdAsync(string Id) {
            return await Persons.FirstOrDefaultAsync(p => p.Id == int.Parse(Id));
        }

        public async Task DeletePersonAsync(Person person) {
            var records = GetPerson(person.Id.ToString()).Records;
            context.Persons.Remove(person);
            context.Records.RemoveRange(records);
            await context.SaveChangesAsync();
        }
        public async Task SavePerson(Person p) {
            if (p.Id != default(long)) {
                context.Update(p);
            }
            else {
                context.Persons.Add(p);
            }
            await context.SaveChangesAsync();
        }

        public async Task AddMonthAsync(Month month) {
            context.Months.Add(month);
            await context.SaveChangesAsync();
        }

        public async Task RemoveMonthAsync(Month month) {
            context.Months.Remove(month);
            await context.SaveChangesAsync();
        }

        public async Task AddDayAsync(Day day) {
            context.Days.Add(day);
            await context.SaveChangesAsync();
        }

        public async Task RemoveDayAsync(Day day) {
            context.Days.Remove(day);
            await context.SaveChangesAsync();
        }

        public async Task AddDegreeAsync(Degree degree) {
            context.Degrees.Add(degree);
            await context.SaveChangesAsync();
        }

        public async Task RemoveDegreeAsync(Degree degree) {
            context.Degrees.Remove(degree);
            await context.SaveChangesAsync();
        }
    }
}