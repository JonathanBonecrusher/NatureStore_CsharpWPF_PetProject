using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureStore
{
    public class Turnover_Product
    {
        [Key] public int TP_Id { get; set; }
        [ForeignKey("TurnoverEntity")] public int Turnover_Key { get; set; }
        [ForeignKey("ProductEntity")] public int Product_Key { get; set; }

         public int Product_Amount { get; set; }

        public Turnover TurnoverEntity { get; set; }
        public Product ProductEntity { get; set; }

    }
}
