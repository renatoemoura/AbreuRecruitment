using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class DeleteArtGalleryQueryHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<DeleteArtGalleryQuery, ArtGallery?>
    {
        public async Task<ArtGallery?> Handle(DeleteArtGalleryQuery request, CancellationToken cancellationToken)
        {
            return await artGalleryRepository.DeleteAsync(request.GalleryId, cancellationToken);
        }
    }
}
