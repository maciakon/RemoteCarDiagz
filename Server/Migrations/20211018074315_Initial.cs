using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCarDiagz.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Value);
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 4, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 62, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 63, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 66, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 67, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 68, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 69, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 70, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 71, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 72, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 73, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 61, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 74, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 76, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 77, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 78, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 82, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 89, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 91, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 92, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 93, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 94, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 97, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 75, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 98, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 60, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 50, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 5, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 6, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 7, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 8, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 9, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 10, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 11, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 12, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 13, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 14, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 51, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 15, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 17, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 30, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 31, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 33, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 44, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 45, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 46, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 47, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 48, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 49, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 16, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 99, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
