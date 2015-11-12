namespace SocialNetwork.Data
{
    using Models;
    using Migrations;
    using System.Data.Entity;

    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext() : base("SocialNetwork")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public DbSet<UserProfile> Profiles { get; set; }

        public DbSet<FriendShip> FriendShips { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post>    Posts { get; set; }
    }
}
