using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripository.DAL.Models
{
    public class NazarSanji:IDisposable
    {
        public int Id { get; private set; }
        public string imagename { get; private set; }
        public string title { get; private set; }
        public string Description { get; private set; }

        public NazarSanji(string imagename, string title, string description)
        {
            this.imagename = imagename;
            this.title = title;
            Description = description;
        }

        public void UpdateModel(int id, string imagename, string title, string description)
        {
            this.Id = id;
            this.imagename = imagename;
            this.title = title;
            Description = description;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
