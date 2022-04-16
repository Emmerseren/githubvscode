using Microsoft.EntityFrameworkCore;

namespace HåndværkerCase.Models
{
    public class DnDContext : DbContext
    {
       public DnDContext(DbContextOptions<DnDContext> options) : base(options)  {  }

        public DbSet<Case> cases => Set<Case>();

        public DbSet<Beskrivelse> beskrivelser => Set<Beskrivelse>();
    }
}
