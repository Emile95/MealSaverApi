using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Database.Context
{
    public partial class MealSaverContext : DbContext
    {
        public MealSaverContext(DbContextOptions<MealSaverContext> options)
            : base(options) {}

        //Normal Table
        public virtual DbSet<Account> Account { get; set; }
    }
}
