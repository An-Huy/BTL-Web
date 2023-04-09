using System;
using System.Collections.Generic;

namespace librarian_admin.Models;

public partial class ThuThu
{
    public string MaThuThu { get; set; } = null!;

    public string? TenThuThu { get; set; }

    public int Quyen { get; set; }

    public string? Username { get; set; }

    public string? Matkhau { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoaiCd { get; set; }

    public string? DienThoaiDd { get; set; }

    public string? MaQue { get; set; }

    public virtual ICollection<HoSoTra> HoSoTras { get; } = new List<HoSoTra>();

    public virtual ICollection<Hsmuon> Hsmuons { get; } = new List<Hsmuon>();

    public virtual Que? MaQueNavigation { get; set; }
}
