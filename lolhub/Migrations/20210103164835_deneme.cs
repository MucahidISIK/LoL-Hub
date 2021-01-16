using Microsoft.EntityFrameworkCore.Migrations;

namespace lolhub.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paylasimlar",
                columns: table => new
                {
                    PaylasimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paylasimlar", x => x.PaylasimID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paylasimlar");
        }
    }
}
