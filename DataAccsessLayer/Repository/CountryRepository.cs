using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Ripository.DAL.Models;

namespace DataAccsessLayer.Repository
{
    public class CountryRepository:object,ICountryRepository,IDisposable
    {
        private DataContextClass _contextClass { get; }

        public CountryRepository(DataContextClass contextClass):base()
        {
            _contextClass = contextClass;
        }

        public IList<CountryItem>? GetAll()
        {
            
            return _contextClass.CountryItem?.ToList();
        }

        public void Add(CountryItem countryItem)
        {
            _contextClass.CountryItem!.Add(countryItem);
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
