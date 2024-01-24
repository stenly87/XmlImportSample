using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateOfCreation { get; set; }

    public int ServicesId { get; set; }

    public int StatusOrderId { get; set; }

    public int StatusServicesId { get; set; }

    public string LeadTime { get; set; } = null!;

    public virtual StatusOrder StatusOrder { get; set; } = null!;

    public virtual StatusService StatusServices { get; set; } = null!;
}
