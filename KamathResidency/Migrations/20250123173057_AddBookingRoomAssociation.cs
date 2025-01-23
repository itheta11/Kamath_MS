using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamathResidency.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingRoomAssociation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createdat = table.Column<byte[]>(name: "created_at", type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    floor = table.Column<long>(type: "INTEGER", nullable: true),
                    roomtype = table.Column<string>(name: "room_type", type: "TEXT", nullable: true),
                    isac = table.Column<byte[]>(name: "is_ac", type: "BOOLEAN", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "lower(hex(randomblob(16)))"),
                    createdat = table.Column<byte[]>(name: "created_at", type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<byte[]>(name: "phone_Number", type: "NUMERIC", nullable: true),
                    IdProof = table.Column<string>(name: "Id_Proof", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "lower(hex(randomblob(16)))"),
                    createdat = table.Column<byte[]>(name: "created_at", type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modifiedat = table.Column<byte[]>(name: "modified_at", type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    userid = table.Column<string>(name: "user_id", type: "TEXT", nullable: false),
                    checkin = table.Column<byte[]>(name: "check_in", type: "DATETIME", nullable: false),
                    checkout = table.Column<byte[]>(name: "check_out", type: "DATETIME", nullable: false),
                    totalbill = table.Column<double>(name: "total_bill", type: "REAL", nullable: false),
                    advanceamount = table.Column<double>(name: "advance_amount", type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_User_user_id",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Booking_Room_Association",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "TEXT", nullable: false),
                    RoomId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Room_Association", x => new { x.BookingId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_Booking_Room_Association_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Booking_Room_Association_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_user_id",
                table: "Booking",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Room_Association_RoomId",
                table: "Booking_Room_Association",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Room_Association");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
