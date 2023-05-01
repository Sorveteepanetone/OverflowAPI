using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using SpotlessAPI.Context;
using SpotlessAPI.Models;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace SpotlessAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly EFContext _efContext;
    
    public UserController(EFContext efContext)
    {
        _efContext = efContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await _efContext.Users.AsQueryable().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await _efContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        _efContext.Users.Add(user);
        await _efContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        _efContext.Entry(user).State = EntityState.Modified;
        await _efContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _efContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _efContext.Users.Remove(user);
        await _efContext.SaveChangesAsync();

        return Ok();
    }
}
