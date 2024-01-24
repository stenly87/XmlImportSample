using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public string Code { get; set; } = null!;

    public string Deadline { get; set; } = null!;

    public string AverageDeviation { get; set; } = null!;
}
