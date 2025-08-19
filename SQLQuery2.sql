-- Tạo Database
CREATE DATABASE CuaHangBanhNgot;
GO
USE CuaHangBanhNgot;
GO

-- Bảng khách hàng
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    SDT VARCHAR(15),
    DiaChi NVARCHAR(200),
    Email VARCHAR(100)
);

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    ChucVu NVARCHAR(50),
    SDT VARCHAR(15),
    MatKhau VARCHAR(100)
);

-- Bảng nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(10) PRIMARY KEY,
    TenNCC NVARCHAR(100),
    SDT VARCHAR(15),
    Email VARCHAR(100),
    DiaChi NVARCHAR(200)
);

-- Bảng sản phẩm
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(100),
    DonGia DECIMAL(18,2),
    SoLuong INT,
    MaNCC VARCHAR(10),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

-- Bảng hóa đơn
CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    NgayLap DATE,
    MaKH VARCHAR(10),
    MaNV VARCHAR(10),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaHD VARCHAR(10),
    MaSP VARCHAR(10),
    SoLuong INT,
    ThanhTien AS (SoLuong * (SELECT DonGia FROM SanPham WHERE SanPham.MaSP = ChiTietHoaDon.MaSP)) PERSISTED,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);