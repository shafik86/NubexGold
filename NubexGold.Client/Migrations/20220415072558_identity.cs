using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NubexGold.Client.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6797), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6810), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6819), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6826), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6833), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6842), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6849), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6857), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6865), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6873), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6903), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6913), new DateTime(2022, 4, 15, 15, 25, 58, 685, DateTimeKind.Local).AddTicks(6913) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(964), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(977), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(977) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(985), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(994), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1002), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1004) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1012), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1020), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1029), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1037), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1046), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1084), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1094), new DateTime(2022, 4, 12, 16, 35, 45, 927, DateTimeKind.Local).AddTicks(1094) });
        }
    }
}
