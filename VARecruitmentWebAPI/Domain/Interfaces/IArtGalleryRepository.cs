using VAArtGalleryWebAPI.Domain.Entities;

namespace VAArtGalleryWebAPI.Domain.Interfaces
{
    public interface IArtGalleryRepository
    {
        Task<List<ArtGallery>> GetAllArtGalleriesAsync(CancellationToken cancellationToken = default);
        Task<ArtGallery?> GetArtGalleryByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ArtGallery> CreateAsync(ArtGallery artGallery, CancellationToken cancellationToken = default);
        Task<ArtGallery?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}