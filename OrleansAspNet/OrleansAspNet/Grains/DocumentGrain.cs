namespace OrleansAspNet.Grains;

public class DocumentGrain([PersistentState("doc", "documentStore")] IPersistentState<DocumentState> state)
    : Grain, IDocumentGrain
{
    public Task<string> GetContent()
    {
        // State is hydrated automatically on activation
        return Task.FromResult(state.State.Content);
    }

    public async Task UpdateContent(string content)
    {
        state.State.Content = content;
        state.State.LastUpdated = DateTime.UtcNow;
        await state.WriteStateAsync(); // persist changes
    }

    public Task<DocumentMetadata> GetMetadata()
    {
        var metadata = new DocumentMetadata
        {
            Title = state.State.Title,
            LastUpdated = state.State.LastUpdated
        };
        return Task.FromResult(metadata);
    }

    public async Task Delete()
    {
        await state.ClearStateAsync(); // wipe persisted state
    }
}