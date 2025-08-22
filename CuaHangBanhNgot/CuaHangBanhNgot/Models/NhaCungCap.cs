using System;
using System.Collections.Generic;

namespace CuaHangBanhNgot.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
