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
    public class CountryMapping:object,IEntityTypeConfiguration<CountryItem>
    {
        public CountryMapping():base()
        {
        }

        public void Configure(EntityTypeBuilder<CountryItem> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => x.id);
            builder.Property(x => x.nameCountry).HasMaxLength(50).IsRequired();
            builder.Property(x => x.imageCountry).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AriaProgress).HasMaxLength(3).IsRequired();
            builder.Property(x => x.visit).HasMaxLength(50).IsRequired();

        }
    }
}
