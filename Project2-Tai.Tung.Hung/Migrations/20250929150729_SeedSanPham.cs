using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project2_TaiTungHung.Migrations
{
    /// <inheritdoc />
    public partial class SeedSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__2725CF1E7B4FB73A", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhaCungC__3A185DEBB26ED3ED", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MatKhau = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__2725D70A04FAC771", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    MaNCC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__2725081C9E0C6741", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK__SanPham__MaNCC__3D5E1FD2",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNCC");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: true),
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaNV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__2725A6E04D6C558A", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK__HoaDon__MaKH__403A8C7D",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__HoaDon__MaNV__412EB0B6",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(29,2)", nullable: true, computedColumnSql: "([SoLuong]*[DonGia])", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietH__F557F661151B2D0D", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "FK__ChiTietHoa__MaHD__4E88ABD4",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "FK__ChiTietHoa__MaSP__4F7CD00D",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "MaSP", "DonGia", "MaNCC", "SoLuong", "TenSP" },
                values: new object[,]
                {
                    { "1", 120000m, "NCC1", 10, "Bánh sinh nhật" },
                    { "10", 20000m, "NCC4", 22, "Bánh su kem matcha" },
                    { "11", 32000m, "NCC4", 14, "Bánh mousse xoài" },
                    { "12", 25000m, "NCC5", 30, "Bánh kem socola" },
                    { "13", 30000m, "NCC5", 16, "Bánh tiramisu" },
                    { "14", 28000m, "NCC5", 20, "Bánh mochi" },
                    { "15", 35000m, "NCC5", 9, "Bánh mousse" },
                    { "16", 22000m, "NCC5", 19, "Bánh su kem" },
                    { "17", 18000m, "NCC5", 50, "Bánh flan" },
                    { "18", 20000m, "NCC5", 35, "Bánh quy bơ" },
                    { "19", 32000m, "NCC5", 22, "Bánh cupcake" },
                    { "2", 25000m, "NCC1", 20, "Bánh tươi" },
                    { "3", 18000m, "NCC2", 30, "Bánh miếng nhỏ" },
                    { "4", 25000m, "NCC2", 15, "Bánh cheesecake dâu" },
                    { "5", 30000m, "NCC2", 12, "Bánh tart trái cây" },
                    { "6", 28000m, "NCC3", 25, "Bánh croissant" },
                    { "7", 35000m, "NCC3", 8, "Bánh su kem" },
                    { "8", 22000m, "NCC3", 18, "Bánh su kem nhỏ" },
                    { "9", 18000m, "NCC4", 40, "Bánh macaron" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaSP",
                table: "ChiTietHoaDon",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaNCC",
                table: "SanPham",
                column: "MaNCC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
