using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatureStore
{
    public class Supply
    {
        [Key] public int Supply_Id { get; set; }
        public DateTime Supply_Date { get; set; }

        [ForeignKey("ProviderEntity")] public int Provider_Key { get; set; }
        public List<Supply_Product> Supply_Product_Entity { get; set; }

        public Provider ProviderEntity { get; set; }
    }
}
