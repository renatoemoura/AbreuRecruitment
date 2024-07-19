using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class CreateArtGalleryQueryHandler(IArtGalleryRepository artGalleryRepository) : IRequestHandler<CreateArtGalleryQuery, ArtGallery?>
    {
        public async Task<ArtGallery?> Handle(CreateArtGalleryQuery request, CancellationToken cancellationToken)
        {
            return await artGalleryRepository.CreateAsync(request.Gallery, cancellationToken);
        }
    }
}
