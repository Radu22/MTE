using Microsoft.EntityFrameworkCore;
using _1_Entity.Model;
using _2_Persistency.Contracts;

namespace _4_Persistency.Mappings.EntityMappings
{
    public class ProfessorMapping : IEntityMapping
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasKey(p => p.Id);
        }
    }
}
