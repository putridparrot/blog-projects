using Microsoft.AspNetCore.Mvc;
using OrleansAspNet.Grains;

namespace OrleansAspNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController(IClusterClient client) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<string> Get(Guid id)
    {
        // sample https://localhost:7288/api/document/B5D4A805-80C3-4239-967B-937A5A0E9250
        var grain = client.GetGrain<IDocumentGrain>(id);
        return await grain.GetContent();
    }
}