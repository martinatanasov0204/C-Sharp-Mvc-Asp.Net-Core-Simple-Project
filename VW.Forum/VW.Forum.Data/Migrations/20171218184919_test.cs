using Microsoft.EntityFrameworkCore.Migrations;

namespace VW.Forum.Data.Migrations
{
	public partial class test : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "Cars");

			migrationBuilder.DropTable(
				name: "Comments");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "Posts");

			migrationBuilder.DropTable(
				name: "AspNetUsers");
		}
	}
}
