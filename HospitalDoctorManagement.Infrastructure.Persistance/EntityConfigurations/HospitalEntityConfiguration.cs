using HospitalDoctorManagement.Api.Core.Domain.Model;
using HospitalDoctorManagement.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Infrastructure.Persistance.EntityConfigurations;

public class HospitalEntityConfiguration : BaseEntityConfiguration<Hospital>
{
    public override void Configure(EntityTypeBuilder<Hospital> builder)
    {
        base.Configure(builder);

        builder.ToTable("Hospitals", HospitalDoctorDbContext.DEFAULT_SCHEMA);
    }
}
