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

        public async Task<State> CreateState(State state)
        {
            await marathonDbContext.AddAsync(state);
            await marathonDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<State?> DeleteState(int id)
        {
            var exisitinregion=await marathonDbContext.States.FirstOrDefaultAsync(s => s.Id == id); 
            if (exisitinregion == null)
            {
                return null;
            }
            marathonDbContext.States.Remove(exisitinregion);
            await marathonDbContext.SaveChangesAsync();
            return exisitinregion;
        }

        public async Task<State?> GetById(int id)
        {
            return await marathonDbContext.States.FirstOrDefaultAsync(s => s.Id == id); 
        }

        public async Task<List<State>> GetStates()
        {
           return await marathonDbContext.States.ToListAsync();
        }

        public async Task<State?> UpdateState(int id, State state)
        {
          var existingState= await marathonDbContext.States.FirstOrDefaultAsync(x=>x.Id == id);
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
