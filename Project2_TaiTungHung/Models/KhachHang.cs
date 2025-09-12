using System;
using System.Collections.Generic;

namespace Project2_TaiTungHung.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
