using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService
{
    public interface ICoffee
    {
        public CoffeeSettings ProcessCoffee(string settings);
    }
}
