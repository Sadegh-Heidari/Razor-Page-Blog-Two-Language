using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.UnitOfWork;
using Ripository.DAL.Models;

namespace RZ_TOW_LANG.BAL.Business
{
    public class BuisinessCountry:object,IBusinessCountry,IDisposable
    {
        private IUnitOfWork _UnitOfWork { get; }

        public BuisinessCountry(IUnitOfWork unitOfWork):base()
        {
            _UnitOfWork = unitOfWork;
            
        }

        public IList<CountryItemDTAT>? GetCountryList()
        {
            var item = _UnitOfWork.CountryRepository.GetAll();
            var get = item?.Select(x => new CountryItemDTAT
            {
                ID = x.id,
                imageCountry = x.imageCountry,
                nameCountry = x.nameCountry,
                visit = x.visit,
                AriaProgress = x.AriaProgress
            }).ToList();
            return get;
        }

        public void Add(string imageCountry, string nameCountry, string visit, string ariaProgress)
        {
            _UnitOfWork.CountryRepository.Add(new CountryItem(imageCountry:imageCountry,
                nameCountry:nameCountry,visit:visit,ariaProgress:ariaProgress));
            _UnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
