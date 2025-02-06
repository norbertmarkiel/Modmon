using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modmon.Modules.Speakers.Core.Entities;

namespace Modmon.Modules.Speakers.Core.DAL.Speakers
{
    internal class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
        }
    }
}
