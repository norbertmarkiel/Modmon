using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.DAL.Conferences
{
    internal class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
        }
    }
}
