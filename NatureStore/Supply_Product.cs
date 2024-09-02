using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureStore
{
    public class Supply_Product
    {
        [Key] public int SuP_Id { get; set; }
        [ForeignKey("SupplyEntity")] public int Supply_Key { get; set; }
        [ForeignKey("ProductEntity")] public int Product_Key { get; set; }

        public int Product_Amount { get; set; }

        public Supply SupplyEntity { get; set; }
        public Product ProductEntity { get; set; }
    }
}
