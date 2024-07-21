using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class CreateArtWorkQueryHandler(IArtWorkRepository artWorkRepository) : IRequestHandler<CreateArtWorkQuery, ArtWork?>
    {
        public async Task<ArtWork?> Handle(CreateArtWorkQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await artWorkRepository.CreateAsync(request.GalleryId, request.Work, cancellationToken);
            }
            catch (ArgumentException ex) when (string.Compare(ex.ParamName, "artGalleryId", true) == 0) 
            {
                return null;
            }
        }
    }
}
