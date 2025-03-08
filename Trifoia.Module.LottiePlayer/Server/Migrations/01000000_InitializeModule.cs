using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Trifoia.Module.LottiePlayer.Migrations.EntityBuilders;
using Trifoia.Module.LottiePlayer.Repository;

namespace Trifoia.Module.LottiePlayer.Migrations
{
    [DbContext(typeof(LottiePlayerContext))]
    [Migration("Trifoia.Module.LottiePlayer.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new LottiePlayerEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new LottiePlayerEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
