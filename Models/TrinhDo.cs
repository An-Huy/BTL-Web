using System;
using System.Collections.Generic;

namespace librarian_admin.Models;

public partial class TrinhDo
{
    public string MaTrinhDo { get; set; } = null!;

    public string? TenTrinhDo { get; set; }

    public virtual ICollection<TacGium> TacGia { get; } = new List<TacGium>();
}
