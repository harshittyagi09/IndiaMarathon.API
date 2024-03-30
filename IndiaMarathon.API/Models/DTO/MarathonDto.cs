using IndiaMarathon.API.Models.Domain;

namespace IndiaMarathon.API.Models.DTO
{
    public class MarathonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double length { get; set; }
        public string? ImageUrl { get; set; }        
        public State State { get; set; }
        public Level Level { get; set; }

    }
}
