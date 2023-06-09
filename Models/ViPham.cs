﻿using System;
using System.Collections.Generic;

namespace librarian_admin.Models;

public partial class ViPham
{
    public string MaViPham { get; set; } = null!;

    public string? TenViPham { get; set; }

    public virtual ICollection<ChiTietHstra> ChiTietHstras { get; } = new List<ChiTietHstra>();
}
