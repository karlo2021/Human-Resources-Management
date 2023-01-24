using Microsoft.EntityFrameworkCore;
namespace IdentityApp.Models {
    public class EFRecordRepository : IRecordRepository {
        private PersonDbContext context;
        public EFRecordRepository(PersonDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Record> Records => context.Records;
        public async Task DeleteRecordAsync(Record record) {
            context.Remove<Record>(record);
            await context.SaveChangesAsync();
        }

        public async Task<Record> FindRecordByIdAsync(int id) {
            return await Records.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}