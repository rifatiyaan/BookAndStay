using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAndStay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoomToDbWithCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Description", "ImageUrl", "Occupancy", "Price", "RoomType", "Updated" },
                values: new object[,]
                {
                    { 1, null, "A basic accommodation option with essential amenities. Standard rooms are usually more affordable and cater to guests looking for a comfortable yet budget-friendly stay.", "aa", 2, 100.0, "Standard Room", null },
                    { 2, null, "An upgraded and more spacious room category compared to the standard room. Deluxe rooms often feature larger beds, higher-quality furnishings, and additional amenities for enhanced comfort. Guests choosing a deluxe room can enjoy a more luxurious experience without opting for a full suite.", "aa", 2, 300.0, "Deluxe Room", null },
                    { 3, null, "A suite is a larger and more luxurious accommodation option that goes beyond the features of a standard or deluxe room. It usually consists of a separate living area and bedroom, providing more space for relaxation and work. Suites may include additional amenities such as a mini-kitchen, dining area, and upgraded in-room facilities.", "aa", 2, 100.0, "Suit", null },
                    { 4, null, "The VIP Suite represents the pinnacle of luxury in a hotel.It is designed for high - profile guests, celebrities, or those seeking an exclusive and opulent experience.VIP Suites often feature a spacious living room, a master bedroom, a dining area, and may include special services such as a personal concierge.These suites are characterized by top - notch amenities, premium furnishings, and a high level of privacy.", "aa", 2, 100.0, "VIP Suite", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Room_Number", "Room_ID", "SpecialDetails" },
                values: new object[,]
                {
                    { 101, 1, null },
                    { 102, 2, null },
                    { 103, 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
