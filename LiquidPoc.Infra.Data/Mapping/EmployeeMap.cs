using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiquidPoc.Domain.Entities;

namespace LiquidPoc.Infra.Data.Mapping
{
    class EmployeeMap : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {

            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.MaritalStatus).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
                                                     
            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Deleted).IsRequired();
            builder.Property(x => x.Active).IsRequired();

            //builder.HasOne(x => x.Company).WithMany().HasForeignKey("IdCompany");
        }
    }
}
