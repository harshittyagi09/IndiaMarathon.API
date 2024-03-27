using IndiaMarathon.API.Data;
using IndiaMarathon.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace IndiaMarathon.API.Repository
{
    public class SQLStatesRepository:IStateRepository
    {
        private readonly MarathonDbContext marathonDbContext;

        public SQLStatesRepository(MarathonDbContext marathonDbContext) 
        { 
           this.marathonDbContext=marathonDbContext;

        }

        public async Task<States> CreateState(States state)
        {
            await marathonDbContext.AddAsync(state);
            await marathonDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<States?> DeleteState(int id)
        {
            var exisitinregion=await marathonDbContext.states.FirstOrDefaultAsync(s => s.Id == id); 
            if (exisitinregion == null)
            {
                return null;
            }
            marathonDbContext.states.Remove(exisitinregion);
            await marathonDbContext.SaveChangesAsync();
            return exisitinregion;
        }

        public async Task<States?> GetById(int id)
        {
            return await marathonDbContext.states.FirstOrDefaultAsync(s => s.Id == id); 
        }

        public async Task<List<States>> GetStates()
        {
           return await marathonDbContext.states.ToListAsync();
        }

        public async Task<States?> UpdateState(int id, States state)
        {
          var existingState= await marathonDbContext.states.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingState == null)
            {
                return null;
            }

            existingState.Name = state.Name;
            existingState.Description = state.Description;
            existingState.StateImageUrl = state.StateImageUrl;

            await marathonDbContext.SaveChangesAsync();
            return existingState;
        }
    }
}
