using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripository.DAL.Models
{
    public class NazarSanjiDTAT:IDisposable
    {
        public int ID { get; set; }
        public string? imagename { get;  set; }
        public string? title { get;  set; }
        public string? Description { get;  set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
