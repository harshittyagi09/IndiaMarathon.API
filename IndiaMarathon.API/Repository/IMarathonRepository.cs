using IndiaMarathon.API.Models.Domain;

namespace IndiaMarathon.API.Repository
{
    public interface IMarathonRepository
    {
        Task<Marathon>InsertMarathon(Marathon marathon);
        Task<List<Marathon>> GetAllMarathons();
        Task<Marathon?>GerMarathonById(int id);
        Task<Marathon?>UpdateMarathon(int id, Marathon marathon);
        Task<Marathon?>RemoveMarathon(int id);
    }
}
