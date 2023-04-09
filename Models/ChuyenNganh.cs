﻿using System;
using System.Collections.Generic;

namespace librarian_admin.Models;

public partial class ChuyenNganh
{
    public string MaChuyenNganh { get; set; } = null!;

    public string? TenChuyenNganh { get; set; }

    public virtual ICollection<DmgiaoTrinh> DmgiaoTrinhs { get; } = new List<DmgiaoTrinh>();
}
