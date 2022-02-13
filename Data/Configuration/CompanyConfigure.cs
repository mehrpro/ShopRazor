using System;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class CompanyConfigure : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyID);
            builder.Property(x => x.CompanyID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CompanyTitle).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.CreateDatetime).HasColumnType("datetime");
            builder.Property(x => x.ModifidDatetime).HasColumnType("datetime");
            builder.Property(x => x.DeleteDatetime).HasColumnType("datetime");
            builder.HasMany(x => x.Departments)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyID_FK)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Company
                {
                    CompanyID = 1,
                    CompanyTitle = "SepehrSystem",
                    Description = "Sepehr System Group",
                    IsActive = true,
                    IsDelete = false,
                    CreateDatetime = DateTime.Now,
                    ModifidDatetime = DateTime.Now,
                    DeleteDatetime = DateTime.Now,

                });
        }
    }
}