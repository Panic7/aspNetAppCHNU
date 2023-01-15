using Microsoft.EntityFrameworkCore;
using ImageMicroservice.DAL;
using ImageMicroservice.DAL.Entities;

namespace ImageMicroservice.DAL.Repositories
{
    public class ImageRepository : GenericRepository<Image>
    {
        public ImageRepository(ImageContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Image> GetCompleteEntityAsync(int id)
        {
            var image = await table
                .SingleOrDefaultAsync(g => g.Id == id);

            return image;
        }
    }
}
