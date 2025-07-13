using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_BangKiem_KhaoSat.Migrations
{
    /// <inheritdoc />
    public partial class DanhGia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KetLuanNhom1",
                table: "BangKiemStepResults");

            migrationBuilder.DropColumn(
                name: "KetLuanNhom2",
                table: "BangKiemStepResults");

            migrationBuilder.CreateTable(
                name: "BangKiemDanhGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangKiemId = table.Column<int>(type: "int", nullable: false),
                    NguoiDanhGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangKiemDanhGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangKiemDanhGias_BangKiemEntities_BangKiemId",
                        column: x => x.BangKiemId,
                        principalTable: "BangKiemEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangKiemDanhGias_BangKiemId",
                table: "BangKiemDanhGias",
                column: "BangKiemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangKiemDanhGias");

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
    }
}
