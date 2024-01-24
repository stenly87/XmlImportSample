using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class StatusService
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
