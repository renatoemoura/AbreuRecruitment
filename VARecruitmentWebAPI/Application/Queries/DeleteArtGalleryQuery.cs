using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class DeleteArtGalleryQuery(Guid galleryId) : IRequest<ArtGallery?>
    {
        public Guid GalleryId { get; set; } = galleryId;
    }
}