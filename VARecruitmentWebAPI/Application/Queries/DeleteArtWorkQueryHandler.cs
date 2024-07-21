using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class DeleteArtWorkQueryHandler(IArtWorkRepository artWorkRepository) : IRequestHandler<DeleteArtWorkQuery, bool>
    {
        public async Task<bool> Handle(DeleteArtWorkQuery request, CancellationToken cancellationToken)
        {
            return await artWorkRepository.DeleteAsync(request.WorkId, cancellationToken);
        }
    }
}
