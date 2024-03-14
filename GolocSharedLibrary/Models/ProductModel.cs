

namespace GolocSharedLibrary.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public UserModel Owner { get; set; }
        public Guid MainImage { get; set; }
        public List<String> Images { get; set; }
        public string Name { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public int EcoValue { get; set; }
        public bool IsDemand { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public Guid CategoryId{ get; set; }
        public string City { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? StartAvailibility { get; set; }
        public DateTime? EndAvailibility { get; set; }
    }
    public class ProductPostModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public double PricePerDay { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
