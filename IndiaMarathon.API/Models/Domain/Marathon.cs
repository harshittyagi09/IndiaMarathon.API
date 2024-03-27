namespace IndiaMarathon.API.Models.Domain
{
    public class Marathon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double length { get; set; }
        public string? ImageUrl { get; set; }
        public int LevelId {  get; set; }
        public int StateId {  get; set; }

        public States States { get; set; }
        public Level Level { get; set; }



    }
}
