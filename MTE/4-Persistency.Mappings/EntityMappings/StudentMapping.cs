using Microsoft.EntityFrameworkCore;
using _1_Entity.Model;
using _2_Persistency.Contracts;

namespace _4_Persistency.Mappings.EntityMappings
{
    public class StudentMapping : IEntityMapping
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            //modelBuilder.Entity<Student>()
            //    .HasOne(e => e.Exam)
            //    .WithMany(s => s.Students)
            //    .HasForeignKey(s => s.ExamId);
        }
    }
}
