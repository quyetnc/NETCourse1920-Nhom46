using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCourse1920_Nhom46.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenKhoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    MaMon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenMon = table.Column<string>(nullable: true),
                    SoTinChi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.MaMon);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    MaLHP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamHoc = table.Column<string>(nullable: true),
                    HocKy = table.Column<string>(nullable: true),
                    MaMon = table.Column<int>(nullable: false),
                    DiemGK = table.Column<double>(nullable: false),
                    DiemCuoiKy = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.MaLHP);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_MonHocs_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHocs",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MaSV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoTen = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DienThoai = table.Column<string>(nullable: true),
                    MaLHP = table.Column<int>(nullable: false),
                    MaKhoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhViens_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SinhViens_LopHocPhans_MaLHP",
                        column: x => x.MaLHP,
                        principalTable: "LopHocPhans",
                        principalColumn: "MaLHP",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaHocTaps",
                columns: table => new
                {
                    MaKQHT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaSV = table.Column<int>(nullable: false),
                    MaLHP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaHocTaps", x => x.MaKQHT);
                    table.ForeignKey(
                        name: "FK_KetQuaHocTaps_LopHocPhans_MaLHP",
                        column: x => x.MaLHP,
                        principalTable: "LopHocPhans",
                        principalColumn: "MaLHP",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KetQuaHocTaps_SinhViens_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaHocTaps_MaLHP",
                table: "KetQuaHocTaps",
                column: "MaLHP");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaHocTaps_MaSV",
                table: "KetQuaHocTaps",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_MaMon",
                table: "LopHocPhans",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaKhoa",
                table: "SinhViens",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaLHP",
                table: "SinhViens",
                column: "MaLHP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQuaHocTaps");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "MonHocs");
        }
    }
}
