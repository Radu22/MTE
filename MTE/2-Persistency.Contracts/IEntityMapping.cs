using Microsoft.EntityFrameworkCore;

namespace _2_Persistency.Contracts
{
    public interface IEntityMapping
    {
        void Map(ModelBuilder modelBuilder);
    }
}
