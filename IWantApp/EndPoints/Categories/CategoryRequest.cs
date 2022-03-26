namespace IWantApp.EndPoints.Categories;

public record CategoryRequest
{
    public string Name { get; set; }
    public bool Active { get; set; }
};