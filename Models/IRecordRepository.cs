namespace IdentityApp.Models {
public interface IRecordRepository {
        IQueryable<Record> Records { get; }
        public Task DeleteRecordAsync(Record record);
        public Task<Record> FindRecordByIdAsync(int id);
    }
}