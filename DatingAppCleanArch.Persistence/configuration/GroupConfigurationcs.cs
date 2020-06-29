using DatingAppCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatingAppCleanArch.Persistence.configuration
{
    public class GroupConfigurationcs : IEntityTypeConfiguration<Group>
    {
        

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50);



            builder.HasMany(g => g.Users)
                .WithOne(u => u.Group)
                .HasForeignKey(u => u.GroupId);
        }
    }
}
