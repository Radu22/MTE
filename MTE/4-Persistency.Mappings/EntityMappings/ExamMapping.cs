using Microsoft.EntityFrameworkCore;
using _1_Entity.Model;
using _2_Persistency.Contracts;

namespace _4_Persistency.Mappings.EntityMappings
{
    public class ExamMapping : IEntityMapping
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Exam>()
                .HasOne(p => p.Professor)
                .WithOne(e => e.Exam)
                .HasForeignKey<Exam>(p => p.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
