namespace GolocAPI.Models;
public class ProductCategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class ProductCategoryPostModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
