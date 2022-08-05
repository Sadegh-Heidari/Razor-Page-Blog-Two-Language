using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripository.DAL.Models
{
    public class CountryItemDTAT:IDisposable
    {
        public int ID { get; set; }
        public string? imageCountry { get;  set; }
        public string? nameCountry { get;  set; }
        public string? visit { get;  set; }
        public string? AriaProgress { get;  set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
