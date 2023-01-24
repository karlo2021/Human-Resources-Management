namespace IdentityApp.Models {
    public interface IPersonRepository {
        IQueryable<Person> Persons { get; }
        public IQueryable<Month> Months { get; }
        public IQueryable<Day> Days { get; }
        public IQueryable<Degree> Degrees { get; }

        public Person GetPerson(string Id);
        public Task<Person> GetPersonByIdAsync(string Id);
        public Task DeletePersonAsync(Person person);
        public Task SavePerson(Person p);

        public Task AddMonthAsync(Month month);
        public Task RemoveMonthAsync(Month month);

        public Task AddDayAsync(Day day);
        public  Task RemoveDayAsync(Day day);

        public Task AddDegreeAsync(Degree degree);
        public  Task RemoveDegreeAsync(Degree degree);
    }
}