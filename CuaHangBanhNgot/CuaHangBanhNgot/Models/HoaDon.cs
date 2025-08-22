using System;
using System.Collections.Generic;

namespace CuaHangBanhNgot.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateOnly? NgayLap { get; set; }

    public string? MaKh { get; set; }

    public string? MaNv { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
