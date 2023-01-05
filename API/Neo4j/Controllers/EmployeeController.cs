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
public class EmployeeController : BaseApiController
{
    private readonly IGraphClient _client;

    public EmployeeController(IGraphClient client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
    {
        await _client.Cypher
            .Create("(employee:Employee $employee)")
            .WithParam("employee", employee)
            .ExecuteWithoutResultsAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var employees = await _client.Cypher
            .Match("(n: Employee)")
            .Return(n => n.As<Employee>()).ResultsAsync;

        return Ok(employees);
    }

    [HttpPost("{employee_id}/assign_employee/{department_id}")]
    public async Task<IActionResult> AssignDepartment(Guid employee_id, Guid department_id)
    {
        await _client.Cypher
            .Match("(d:Department), (e:Employee)")
            .Where((Department d, Employee e) => d.id == department_id && e.id == employee_id)
            
            /*
             * Merge Insures That Relationship is only added if it does not exist. 
             */
            
            .Merge("(d)-[r:HasEmployee]->(e)")
            .ExecuteWithoutResultsAsync();

        return Ok();

    }
    


}