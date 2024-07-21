using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class DeleteArtWorkQuery(Guid workId) : IRequest<bool>
    {
        public Guid WorkId { get; set; } = workId;
    }
}