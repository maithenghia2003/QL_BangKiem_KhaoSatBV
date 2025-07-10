using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_BangKiem_KhaoSat.Migrations
{
    /// <inheritdoc />
    public partial class Step : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BangKiemEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGiamSat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Khoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieuDuongThucHien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiGiamSat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomThaoTacJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangKiemEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepIndex = table.Column<int>(type: "int", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaiTros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BangKiemStepResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangKiemEntityId = table.Column<int>(type: "int", nullable: false),
                    StepIndex = table.Column<int>(type: "int", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KetQuaLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diem = table.Column<float>(type: "real", nullable: true),
                    KetQuaNhom1 = table.Column<float>(type: "real", nullable: true),
                    KetQuaNhom2 = table.Column<float>(type: "real", nullable: true),
                    LoaiKetQua = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangKiemStepResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangKiemStepResults_BangKiemEntities_BangKiemEntityId",
                        column: x => x.BangKiemEntityId,
                        principalTable: "BangKiemEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhauHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTroId = table.Column<int>(type: "int", nullable: false),
                    DaDuyet = table.Column<bool>(type: "bit", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_VaiTros_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BangKiemSubStepResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepResultId = table.Column<int>(type: "int", nullable: false),
                    BangKiemStepResultId = table.Column<int>(type: "int", nullable: false),
                    SubStepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KetQuaNhom1 = table.Column<float>(type: "real", nullable: true),
                    KetQuaNhom2 = table.Column<float>(type: "real", nullable: true),
                    Diem = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangKiemSubStepResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangKiemSubStepResults_BangKiemStepResults_BangKiemStepResultId",
                        column: x => x.BangKiemStepResultId,
                        principalTable: "BangKiemStepResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuDuyets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HanhDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDuyets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuDuyets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangKiemStepResults_BangKiemEntityId",
                table: "BangKiemStepResults",
                column: "BangKiemEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BangKiemSubStepResults_BangKiemStepResultId",
                table: "BangKiemSubStepResults",
                column: "BangKiemStepResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDuyets_UserId",
                table: "LichSuDuyets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VaiTroId",
                table: "Users",
                column: "VaiTroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangKiemSubStepResults");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropTable(
                name: "LichSuDuyets");

            migrationBuilder.DropTable(
                name: "StepEntities");

            migrationBuilder.DropTable(
                name: "BangKiemStepResults");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BangKiemEntities");

            migrationBuilder.DropTable(
                name: "VaiTros");
        }
    }
}
