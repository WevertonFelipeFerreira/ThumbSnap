using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThumbSnap.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedtimefieldtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "VideoInformations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "StoryboardSnaps",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "VideoInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "StoryboardSnaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
