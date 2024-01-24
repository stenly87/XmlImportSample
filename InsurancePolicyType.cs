using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class InsurancePolicyType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
