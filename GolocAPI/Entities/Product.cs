using GolocAPI.Entities.Common;

namespace GolocAPI.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public double PricePerDay { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

    }
}
