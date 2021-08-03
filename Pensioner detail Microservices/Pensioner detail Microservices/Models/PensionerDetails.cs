using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pensioner_detail_Microservices.Models
{
    public class PensionerDetails
    {
    public string Name { get; set; }
    public string Dateofbirth { get; set; }
        
        [Key]
    public string PAN { get; set; }

    public int SalaryEarned { get; set; }

    public int Allowances { get; set; }

    public string SelforFamilypension { get; set; }

     public string bank_name { get; set; }
     public string accountNumber { get; set; }

     public string typeofbank { get; set; }
    }
}
