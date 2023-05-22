using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpDal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWith1to1Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorExperiments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ButtonColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperimentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorExperiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorExperiments_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceExperiments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<byte>(type: "tinyint", nullable: false),
                    ExperimentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceExperiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceExperiments_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorExperiments_DeviceId",
                table: "ColorExperiments",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceToken",
                table: "Devices",
                column: "DeviceToken",
                unique: true,
                filter: "[DeviceToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceExperiments_DeviceId",
                table: "PriceExperiments",
                column: "DeviceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorExperiments");

            migrationBuilder.DropTable(
                name: "PriceExperiments");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
