using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class DeleteArtGalleryQuery(Guid galleryId) : IRequest<bool>
    {
        public Guid GalleryId { get; set; } = galleryId;
    }
}