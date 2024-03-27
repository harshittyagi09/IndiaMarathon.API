using IndiaMarathon.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaMarathon.API.Data
{
    public class MarathonDbContext: DbContext
    {
        public MarathonDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) 
        {

        }
       
        public DbSet<Level> Levels { get; set; }
        public DbSet<States> states { get; set; }
        public DbSet<Marathon> Marathons { get; set; }
    }
}
