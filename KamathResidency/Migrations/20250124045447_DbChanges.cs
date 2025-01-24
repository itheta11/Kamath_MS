using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamathResidency.Migrations
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_user_id",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_Association_Booking_BookingId",
                table: "Booking_Room_Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_Association_Room_RoomId",
                table: "Booking_Room_Association");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone_Number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Id_Proof",
                table: "Users",
                newName: "IdProof");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "Rooms",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "room_type",
                table: "Rooms",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "is_ac",
                table: "Rooms",
                newName: "IsAc");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Rooms",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "total_bill",
                table: "Bookings",
                newName: "TotalBill");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "Bookings",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Bookings",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "check_out",
                table: "Bookings",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "check_in",
                table: "Bookings",
                newName: "CheckIn");

            migrationBuilder.RenameColumn(
                name: "advance_amount",
                table: "Bookings",
                newName: "AdvanceAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_user_id",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValueSql: "lower(hex(randomblob(16)))");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "NUMERIC",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(byte[]),
                oldType: "DATETIME",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "RoomType",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAc",
                table: "Rooms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BOOLEAN",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(byte[]),
                oldType: "DATETIME",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValueSql: "lower(hex(randomblob(16)))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(byte[]),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(byte[]),
                oldType: "DATETIME",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckIn",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "DATETIME");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_Association_Bookings_BookingId",
                table: "Booking_Room_Association",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_Association_Rooms_RoomId",
                table: "Booking_Room_Association",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_Association_Bookings_BookingId",
                table: "Booking_Room_Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_Association_Rooms_RoomId",
                table: "Booking_Room_Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "User",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "User",
                newName: "phone_Number");

            migrationBuilder.RenameColumn(
                name: "IdProof",
                table: "User",
                newName: "Id_Proof");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Room",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Room",
                newName: "room_type");

            migrationBuilder.RenameColumn(
                name: "IsAc",
                table: "Room",
                newName: "is_ac");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Room",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Booking",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Booking",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TotalBill",
                table: "Booking",
                newName: "total_bill");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Booking",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Booking",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Booking",
                newName: "check_out");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Booking",
                newName: "check_in");

            migrationBuilder.RenameColumn(
                name: "AdvanceAmount",
                table: "Booking",
                newName: "advance_amount");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "Booking",
                newName: "IX_Booking_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "lower(hex(randomblob(16)))",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "phone_Number",
                table: "User",
                type: "NUMERIC",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "created_at",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "room_type",
                table: "Room",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "is_ac",
                table: "Room",
                type: "BOOLEAN",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "created_at",
                table: "Room",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "lower(hex(randomblob(16)))",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "modified_at",
                table: "Booking",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<byte[]>(
                name: "created_at",
                table: "Booking",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<byte[]>(
                name: "check_out",
                table: "Booking",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "check_in",
                table: "Booking",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_user_id",
                table: "Booking",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_Association_Booking_BookingId",
                table: "Booking_Room_Association",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_Association_Room_RoomId",
                table: "Booking_Room_Association",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "id");
        }
    }
}
