using IndiaMarathon.API.Data;
using IndiaMarathon.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaMarathon.API.Repository
{
    public class SQLMarathonRepository : IMarathonRepository
    {
        private readonly MarathonDbContext marathonDbContext;

        public SQLMarathonRepository(MarathonDbContext marathonDbContext)
        {
            this.marathonDbContext = marathonDbContext;
        }

        public async Task<Marathon?> GerMarathonById(int id)
        {
           return await marathonDbContext.Marathons.Include("Level").Include("State").FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Marathon>> GetAllMarathons()
        {
            return await marathonDbContext.Marathons.Include("Level").Include("State").ToListAsync();
        }

        public async Task<Marathon> InsertMarathon(Marathon marathon)
        {
            await marathonDbContext.Marathons.AddAsync(marathon);
            await marathonDbContext.SaveChangesAsync(); 
            return marathon;
        }

        public async Task<Marathon?> RemoveMarathon(int id)
        {
            var existingmarathon = await marathonDbContext.Marathons.FirstOrDefaultAsync(x => x.Id == id);
            if (existingmarathon == null)
            {
                return null;
            }
            marathonDbContext.Marathons.Remove(existingmarathon);
            await marathonDbContext.SaveChangesAsync();
            return existingmarathon;
        }

        public async Task<Marathon?> UpdateMarathon(int id, Marathon marathon)
        {
            var existingmarathon= await marathonDbContext.Marathons.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingmarathon == null)
            {
                return null;
            }
            existingmarathon.Name = marathon.Name;
            existingmarathon.Description = marathon.Description;
            existingmarathon.length = marathon.length;
            existingmarathon.ImageUrl = marathon.ImageUrl;
            existingmarathon.LevelId = marathon.LevelId;
            existingmarathon.StateId = marathon.StateId;

            await marathonDbContext.SaveChangesAsync();
            return existingmarathon;
        }
    }
}
