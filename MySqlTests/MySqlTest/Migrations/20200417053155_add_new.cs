using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlTest.Migrations
{
    public partial class add_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "robots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RobotCode = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: true),
                    ExtraProperties = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    RobotStatus = table.Column<int>(nullable: false),
                    RobotType = table.Column<int>(nullable: false),
                    LastCommTime = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    DomainUsers = table.Column<string>(nullable: true),
                    MachineCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_robots", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "robots");
        }
    }
}
