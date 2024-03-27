using IndiaMarathon.API.Models.Domain;

namespace IndiaMarathon.API.Repository
{
    public interface IStateRepository
    {
        Task<List<States>>GetStates();
        Task<States?> GetById(int id);
        Task<States>CreateState(States state);
        Task<States?> UpdateState(int id,States state);
        Task<States?> DeleteState(int id);

    }
}
