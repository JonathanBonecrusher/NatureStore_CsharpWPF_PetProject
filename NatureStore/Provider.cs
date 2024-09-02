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
    public class Provider
    {
        [Key] public int Provider_Id { get; set; }
        public string Provider_Name { get; set; }
        public string Provider_Phone { get; set; }
        public string Provider_Email { get; set; }

        public List<Supply> SupplyEntity { get; set; }

        static public class gridRefEE
        {
            static public ListBox listBox{ get; set; }
        }
    }
}
