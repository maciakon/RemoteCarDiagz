using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCarDiagz.Server.Migrations
{
    public partial class ActiveMeasurements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Measurements",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 4,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 5,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 10,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 11,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 12,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 13,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 15,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 16,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 17,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Value",
                keyValue: 67,
                column: "IsAvailable",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Measurements");

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 6, false });

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
                values: new object[] { 74, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 75, false });

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
                values: new object[] { 68, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 98, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 66, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 62, false });

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
                values: new object[] { 14, false });

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
                values: new object[] { 50, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 51, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 60, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 61, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 63, false });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Value", "IsActive" },
                values: new object[] { 99, false });
        }
    }
}
