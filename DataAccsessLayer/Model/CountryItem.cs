using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripository.DAL.Models
{
    public class CountryItem:IDisposable
    {
        public int id { get; private set;}
        public string imageCountry { get; private set; }
        public string nameCountry { get; private set; }
        public string visit { get; private set; }
        public string AriaProgress { get; private set; }

        public CountryItem(string imageCountry, string nameCountry, string visit, string ariaProgress)
        {
            this.imageCountry = imageCountry;
            this.nameCountry = nameCountry;
            this.visit = visit;
            AriaProgress = ariaProgress;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
