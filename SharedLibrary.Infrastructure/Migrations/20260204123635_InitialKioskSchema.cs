using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialKioskSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvKioskDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvKioskDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvKioskSessionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserActiveCount = table.Column<int>(type: "int", nullable: false),
                    UserLastSession = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskSessionUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvKioskLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KioskId = table.Column<int>(type: "int", nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvKioskLanguage_InvKioskDetail_KioskId",
                        column: x => x.KioskId,
                        principalTable: "InvKioskDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvKioskService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KioskId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvKioskDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvKioskService_InvKioskDetail_InvKioskDetailId",
                        column: x => x.InvKioskDetailId,
                        principalTable: "InvKioskDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvKioskTrackingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KioskId = table.Column<int>(type: "int", nullable: false),
                    SessionUserId = table.Column<int>(type: "int", nullable: false),
                    KioskServiceId = table.Column<int>(type: "int", nullable: true),
                    SessionStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionActivity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvKioskTrackingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvKioskTrackingDetail_InvKioskDetail_KioskId",
                        column: x => x.KioskId,
                        principalTable: "InvKioskDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvKioskTrackingDetail_InvKioskService_KioskServiceId",
                        column: x => x.KioskServiceId,
                        principalTable: "InvKioskService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvKioskTrackingDetail_InvKioskSessionUser_SessionUserId",
                        column: x => x.SessionUserId,
                        principalTable: "InvKioskSessionUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvKioskLanguage_KioskId",
                table: "InvKioskLanguage",
                column: "KioskId");

            migrationBuilder.CreateIndex(
                name: "IX_InvKioskService_InvKioskDetailId",
                table: "InvKioskService",
                column: "InvKioskDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvKioskTrackingDetail_KioskId",
                table: "InvKioskTrackingDetail",
                column: "KioskId");

            migrationBuilder.CreateIndex(
                name: "IX_InvKioskTrackingDetail_KioskServiceId",
                table: "InvKioskTrackingDetail",
                column: "KioskServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvKioskTrackingDetail_SessionUserId",
                table: "InvKioskTrackingDetail",
                column: "SessionUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvKioskDepartment");

            migrationBuilder.DropTable(
                name: "InvKioskLanguage");

            migrationBuilder.DropTable(
                name: "InvKioskTrackingDetail");

            migrationBuilder.DropTable(
                name: "InvKioskService");

            migrationBuilder.DropTable(
                name: "InvKioskSessionUser");

            migrationBuilder.DropTable(
                name: "InvKioskDetail");
        }
    }
}
