using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ripository.DAL.Models;

namespace DataAccsessLayer.ModelMapping
{
    public class NazarSanjiMapping: object,IEntityTypeConfiguration<NazarSanji>
    {
        public NazarSanjiMapping():base()
        {
        }

        public void Configure(EntityTypeBuilder<NazarSanji> builder)
        {
            builder.ToTable("Nazrsanji");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.imagename).HasMaxLength(50).IsRequired();
        }
    }
}
