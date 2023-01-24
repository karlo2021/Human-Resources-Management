namespace IdentityApp.Models {
    public interface IArrows {
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        public string IdNext { get; set; }
        public string IdPrev { get; set; }
        public void HasNextPrev(string Id);
    }
}