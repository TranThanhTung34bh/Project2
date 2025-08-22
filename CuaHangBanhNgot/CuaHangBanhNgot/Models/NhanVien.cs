using System;
using System.Collections.Generic;

namespace CuaHangBanhNgot.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? ChucVu { get; set; }

    public string? Sdt { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
