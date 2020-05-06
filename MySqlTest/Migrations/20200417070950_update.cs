using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlTest.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("1d91ee3e-b579-4cd6-b80c-377acb9351cd"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("1e6cc4f4-f5dc-4879-af60-b00a5a1eaa94"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("251138eb-8812-47c0-a94b-f827deb6887d"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("2901ec87-685c-4d17-8a94-d30c74bb4722"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("333da21b-41c8-4f0c-83d9-d914634130cd"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("75b6f572-7160-4c0f-b728-e4e4aa35bc0b"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("9a3c099b-fc48-4ab9-8654-56ce2a622a3f"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("9e5da601-5787-4025-a9ea-53e9da6fbce9"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("c54b7bee-a577-4f6f-974a-098a870f3ad5"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("e03a655d-8733-4f96-a207-acfb788bcae4"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("edb08a8f-9106-474b-8b65-274894d6e634"));

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "robots",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineCode",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExtraProperties",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DomainUsers",
                table: "robots",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "robots",
                columns: new[] { "Id", "CreationTime", "DomainUsers", "ExtraProperties", "GroupId", "IsDeleted", "LastCommTime", "MachineCode", "Name", "Remark", "RobotCode", "RobotStatus", "RobotType", "Tags", "TenantId", "Version" },
                values: new object[,]
                {
                    { new Guid("d65a9ac4-4402-4efa-8eaa-719be83245dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aabb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("545f25c3-53ad-419a-bbf3-f58b81c2e967"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AABB", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("86c637ca-9133-4e99-9e5b-b9ffbf64c977"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AaBb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("3a3031a5-1463-4046-b063-cf065137e77b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aAbB", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("f9f32fc0-af52-411e-8632-ceea7a635def"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bbcc", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("4173a770-cf04-426f-867d-294291e5d622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "zxcv", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("553d394e-9cde-4843-8c27-c21b81cd08bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("654b30ac-d038-4ad1-9955-22de3a154942"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰11", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("0bd64f72-a375-4684-af4b-27c010d4e74d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰阿阿不", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("9e119488-468f-4217-928a-2ab4415d9e9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰aabb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("c502001c-e99b-4467-8013-9cd581f7397c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰cccccc", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("0bd64f72-a375-4684-af4b-27c010d4e74d"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("3a3031a5-1463-4046-b063-cf065137e77b"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("4173a770-cf04-426f-867d-294291e5d622"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("545f25c3-53ad-419a-bbf3-f58b81c2e967"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("553d394e-9cde-4843-8c27-c21b81cd08bb"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("654b30ac-d038-4ad1-9955-22de3a154942"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("86c637ca-9133-4e99-9e5b-b9ffbf64c977"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("9e119488-468f-4217-928a-2ab4415d9e9c"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("c502001c-e99b-4467-8013-9cd581f7397c"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("d65a9ac4-4402-4efa-8eaa-719be83245dd"));

            migrationBuilder.DeleteData(
                table: "robots",
                keyColumn: "Id",
                keyValue: new Guid("f9f32fc0-af52-411e-8632-ceea7a635def"));

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineCode",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExtraProperties",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DomainUsers",
                table: "robots",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "robots",
                columns: new[] { "Id", "CreationTime", "DomainUsers", "ExtraProperties", "GroupId", "IsDeleted", "LastCommTime", "MachineCode", "Name", "Remark", "RobotCode", "RobotStatus", "RobotType", "Tags", "TenantId", "Version" },
                values: new object[,]
                {
                    { new Guid("75b6f572-7160-4c0f-b728-e4e4aa35bc0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aabb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("1e6cc4f4-f5dc-4879-af60-b00a5a1eaa94"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AABB", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("1d91ee3e-b579-4cd6-b80c-377acb9351cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AaBb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("9e5da601-5787-4025-a9ea-53e9da6fbce9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aAbB", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("333da21b-41c8-4f0c-83d9-d914634130cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bbcc", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("2901ec87-685c-4d17-8a94-d30c74bb4722"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "zxcv", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("9a3c099b-fc48-4ab9-8654-56ce2a622a3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("251138eb-8812-47c0-a94b-f827deb6887d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰11", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("edb08a8f-9106-474b-8b65-274894d6e634"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰阿阿不", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("e03a655d-8733-4f96-a207-acfb788bcae4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰aabb", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null },
                    { new Guid("c54b7bee-a577-4f6f-974a-098a870f3ad5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "朱峰cccccc", null, new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, null, null, null }
                });
        }
    }
}
