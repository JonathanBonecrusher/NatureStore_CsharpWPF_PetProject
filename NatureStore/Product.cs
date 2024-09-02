using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace NatureStore
{
    public class Product
    {
        [Key] public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Type { get; set; }
        public int Product_Amount { get; set; }
        public decimal Product_Cost { get; set; }
        public string Expiration_Date { get; set; }
        public List<Turnover_Product> Product_Turnover_Entity { get; set; }

        public List<Supply_Product> Product_Supply_Entity { get; set; }

        [ForeignKey("ProviderEntity")] public int Provider_Key { get; set; }

        public Provider ProviderEntity { get; set; }

        static public class gridRefE
        {
            static public DataGrid grid { get; set; }
        }
    }
}
