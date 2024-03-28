using IndiaMarathon.API.Data;
using IndiaMarathon.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaMarathon.API.Repository
{
    public class SQLLevelRepository:ILevelRepository
    {
        private readonly MarathonDbContext marathonDbContext;

        public SQLLevelRepository(MarathonDbContext marathonDbContext)
        {
            this.marathonDbContext = marathonDbContext;
        }

        public async Task<Level> CreateLevel(Level level)
        {
            await marathonDbContext.Levels.AddAsync(level);
            await marathonDbContext.SaveChangesAsync();
            return level;
        }

        public async Task<Level?> DeleteLevel(int id)
        {
            var existinglevel=await marathonDbContext.Levels.FirstOrDefaultAsync(x => x.Id == id);
            if (existinglevel == null)
            {
                return null;
            }
            marathonDbContext.Levels.Remove(existinglevel);
            await marathonDbContext.SaveChangesAsync();
            return existinglevel;
        }

        public async Task<List<Level>> GetAllLevels()
        {
           return await marathonDbContext.Levels.ToListAsync();
        }

        public async Task<Level?> GetLevelById(int id)
        {
            return await marathonDbContext.Levels.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
