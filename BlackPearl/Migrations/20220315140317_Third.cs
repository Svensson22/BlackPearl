using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackPearl.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pearls",
                table: "Pearls");

            migrationBuilder.AlterColumn<int>(
                name: "NecklaceID",
                table: "Pearls",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pearls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pearls",
                table: "Pearls",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pearls",
                table: "Pearls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pearls");

            migrationBuilder.AlterColumn<int>(
                name: "NecklaceID",
                table: "Pearls",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pearls",
                table: "Pearls",
                column: "NecklaceID");
        }
    }
}
