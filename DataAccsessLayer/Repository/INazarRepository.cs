using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripository.DAL.Models;

namespace DataAccsessLayer.Repository
{
    public interface INazarRepository
    {
        IList<NazarSanji>? GetAll();
        void AddNazar(NazarSanji nazarSanji);
        string? DeleteNazar(NazarSanji nazarSanji);
        NazarSanji? GetNazarById(int id); 
        string? UpdateNazar(NazarSanji nazarSanji);
    }
}
