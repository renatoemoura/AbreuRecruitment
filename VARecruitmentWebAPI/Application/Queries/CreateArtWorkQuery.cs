using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;
using VAArtGalleryWebAPI.Domain.Interfaces;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class CreateArtWorkQuery(Guid galleryId, ArtWork work) : IRequest<ArtWork?>
    {
        public Guid GalleryId { get; set; } = galleryId;
        public ArtWork Work { get; set; } = work;
    }
}
