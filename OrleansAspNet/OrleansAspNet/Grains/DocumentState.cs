namespace OrleansAspNet.Grains;

public class DocumentState
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
}