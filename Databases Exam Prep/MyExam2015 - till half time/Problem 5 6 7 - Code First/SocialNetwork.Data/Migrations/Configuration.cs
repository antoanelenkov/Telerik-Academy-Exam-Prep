namespace SocialNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetwork.Data.SocialNetworkDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SocialNetwork.Data.SocialNetworkDbContext context)
        {
        }
    }
}
