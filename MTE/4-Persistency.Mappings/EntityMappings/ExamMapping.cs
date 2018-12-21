using Microsoft.EntityFrameworkCore;
using _1_Entity.Model;
using _2_Persistency.Contracts;

namespace _4_Persistency.Mappings.EntityMappings
{
    public class ExamMapping : IEntityMapping
    {
        public void Map(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Exam>()
            //    .HasKey(e => e.Id);

            //modelBuilder.Entity<Exam>()
            //    .HasMany(s => s.Students)
            //    .WithOne(e => e.Exam);
        }
    }
}
