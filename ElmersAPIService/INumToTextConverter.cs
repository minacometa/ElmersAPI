using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService
{
    public interface INumToTextConverter
    {
        string ConvertNumberToWords(string number);
    }
}
