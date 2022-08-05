using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripository.DAL.Models;

namespace DataAccsessLayer.Repository
{
    public interface ICountryRepository
    {
        IList<CountryItem>? GetAll();
        void Add(CountryItem countryItem);
    }
}
