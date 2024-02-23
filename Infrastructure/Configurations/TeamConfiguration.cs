using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWorkshop.Infrastructure.Configurations;
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasConversion(
                convertToProviderExpression: id => id.Value,
                convertFromProviderExpression: id => TeamName.Create(id))
            .HasColumnName("Name");
        builder.HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey("TeamName");
    }
}
