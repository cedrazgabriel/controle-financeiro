namespace controle_financeiro.Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsersController(UserContext context) : ControllerBase
{
    //Health check
    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return NoContent();
    }
}