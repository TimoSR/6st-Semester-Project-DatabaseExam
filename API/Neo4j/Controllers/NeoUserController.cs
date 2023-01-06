using API.Controllers;
using API.Neo4j.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace API.Neo4j.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class NeoUserController : BaseApiController
{
    private readonly IGraphClient _client;

    public NeoUserController(IGraphClient client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] NeoUser user)
    {
        await _client.Cypher
            .Create("(n: User $user)")
            .WithParam("user", user)
            .ExecuteWithoutResultsAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var employees = await _client.Cypher
            .Match("(n: User)")
            .Return(n => n.As<NeoUser>()).ResultsAsync;

        return Ok(employees);
    }

    [HttpPost("{user_id}/attends/{activity_id}")]
    public async Task<IActionResult> UserAttendsActivity(Guid user_id, Guid activity_id)
    {
        await _client.Cypher
            .Match("(a: Activity), (u: User)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            
            /*
             * Merge Insures That Relationship is only added if it does not exist. 
             */
            
            .Merge("(u)-[r:Attends]->(a)")
            .ExecuteWithoutResultsAsync();

        return Ok();

    }
    
    [HttpPost("{user_id}/IsHost/{activity_id}")]
    public async Task<IActionResult> UserIsHost(Guid user_id, Guid activity_id)
    {
        await _client.Cypher
            .Match("(a: Activity), (u: User)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            
            /*
             * Merge Insures That Relationship is only added if it does not exist. 
             */
            
            .Merge("(u)-[r:IsHost]->(a)")
            .ExecuteWithoutResultsAsync();

        return Ok();

    }
    
    [HttpPost("{user_id}/IsWatching/{activity_id}")]
    public async Task<IActionResult> IsWatching(Guid user_id, Guid activity_id)
    {
        await _client.Cypher
            .Match("(a: Activity), (u: User)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            
            /*
             * Merge Insures That Relationship is only added if it does not exist. 
             */
            
            .Merge("(u)-[r:IsWatching]->(a)")
            .ExecuteWithoutResultsAsync();

        return Ok();

    }

    [HttpPost("{user_id}/AddComment/{activity_id}")]
    public async Task<IActionResult> AddComment(Guid user_id, Guid activity_id, [FromBody]NeoComments comment)
    {
        await _client.Cypher
            .Match("(u: User), (a: Activity)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            .Create("(u)-[r:Comment $comment]->(a)")
            .WithParam("comment", comment)
            .ExecuteWithoutResultsAsync();

        return Ok();
    }
    
    [HttpDelete("{user_id}/RemoveAttends/{activity_id}")]
    public async Task<IActionResult> RemoveAttending(Guid user_id, Guid activity_id)
    {
        await _client.Cypher
            .Match("(u: User)-[rel]->(a: Activity)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            .Delete("rel")
            .ExecuteWithoutResultsAsync();

        return Ok();

    }

    [HttpGet("{user_id}/ActivityComments/{activity_id}")]
    public async Task<IActionResult> GetActivityComments(Guid user_id, Guid activity_id)
    {
        var comments = await _client.Cypher
            .Match("(u: User)-[rel:Comment]->(a: Activity)")
            .Where((NeoActivity a, NeoUser u) => a.id == activity_id && u.id == user_id)
            .Return(rel => rel.As<NeoComments>()).ResultsAsync;

        return Ok(comments);
    }
    
    [HttpGet("{user_id}/ActivityComments/")]
    public async Task<IActionResult> GetComments(Guid user_id)
    {
        var comments = await _client.Cypher
            .Match("(u: User)-[rel:Comment]->(a: Activity)")
            .Where((NeoUser u) => u.id == user_id)
            .Return(rel => rel.As<NeoComments>()).ResultsAsync;

        return Ok(comments);
    }

}