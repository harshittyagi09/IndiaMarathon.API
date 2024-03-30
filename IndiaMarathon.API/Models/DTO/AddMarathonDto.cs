namespace IndiaMarathon.API.Models.DTO
{
    public class AddMarathonDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double length { get; set; }
        public string? ImageUrl { get; set; }
        public int LevelId { get; set; }
        public int StateId { get; set; }
    }
}
