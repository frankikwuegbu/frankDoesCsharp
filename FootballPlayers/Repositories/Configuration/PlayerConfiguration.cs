using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configuration;

internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasData
        (
            new Player
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Bruno Fernandes",
                Age = 31,
                Position = "Midfielder",
                TeamId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Player
            {
                Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Name = "Kylian Mbappe",
                Age = 26,
                Position = "Forward",
                TeamId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            },
            new Player
            {
                Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Name = "Jude Bellingham",
                Age = 22,
                Position = "Midfielder",
                TeamId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            }
        );
    }
}
