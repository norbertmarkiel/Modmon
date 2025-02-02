using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.DAL.Conferences
{
    internal class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
        }
    }
}
