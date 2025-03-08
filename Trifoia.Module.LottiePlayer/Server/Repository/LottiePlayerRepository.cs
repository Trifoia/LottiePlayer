using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;

namespace Trifoia.Module.LottiePlayer.Repository
{
    public class LottiePlayerRepository : ITransientService
    {
        private readonly IDbContextFactory<LottiePlayerContext> _factory;

        public LottiePlayerRepository(IDbContextFactory<LottiePlayerContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.LottiePlayer> GetLottiePlayers()
        {
            using var db = _factory.CreateDbContext();
            return db.LottiePlayer.ToList();
        }

        public Models.LottiePlayer GetLottiePlayer(int LottiePlayerId)
        {
            return GetLottiePlayer(LottiePlayerId, true);
        }

        public Models.LottiePlayer GetLottiePlayer(int LottiePlayerId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.LottiePlayer.Find(LottiePlayerId);
            }
            else
            {
                return db.LottiePlayer.AsNoTracking().FirstOrDefault(item => item.LottiePlayerId == LottiePlayerId);
            }
        }

        public Models.LottiePlayer AddLottiePlayer(Models.LottiePlayer item)
        {
            using var db = _factory.CreateDbContext();
            db.LottiePlayer.Add(item);
            db.SaveChanges();
            return item;
        }

        public Models.LottiePlayer UpdateLottiePlayer(Models.LottiePlayer item)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void DeleteLottiePlayer(int LottiePlayerId)
        {
            using var db = _factory.CreateDbContext();
            var item = db.LottiePlayer.Find(LottiePlayerId);
            db.LottiePlayer.Remove(item);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.LottiePlayer>> GetLottiePlayersAsync(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return await db.LottiePlayer.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.LottiePlayer> GetLottiePlayerAsync(int LottiePlayerId)
        {
            return await GetLottiePlayerAsync(LottiePlayerId, true);
        }

        public async Task<Models.LottiePlayer> GetLottiePlayerAsync(int LottiePlayerId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.LottiePlayer.FindAsync(LottiePlayerId);
            }
            else
            {
                return await db.LottiePlayer.AsNoTracking().FirstOrDefaultAsync(item => item.LottiePlayerId == LottiePlayerId);
            }
        }

        public async Task<Models.LottiePlayer> AddLottiePlayerAsync(Models.LottiePlayer item)
        {
            using var db = _factory.CreateDbContext();
            db.LottiePlayer.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<Models.LottiePlayer> UpdateLottiePlayerAsync(Models.LottiePlayer item)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteLottiePlayerAsync(int LottiePlayerId)
        {
            using var db = _factory.CreateDbContext();
           var item = db.LottiePlayer.Find(LottiePlayerId);
            db.LottiePlayer.Remove(item);
            await db.SaveChangesAsync();
        }
    }
}
