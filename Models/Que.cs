﻿using System;
using System.Collections.Generic;

namespace librarian_admin.Models;

public partial class Que
{
    public string MaQue { get; set; } = null!;

    public string? TenQue { get; set; }

    public virtual ICollection<ThuThu> ThuThus { get; } = new List<ThuThu>();
}
