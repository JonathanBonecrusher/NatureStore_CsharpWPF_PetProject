using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatureStore
{
    public class Turnover
    {
        [Key] public int Turnover_Id { get; set; }
        public DateTime Turnover_Date { get; set; }
        public decimal Turnover_Amount { get; set; }

        [ForeignKey("EmployeeEntity")] public int Employee_Key { get; set; }

        public List<Turnover_Product> Turnover_Product_Entity { get; set; }

        public Employee EmployeeEntity { get; set; }
    }
}
