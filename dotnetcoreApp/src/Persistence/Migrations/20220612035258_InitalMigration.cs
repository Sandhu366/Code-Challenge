using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upvotes = table.Column<int>(type: "int", nullable: false),
                    Downvotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoutId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remarks_Shouts_ShoutId",
                        column: x => x.ShoutId,
                        principalTable: "Shouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shouts",
                columns: new[] { "Id", "Body", "Downvotes", "Upvotes" },
                values: new object[] { 1, "Shout out loud!", 2000, 5000 });

            migrationBuilder.InsertData(
                table: "Shouts",
                columns: new[] { "Id", "Body", "Downvotes", "Upvotes" },
                values: new object[] { 2, "Winter is coming!", 120, 1200 });

            migrationBuilder.InsertData(
                table: "Remarks",
                columns: new[] { "Id", "Body", "ShoutId" },
                values: new object[,]
                {
                    { 1, "Let's do it", 1 },
                    { 2, "Yay!!!!!!", 1 },
                    { 3, "NAY!!!!!!!!!", 1 },
                    { 4, "Let's go to night watch!", 2 },
                    { 5, "You know nothing John snow!", 2 },
                    { 6, "King in the north!", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_ShoutId",
                table: "Remarks",
                column: "ShoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remarks");

            migrationBuilder.DropTable(
                name: "Shouts");
        }
    }
}
