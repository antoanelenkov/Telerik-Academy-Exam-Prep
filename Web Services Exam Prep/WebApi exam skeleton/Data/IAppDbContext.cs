using Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public interface IAppDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Game> Games { get; set; }

        IDbSet<Score> Scores { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Guess> Guesses { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
