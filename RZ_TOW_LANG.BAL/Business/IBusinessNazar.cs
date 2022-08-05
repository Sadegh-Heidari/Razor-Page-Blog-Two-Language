using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripository.DAL.Models;

namespace RZ_TOW_LANG.BAL.Business
{
    public interface IBusinessNazar
    {
        IList<NazarSanjiDTAT>? getAlList();
        void Add(string imagename, string title, string Description);
        string DeleteNazar(int id);
        NazarSanjiDTAT? getNazarById(int id);
        string Update(int id,string imagename, string title, string Description);
    }            
}                