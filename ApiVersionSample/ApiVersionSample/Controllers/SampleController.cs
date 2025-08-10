using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

/*
    https://github.com/dotnet/aspnet-api-versioning

    Install-Package Asp.Versioning.Http # For Minimal APIs
    Install-Package Asp.Versioning.Mvc  # For Controllers
    Install-Package Asp.Versioning.Mvc.ApiExplorer

    <PackageReference Include="Asp.Versioning.Http" Version="8.1.0" />
    <PackageReference Include="Asp.Versioning.Mvc" Version="8.1.0" />
    <PackageReference Include="Asp.Versioning.Mvc.ApiExplorer" Version="8.1.0" />

    Header Version
    curl 'http://localhost:5029/Sample/GetValue' --header 'X-Api-Version: 1'
    curl 'http://localhost:5029/Sample/GetValue' --header 'X-Api-Version: 2'

    Query Parameter Version
    curl 'http://localhost:5029/Sample/GetValue?api-version=1'
    curl 'http://localhost:5029/Sample/GetValue?api-version=2'

    URL Version
    curl 'http://localhost:5029/v1/Sample/GetValue'
    curl 'http://localhost:5029/v2/Sample/GetValue'

    Media Type version
    curl 'http://localhost:5029/v1/Sample/GetValue' -H 'version=1.0'
    curl 'http://localhost:5029/v1/Sample/GetValue' -H 'version=2.0'

    curl 'http://localhost:5029/v1/Sample/GetValue' -v
    * Request completely sent off
    < HTTP/1.1 200 OK
    < Content-Type: application/json; charset=utf-8
    < Date: Thu, 28 Nov 2024 22:35:03 GMT
    < Server: Kestrel
    < Transfer-Encoding: chunked
    < api-supported-versions: 2.0, 3.0
    < api-deprecated-versions: 1.0
*/

namespace ApiVersionSample.Controllers;

[ApiVersion(1, Deprecated = true)]
[ApiVersion(2)]
[ApiVersion(3)]
[ApiController]
[Route("v{v:apiVersion}/[controller]")]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    [MapToApiVersion(1)]
    [Route("GetValue")]
    [HttpGet]
    public IActionResult Get1() =>
        Ok(1);

    [MapToApiVersion(2)]
    [Route("GetValue")]
    [HttpGet]
    public IActionResult Get2() =>
        Ok(2);

    [MapToApiVersion(3)]
    [Route("GetValue")]
    [HttpGet]
    public IActionResult Get3() =>
        Ok(3);
}