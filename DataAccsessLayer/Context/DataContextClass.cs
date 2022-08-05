using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer.ModelMapping;
using Microsoft.EntityFrameworkCore;
using Ripository.DAL.Models;

namespace DataAccsessLayer.Context
{
    public class DataContextClass:DbContext
    {

        public DbSet<NazarSanji>? NazarSanji { get; set; }
        public DbSet<CountryItem>? CountryItem { get; set; }

       

        public DataContextClass(DbContextOptions<DataContextClass> options) : base(options)
        {
           
            
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NazarSanjiMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
