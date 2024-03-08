using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_store.Migrations
{
    public partial class UpdateAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Album");
        }
    }
}
