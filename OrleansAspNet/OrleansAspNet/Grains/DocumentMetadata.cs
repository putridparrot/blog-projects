namespace OrleansAspNet.Grains;

[GenerateSerializer]
public class DocumentMetadata
{
    [Id(0)]
    public string Title { get; set; } = string.Empty;

    [Id(1)]
    public DateTime LastUpdated { get; set; }
}

// OR records
//[GenerateSerializer]
//public record DocumentMetadata(
//    [property: Id(0)] string Title,
//    [property: Id(1)] DateTime LastUpdated
//);