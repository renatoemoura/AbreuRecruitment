namespace VAArtGalleryWebAPI.WebApi.Models
{
    public class CreateArtWorkRequest(Guid galleryId, string name, string author, int creationYear, decimal askPrice)
    {
        public Guid GalleryId { get; set; } = galleryId;

        public string Name { get; set; } = name;

        public string Author { get; set; } = author;

        public int CreationYear { get; set; } = creationYear;

        public decimal AskPrice { get; set; } = askPrice;
    }
}
