using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Testimonials");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "AboutID");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdultCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Testimonials");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "About");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Testimonials",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Image",
                table: "Testimonials",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "Testimonials",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Ttitle",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "AboutID");
        }
    }
}
