using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService
{
    public class CoffeeSettings
    {
        public bool machine_on { get; set; }
        public bool grinding_beans { get; set; }
        public bool empty_grounds_fault { get; set; }
        public bool water_empty_fault { get; set; }
        public uint number_of_cups_today { get; set; }
        public bool descale_required { get; set; }
        public bool have_another_one_carl { get; set; }
    }
}
