using IndiaMarathon.API.Models.Domain;

namespace IndiaMarathon.API.Repository
{
    public interface ILevelRepository
    {
        Task<Level>CreateLevel(Level level);
        Task<List<Level>>GetAllLevels();
        Task<Level?> GetLevelById(int id);
        Task<Level?> DeleteLevel(int id);
    }
}
