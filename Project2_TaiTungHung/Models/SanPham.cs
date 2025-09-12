using System;
using System.Collections.Generic;

namespace Project2_TaiTungHung.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public decimal? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public string? MaNcc { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }
}
