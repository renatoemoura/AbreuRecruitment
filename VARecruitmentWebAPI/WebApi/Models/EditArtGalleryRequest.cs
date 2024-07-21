namespace VAArtGalleryWebAPI.WebApi.Models
{
    public class EditArtGalleryRequest(string id, string name, string city, string manager)
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string City { get; set; } = city;
        public string Manager { get; set; } = manager;
    }
}
