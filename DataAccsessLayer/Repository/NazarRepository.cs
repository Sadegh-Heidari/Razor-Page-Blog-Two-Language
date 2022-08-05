using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Ripository.DAL.Models;

namespace DataAccsessLayer.Repository
{
    public class NazarRepository:object,INazarRepository,IDisposable
    {
        private DataContextClass _dataContextClass { get; }

        public NazarRepository(DataContextClass dataContextClass):base()
        {
            _dataContextClass = dataContextClass;
        }

        public IList<NazarSanji>? GetAll()
        {
            return _dataContextClass.NazarSanji?.ToList();
        }

        public void AddNazar(NazarSanji nazarSanji)
        {
            _dataContextClass.NazarSanji!.Add(nazarSanji);
        }

        public string? DeleteNazar(NazarSanji nazarSanji)
        {
            if (_dataContextClass.Entry(nazarSanji).State != EntityState.Deleted)
            {
                _dataContextClass.NazarSanji!.Remove(nazarSanji).State = EntityState.Deleted;
                return String.Empty;
            }
            else
            {
                return  Resources.ProjectResource.DeleteProject;
            }

        }

        public NazarSanji? GetNazarById(int id)
        {
            return _dataContextClass.NazarSanji?.FirstOrDefault(x=>x.Id==id);
        }

        public string? UpdateNazar(NazarSanji nazarSanji)
        {

            if (_dataContextClass.Entry(nazarSanji).State != EntityState.Deleted || _dataContextClass.Entry(nazarSanji).State !=  EntityState.Modified)
            {
                _dataContextClass.Entry(nazarSanji).State = EntityState.Modified;
                _dataContextClass.Update(nazarSanji);
                return String.Empty;
            }
           
            return Resources.ProjectResource.DeleteProject;
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
