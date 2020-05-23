using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Database.Context
{
    public partial class MealSaverContext : DbContext
    {
        public MealSaverContext(DbContextOptions<MealSaverContext> options)
            : base(options) {}

        //Entity Table
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Aliment> Aliment { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }

        //ASsociation Table
        public virtual DbSet<MealXAliment> MealXAliment { get; set; }
    }
}
