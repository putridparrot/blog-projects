namespace OrleansAspNet.Grains;

public interface IDocumentGrain : IGrainWithGuidKey
{
    /// <summary>
    /// Gets the current content of the document.
    /// </summary>
    Task<string> GetContent();

    /// <summary>
    /// Updates the document content.
    /// </summary>
    Task UpdateContent(string content);

    /// <summary>
    /// Gets metadata about the document (title, last updated, etc.).
    /// </summary>
    Task<DocumentMetadata> GetMetadata();

    /// <summary>
    /// Deletes the document state.
    /// </summary>
    Task Delete();
}