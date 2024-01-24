using System;
using System.Collections.Generic;

namespace ConsoleApp46;

public partial class Patient
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string SeriesPassport { get; set; } = null!;

    public string NumbersPassport { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string InsurancePolicyNumber { get; set; } = null!;

    public int InsurancePolicyTypeId { get; set; }

    public int InsuranceCompanyId { get; set; }

    public virtual InsuranceCmpany InsuranceCompany { get; set; } = null!;

    public virtual InsurancePolicyType InsurancePolicyType { get; set; } = null!;
}
