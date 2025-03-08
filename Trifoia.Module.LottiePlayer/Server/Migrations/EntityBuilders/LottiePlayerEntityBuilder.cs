using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Trifoia.Module.LottiePlayer.Migrations.EntityBuilders
{
    public class LottiePlayerEntityBuilder : AuditableBaseEntityBuilder<LottiePlayerEntityBuilder>
    {
        private const string _entityTableName = "TrifoiaLottiePlayer";
        private readonly PrimaryKey<LottiePlayerEntityBuilder> _primaryKey = new("PK_TrifoiaLottiePlayer", x => x.LottiePlayerId);
        private readonly ForeignKey<LottiePlayerEntityBuilder> _moduleForeignKey = new("FK_TrifoiaLottiePlayer_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public LottiePlayerEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override LottiePlayerEntityBuilder BuildTable(ColumnsBuilder table)
        {
            LottiePlayerId = AddAutoIncrementColumn(table,"LottiePlayerId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> LottiePlayerId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
