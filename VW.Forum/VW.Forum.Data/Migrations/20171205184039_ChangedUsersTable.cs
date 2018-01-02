using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VW.Forum.Data.Migrations
{
	public partial class ChangedUsersTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "BirthDate",
				table: "AspNetUsers",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<DateTime>(
				name: "DateOfRegister",
				table: "AspNetUsers",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "Name",
				table: "AspNetUsers",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Password",
				table: "AspNetUsers",
				nullable: true);
		}
	}
}
