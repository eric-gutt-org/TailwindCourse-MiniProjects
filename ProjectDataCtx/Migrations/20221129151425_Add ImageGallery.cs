using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDataCtx.Migrations
{
    /// <inheritdoc />
    public partial class AddImageGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageGalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageGalleryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageGalleryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageGalleryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageGalleryPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageGalleryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
