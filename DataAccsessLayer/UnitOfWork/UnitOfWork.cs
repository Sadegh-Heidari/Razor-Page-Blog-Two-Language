using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.Context;
using DataAccsessLayer.Repository;

namespace DataAccsessLayer.UnitOfWork
{
    public class UnitOfWork:object,IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private DataContextClass _contextClass { get; }
        private INazarRepository? _NazarRepository { get; set; }
        private ICountryRepository? _CountryRepository { get; set; }
        public UnitOfWork(DataContextClass contextClass):base()
        {
            _contextClass = contextClass;
           
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (_CountryRepository == null)
                {
                    _CountryRepository = new CountryRepository(_contextClass);
                }
                return _CountryRepository;
            }
        }

        public INazarRepository NazarRepository
        {
            get
            {
                if (_NazarRepository == null)
                {
                    _NazarRepository = new NazarRepository(_contextClass);
                }

                return _NazarRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
        public void SaveChanges()
        {
            _contextClass.SaveChanges();
        }

        protected virtual void Dispose(bool dispossing)
        {
            if(!_disposed&&dispossing)
                _contextClass.Dispose();
            _disposed = true;
        }
    }
}
