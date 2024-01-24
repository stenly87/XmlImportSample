using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class InsuranceCmpany
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string CheckingAccount { get; set; } = null!;

    public string Bik { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
