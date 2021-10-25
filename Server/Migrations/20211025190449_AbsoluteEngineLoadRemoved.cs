using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCarDiagz.Server.Migrations
{
    public partial class AbsoluteEngineLoadRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 67);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive", "IsAvailable" },
                values: new object[] { 67, false, true });
        }
    }
}
