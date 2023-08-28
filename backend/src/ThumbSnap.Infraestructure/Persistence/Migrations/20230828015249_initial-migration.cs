using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThumbSnap.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    SnapWidth = table.Column<int>(type: "int", nullable: false),
                    SnapHeight = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    SnapTakenEverySeconds = table.Column<int>(type: "int", nullable: false),
                    RejectionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryboardProcessingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoryboardSnaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryboardSnaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryboardSnaps_VideoInformations_VideoId",
                        column: x => x.VideoId,
                        principalTable: "VideoInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryboardSnaps_VideoId",
                table: "StoryboardSnaps",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryboardSnaps");

            migrationBuilder.DropTable(
                name: "VideoInformations");
        }
    }
}
