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
    DonGia DECIMAL(18,2), -- thêm đơn giá ở đây
    ThanhTien AS (SoLuong * DonGia) PERSISTED, -- cột tính toán
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
-- Thêm khách hàng
INSERT INTO KhachHang (MaKH, HoTen, SDT, DiaChi, Email)
VALUES
('KH01', N'Nguyễn Văn A', '0912345678', N'Hà Nội', 'vana@example.com'),
('KH02', N'Trần Thị B', '0987654321', N'Hồ Chí Minh', 'thib@example.com'),
('KH03', N'Lê Văn C', '0909123456', N'Đà Nẵng', 'vanc@example.com');

-- Thêm nhân viên
INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SDT, MatKhau)
VALUES
('NV01', N'Nguyễn Văn Quản', N'Quản lý', '0901112233', '123456'),
('NV02', N'Trần Văn Bán', N'Nhân viên bán hàng', '0902223344', 'abc123'),
('NV03', N'Lê Thị Thu', N'Thu ngân', '0903334455', 'thu321');

-- Thêm nhà cung cấp
INSERT INTO NhaCungCap (MaNCC, TenNCC, SDT, Email, DiaChi)
VALUES
('NCC01', N'Công ty Bánh Ngọt Việt', '0241234567', 'info@banhngotviet.com', N'Hà Nội'),
('NCC02', N'Nhà máy Bánh Kem Sài Gòn', '0289876543', 'contact@banhkemsg.com', N'Hồ Chí Minh');

-- Thêm sản phẩm
INSERT INTO SanPham (MaSP, TenSP, DonGia, SoLuong, MaNCC)
VALUES
('SP01', N'Bánh kem dâu', 120000, 50, 'NCC02'),
('SP02', N'Bánh su kem', 50000, 100, 'NCC01'),
('SP03', N'Bánh bông lan trứng muối', 90000, 70, 'NCC01');

-- Thêm hóa đơn
INSERT INTO HoaDon (MaHD, NgayLap, MaKH, MaNV)
VALUES
('HD01', '2025-08-20', 'KH01', 'NV02'),
('HD02', '2025-08-20', 'KH02', 'NV03');

-- Thêm chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia)
VALUES
('HD01', 'SP01', 1, 120000),
('HD01', 'SP02', 2, 50000),
('HD02', 'SP03', 1, 90000);

SELECT * FROM KhachHang;
SELECT * FROM HoaDon;
SELECT * FROM ChiTietHoaDon;
