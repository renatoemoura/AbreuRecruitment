using MediatR;
using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Application.Queries
{
    public class CreateArtGalleryQuery(ArtGallery artGallery) : IRequest<ArtGallery?>
    {
        public ArtGallery Gallery { get; set; } = artGallery;
    }
}