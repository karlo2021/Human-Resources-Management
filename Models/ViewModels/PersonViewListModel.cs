namespace IdentityApp.Models.ViewModels {
    public class PersonListViewModel {
        public IEnumerable<Person> Persons { get; set; } = Enumerable.Empty<Person>();
        public PagingInfo PagingInfo { get; set; } = new();
    }
}