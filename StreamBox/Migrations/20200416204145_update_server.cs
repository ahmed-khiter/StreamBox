using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamBox.Migrations
{
    public partial class update_server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamName",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "ServerIP",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SudoPassword",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SudoUsername",
                table: "Servers");

            migrationBuilder.AddColumn<int>(
                name: "BouquetId",
                table: "Streams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Streams",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HTTPPort",
                table: "Servers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HTTPSPort",
                table: "Servers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "Servers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRTMP",
                table: "Servers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Servers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RTMPPort",
                table: "Servers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RootPassword",
                table: "Servers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SSHPort",
                table: "Servers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StreamId",
                table: "Servers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bouquets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bouquets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streams_BouquetId",
                table: "Streams",
                column: "BouquetId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_StreamId",
                table: "Servers",
                column: "StreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_Streams_StreamId",
                table: "Servers",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Bouquets_BouquetId",
                table: "Streams",
                column: "BouquetId",
                principalTable: "Bouquets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_Streams_StreamId",
                table: "Servers");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Bouquets_BouquetId",
                table: "Streams");

            migrationBuilder.DropTable(
                name: "Bouquets");

            migrationBuilder.DropIndex(
                name: "IX_Streams_BouquetId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Servers_StreamId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "BouquetId",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "HTTPPort",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "HTTPSPort",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IsRTMP",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "RTMPPort",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "RootPassword",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SSHPort",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "StreamId",
                table: "Servers");

            migrationBuilder.AddColumn<string>(
                name: "StreamName",
                table: "Streams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerIP",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServerName",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SudoPassword",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SudoUsername",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
