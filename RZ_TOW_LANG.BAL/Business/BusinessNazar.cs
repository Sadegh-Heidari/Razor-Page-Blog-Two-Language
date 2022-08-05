using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.UnitOfWork;
using Ripository.DAL.Models;

namespace RZ_TOW_LANG.BAL.Business
{
    public class BusinessNazar:object,IBusinessNazar,IDisposable
    {
        private IUnitOfWork _unitOfWork { get; }
        public BusinessNazar(IUnitOfWork unitOfWork):base()
        {
            _unitOfWork = unitOfWork;
        }

        public IList<NazarSanjiDTAT>? getAlList()
        {
             return _unitOfWork?.NazarRepository?.GetAll()?.Select(x => new NazarSanjiDTAT()
             {
                 ID = x.Id,
                 imagename = x.imagename,
                 title = x.title,
                 Description = x.Description
             }).ToList(); 

            
        }

        public void Add(string imagename, string title, string Description)
        {
            _unitOfWork.NazarRepository.AddNazar(new NazarSanji(imagename:imagename,
            title: title, description: Description));
            _unitOfWork.SaveChanges();
        }

        public string DeleteNazar(int id)
        {

            var item = _unitOfWork.NazarRepository.GetNazarById(id);
            if (item == null)
            {
                return Resources.ProjectResource.ProjectNotFound;
            }
            else
            {
                var result = _unitOfWork.NazarRepository.DeleteNazar(item);
                _unitOfWork.SaveChanges();
                return result!;
            }
        }

        public NazarSanjiDTAT? getNazarById(int id)
        {
            var item = _unitOfWork.NazarRepository.GetNazarById(id);
            if (item == null)
                return null;
            NazarSanjiDTAT nz = new NazarSanjiDTAT();
            nz.ID=item.Id;
            nz.title = item.title;
            nz.Description = item.Description;
            nz.imagename =item.imagename;

            return nz;
            
        }

        public string Update(int id, string imagename, string title, string Description)
        {
            var item = _unitOfWork.NazarRepository.GetNazarById(id);
            if (item == null)
            {
                return Resources.ProjectResource.DeleteProject;
            }
            item.UpdateModel(id,imagename,title,Description);
            var result = _unitOfWork.NazarRepository.UpdateNazar(item);
            _unitOfWork.SaveChanges();
            return result!;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
