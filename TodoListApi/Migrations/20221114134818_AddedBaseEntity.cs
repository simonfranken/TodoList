using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListApi.Migrations
{
    public partial class AddedBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "TodoEntries",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TodoEntries",
                newName: "EntryId");
        }
    }
}
