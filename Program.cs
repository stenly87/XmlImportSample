// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Numerics;
using System;
using System.Data;
using System.Xml.Serialization;
using ConsoleApp46;

Console.WriteLine("Hello, World!");

/*
< full_name > Glyn Dunkerly </ full_name >
< login > gdunkerly0 </ login >
< pwd > IGU2Q1qifXuf </ pwd >
< guid > da293d99 - 95aa - 4254 - 8c7e - c9e9270ef3f7 </ guid >
< email > gdunkerly0@ted.com </ email >
< social_sec_number > 93766273 </ social_sec_number >
< ein > 04 - 6439890 </ ein >
< social_type > oms </ social_type >
< phone > +86(106) 695 - 3205 </ phone >
< passport_s > 9091 </ passport_s >
< passport_n > 129038 </ passport_n >
< birthdate_timestamp > -716240535000 </ birthdate_timestamp >
< id > 1 </ id >
< country > China </ country >
< insurance_name > Avamba </ insurance_name >
< insurance_address > 0536 Bunker Hill Plaza</insurance_address>
<insurance_inn>2716833</insurance_inn>
<ipadress>227.113.77.41</ipadress>
<insurance_p/c>553793026</insurance_p/c>
<insurance_bik>180522995</insurance_bik>
<ua>Mozilla/5.0 (X11; CrOS i686 0.13.587) AppleWebKit / 535.1(KHTML, like Gecko) Chrome / 13.0.782.14 Safari / 535.1 </ ua >

    */

//Console.WriteLine(DateTime.Now.ToBinary());

XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Record>));
List<Record> records = new List<Record>();
using (var fs = File.OpenRead("C:\\Users\\Student\\Desktop\\КЗ_РЧ20_21_Основная группа\\Session 1\\patients.xml"))
    records = (List<Record>)xmlSerializer.Deserialize(fs);

User29Context user29Context = new User29Context();
    foreach (var r in records)
{
    Patient patient = new Patient
    {
        Birthday = DateTimeOffset.FromUnixTimeMilliseconds(r.birthdate_timestamp).DateTime,
        Email = r.email,
        Fio = r.full_name,
        //Id = r.id, // убираем, потому что EF не дает сохранять записи с указанными ID и с автоикрементом
        InsurancePolicyNumber = r.social_sec_number.ToString(),
        Login = r.login,
        NumbersPassport = r.passport_n.ToString(),
        SeriesPassport = r.passport_s.ToString(),
        Password = r.pwd,
        Telephone = r.phone,
    };
    var cmp = user29Context.InsuranceCmpanies.FirstOrDefault(s=>s.Inn == r.insurance_inn);
    if (cmp == null)
    {
        cmp = new InsuranceCmpany {
         Adress = r.insurance_address,
          Bik = r.insurance_bik,
           CheckingAccount = r.insurance_pc,
            Inn = r.insurance_inn,
             Title = r.insurance_name
        };
        user29Context.InsuranceCmpanies.Add(cmp);
        user29Context.SaveChanges();
    }
    patient.InsuranceCompany = cmp;
    var cmpType = user29Context.InsurancePolicyTypes.
        FirstOrDefault(s=>s.Title == r.social_type);
    if (cmpType == null )
    {
        cmpType = new InsurancePolicyType
        {
            Title = r.social_type,
        };
        user29Context.InsurancePolicyTypes.Add(cmpType);
        user29Context.SaveChanges();
    }
    patient.InsurancePolicyType = cmpType;
    user29Context.Patients.Add(patient);
}
user29Context.SaveChanges();

/*
 // код для создания файла для самопроверки структуры
 XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Record>));
List<Record> records = new List<Record>();
 records.Add(new Record());

using (var fs = File.Create("test.xml"))
    xmlSerializer.Serialize(fs, records);*/

public class Record
{
    public string full_name { get; set; }
    public string login { get; set; }
    public string pwd { get; set; }
    public long birthdate_timestamp { get; set; }
    public int passport_s { get; set; }
    public int passport_n { get; set; }
    public string phone { get; set; }
    public string email { get; set; }

    public string guid { get; set; }
    public int social_sec_number { get; set; }
    public string ein { get; set; }
    public string social_type { get; set; }
    public int id { get; set; }
    public string country { get; set; }

    public string insurance_name { get; set; }
    public string insurance_address { get; set; }
    public string insurance_inn { get; set; }
    public string ipadress { get; set; }
    public string insurance_pc { get; set; }
    public string insurance_bik { get; set; }
    public string ua { get; set; }
}