using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Database.Context
{
    public partial class VimoContext : DbContext
    {
        public VimoContext(DbContextOptions<VimoContext> options)
            : base(options) {}

        //Normal Table
        public virtual DbSet<Account> Account { get; set; }
    }
}
