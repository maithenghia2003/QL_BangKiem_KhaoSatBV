using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_BangKiem_KhaoSat.Migrations
{
    /// <inheritdoc />
    public partial class ketluan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KetLuanNhom1",
                table: "BangKiemStepResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KetLuanNhom2",
                table: "BangKiemStepResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KetLuanNhom1",
                table: "BangKiemStepResults");

            migrationBuilder.DropColumn(
                name: "KetLuanNhom2",
                table: "BangKiemStepResults");
        }
    }
}
