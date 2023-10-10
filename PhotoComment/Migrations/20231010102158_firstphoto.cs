using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoComment.Migrations
{
    /// <inheritdoc />
    public partial class firstphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_PhotoId",
                table: "comment",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "photo");
        }
    }
}
