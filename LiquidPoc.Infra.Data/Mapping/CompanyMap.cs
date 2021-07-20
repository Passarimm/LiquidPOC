using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiquidPoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Infra.Data.Mapping
{
    class CompanyMap : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).HasMaxLength(250).IsRequired();

            builder.Property(u => u.CreateAt).IsRequired();
            builder.Property(u => u.UpdatedAt);
            builder.Property(u => u.Deleted).IsRequired();
            builder.Property(u => u.Active).IsRequired();
        }
    }
}
