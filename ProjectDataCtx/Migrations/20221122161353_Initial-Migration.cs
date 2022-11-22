using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDataCtx.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectData",
                columns: table => new
                {
                    ProjectDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectData", x => x.ProjectDataId);
                });

            migrationBuilder.CreateTable(
                name: "DataDetails",
                columns: table => new
                {
                    DataDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDetails", x => x.DataDetailsId);
                    table.ForeignKey(
                        name: "FK_DataDetails_ProjectData_ProjectDataId",
                        column: x => x.ProjectDataId,
                        principalTable: "ProjectData",
                        principalColumn: "ProjectDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataDetails_ProjectDataId",
                table: "DataDetails",
                column: "ProjectDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDetails");

            migrationBuilder.DropTable(
                name: "ProjectData");
        }
    }
}
