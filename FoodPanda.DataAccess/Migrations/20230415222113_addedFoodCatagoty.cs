using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodPanda.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedFoodCatagoty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCatagorys",
                columns: table => new
                {
                    FoodCatagoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCatagoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCatagorys", x => x.FoodCatagoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCatagorys");
        }
    }
}
