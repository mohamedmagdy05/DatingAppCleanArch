using DatingAppCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatingAppCleanArch.Persistence.configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(p => p.FristName)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.HasOne(u => u.Group)
                    .WithMany(g => g.Users)
                    .HasForeignKey(u => u.GroupId);
        }
    }
}
