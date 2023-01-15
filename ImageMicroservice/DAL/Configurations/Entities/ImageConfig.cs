using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL.Configurations.Entities
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
               .Property(i => i.Uri)
               .HasMaxLength(3000)
               .IsRequired();

            builder
               .Property(i => i.Description)
               .HasMaxLength(2000)
               .IsRequired(false);

            builder
                .HasOne<Gallery>(i => i.Gallery)
                .WithMany(g => g.Images)
                .HasForeignKey(i => i.GalleryId)
                .IsRequired(false);


        }
    }
}
