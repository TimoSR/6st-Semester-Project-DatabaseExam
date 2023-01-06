using API.Neo4j.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;

namespace API.Neo4j.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class NeoActivityController : ControllerBase
{
    
    private readonly IGraphClient _client;

    public NeoActivityController(IGraphClient client)
    {
        _client = client;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var activities = await _client.Cypher
            .Match("(n: Activity)")
            .Return(n => n.As<NeoActivity>()).ResultsAsync;

        return Ok(activities);
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var activity = await _client.Cypher
            .Match("(n: Activity)")
            .Where((Department n) => n.id == id)
            .Return(n => n.As<NeoActivity>()).ResultsAsync;

        return Ok(activity.LastOrDefault());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]NeoActivity activity)
    {
        await _client.Cypher
            .Create("(a: Activity $activity)")
            .WithParam("activity", activity)
            .ExecuteWithoutResultsAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]NeoActivity activity)
    {
        await _client.Cypher
            .Match("(n:Activity)")
            .Where((NeoActivity n) => n.id == id)
            .Set("n = $activity")
            .WithParam("activity", activity)
            .ExecuteWithoutResultsAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _client.Cypher
            .Match("(n: Activity)")
            .Where((NeoActivity n) => n.id == id)
            .Delete("n")
            .ExecuteWithoutResultsAsync();

        return Ok();
    }
    
    
}


