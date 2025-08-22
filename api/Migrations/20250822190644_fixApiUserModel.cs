using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class fixApiUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "Factor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factor_ApiUserId",
                table: "Factor",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factor_AspNetUsers_ApiUserId",
                table: "Factor",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
