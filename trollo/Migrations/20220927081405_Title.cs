using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trollo.Migrations
{
    public partial class Title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Title",
            table: "Todo",
            nullable: true);

            migrationBuilder.Sql(
            @"
             UPDATE Todo
                SET Title = Category || ':' || Name;
             ");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todo");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todo",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todo",
                type: "TEXT",
                nullable: true);
        }
    }
}
