using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripository.DAL.Models;

namespace RZ_TOW_LANG.BAL.Business
{
    public interface IBusinessCountry
    {
        IList<CountryItemDTAT>? GetCountryList();
        void Add(string imageCountry, string nameCountry, string visit, string ariaProgress);
    }
}
