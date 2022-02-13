using System;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class DepartmentConfigure : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DepartmentID);
            builder.Property(x => x.DepartmentID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.DepartmentTitle).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CompanyID_FK).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.CreateDatetime).HasColumnType("datetime");
            builder.Property(x => x.ModifidDatetime).HasColumnType("datetime");
            builder.Property(x => x.DeleteDatetime).HasColumnType("datetime");

            builder.HasData(
                new Department
                {
                    DepartmentID = 1,
                    DepartmentTitle = "IT Programing",
                    Description = "Programing and Deplover",
                    IsActive = true,
                    IsDelete = false,
                    CreateDatetime = DateTime.Now,
                    ModifidDatetime = DateTime.Now,
                    DeleteDatetime = DateTime.Now,
                    CompanyID_FK = 1,
                });

        }
    }
}