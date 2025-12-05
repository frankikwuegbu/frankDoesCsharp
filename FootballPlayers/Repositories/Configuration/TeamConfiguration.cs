using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories.Configuration;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{

    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasData
        (
        new Team
        {
            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            Name = "Manchester United",
            Country = "England",
            City = "Manchester"
        },
        new Team
        {
            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            Name = "Real Madrid",
            Country = "Spain",
            City = "Madrid"
        }
        );
    }
}
