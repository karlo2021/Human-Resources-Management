namespace IdentityApp.Models {
public class Arrows : IArrows {
        public bool HasNext { get; set; } = false;
        public bool HasPrev { get; set; } = false;
        public string IdNext { get; set; } = string.Empty;
        public string IdPrev { get; set; }  = string.Empty;
        
        private IPersonRepository repository;
        public Arrows(IPersonRepository ctx) {
            repository = ctx;  
        }

        public void HasNextPrev(string Id) {
            var temp = repository.Persons.ToList().Last();
            HasNext = long.Parse(Id) < temp.Id ? true : false;
            temp = repository.Persons.First();
            HasPrev = int.Parse(Id) > temp.Id ? true : false;
            if (HasNext) {
                IdNext = (int.Parse(Id) + 1).ToString();
                while(repository.GetPerson(IdNext)==null) {
                    IdNext = (int.Parse(IdNext)+1).ToString();
                }
            }
            if (HasPrev) {
                IdPrev = (int.Parse(Id) - 1).ToString();
                while(repository.GetPerson(IdPrev)==null) {
                    IdPrev = (int.Parse(IdPrev)-1).ToString();
                }
            }
        }

    }
}