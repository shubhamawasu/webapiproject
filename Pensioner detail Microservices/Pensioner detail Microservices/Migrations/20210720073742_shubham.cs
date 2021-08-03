using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensioner_detail_Microservices.Migrations
{
    public partial class shubham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pensioners",
                columns: table => new
                {
                    PAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryEarned = table.Column<int>(type: "int", nullable: false),
                    Allowances = table.Column<int>(type: "int", nullable: false),
                    SelforFamilypension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeofbank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensioners", x => x.PAN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pensioners");
        }
    }
}
