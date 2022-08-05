using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.Repository;

namespace DataAccsessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
       ICountryRepository CountryRepository { get; }
       INazarRepository NazarRepository { get; }
       void SaveChanges();
    }
}
