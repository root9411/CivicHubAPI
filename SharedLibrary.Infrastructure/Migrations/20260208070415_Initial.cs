using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultConfig = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                });

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
                name: "InvPages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvPages", x => x.PageId);
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
                name: "PageSections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    SectionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CssClass = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_PageSections_InvPages_PageId",
                        column: x => x.PageId,
                        principalTable: "InvPages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "SectionComponents",
                columns: table => new
                {
                    SectionComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionComponents", x => x.SectionComponentId);
                    table.ForeignKey(
                        name: "FK_SectionComponents_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionComponents_PageSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "PageSections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentContent",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionComponentId = table.Column<int>(type: "int", nullable: false),
                    ContentKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContentValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentContent", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_ComponentContent_SectionComponents_SectionComponentId",
                        column: x => x.SectionComponentId,
                        principalTable: "SectionComponents",
                        principalColumn: "SectionComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentContent_SectionComponentId",
                table: "ComponentContent",
                column: "SectionComponentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InvPages_PageKey",
                table: "InvPages",
                column: "PageKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_PageId",
                table: "PageSections",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionComponents_ComponentId",
                table: "SectionComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionComponents_SectionId",
                table: "SectionComponents",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentContent");

            migrationBuilder.DropTable(
                name: "InvKioskDepartment");

            migrationBuilder.DropTable(
                name: "InvKioskLanguage");

            migrationBuilder.DropTable(
                name: "InvKioskTrackingDetail");

            migrationBuilder.DropTable(
                name: "SectionComponents");

            migrationBuilder.DropTable(
                name: "InvKioskService");

            migrationBuilder.DropTable(
                name: "InvKioskSessionUser");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "InvKioskDetail");

            migrationBuilder.DropTable(
                name: "InvPages");
        }
    }
}
