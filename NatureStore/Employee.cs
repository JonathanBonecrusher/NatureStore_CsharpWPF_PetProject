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
    public class Employee
    {
        [Key] public int Employee_Id { get; set; }
        public string Job_Title { get; set; }
        public string Employee_Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        static public class gridRefEEE
        {
            static public ListBox listBox { get; set; }
        }
    }
}
