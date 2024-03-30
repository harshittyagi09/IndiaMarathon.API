using IndiaMarathon.API.Models.Domain;

namespace IndiaMarathon.API.Repository
{
    public interface IStateRepository
    {
        Task<List<State>>GetStates();
        Task<State?> GetById(int id);
        Task<State>CreateState(State state);
        Task<State?> UpdateState(int id,State state);
        Task<State?> DeleteState(int id);

    }
}
