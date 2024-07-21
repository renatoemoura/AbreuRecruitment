using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class EditArtGalleryQuery(ArtGallery artGallery) : IRequest<ArtGallery?>
    {
        public ArtGallery Gallery { get; set; } = artGallery;
    }
}