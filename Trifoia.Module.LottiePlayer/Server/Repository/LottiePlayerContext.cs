using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Trifoia.Module.LottiePlayer.Repository
{
    public class LottiePlayerContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.LottiePlayer> LottiePlayer { get; set; }

        public LottiePlayerContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.LottiePlayer>().ToTable(ActiveDatabase.RewriteName("TrifoiaLottiePlayer"));
        }
    }
}
