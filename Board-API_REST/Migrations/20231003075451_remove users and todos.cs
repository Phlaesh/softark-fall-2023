using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    public partial class removeusersandtodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_UserId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Todo");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_UserId",
                table: "Todo",
                newName: "IX_Todo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_BoardId",
                table: "Todo",
                newName: "IX_Todo_BoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Boards_BoardId",
                table: "Todo",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_User_UserId",
                table: "Todo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Boards_BoardId",
                table: "Todo");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_User_UserId",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Todos");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_UserId",
                table: "Todos",
                newName: "IX_Todos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_BoardId",
                table: "Todos",
                newName: "IX_Todos_BoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_UserId",
                table: "Todos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
