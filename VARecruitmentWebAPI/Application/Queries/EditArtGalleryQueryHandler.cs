using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class EditArtGalleryQueryHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<EditArtGalleryQuery, ArtGallery?>
    {
        public async Task<ArtGallery?> Handle(EditArtGalleryQuery request, CancellationToken cancellationToken)
        {
            return await artGalleryRepository.EditAsync(request.Gallery, cancellationToken);
        }
    }
}
