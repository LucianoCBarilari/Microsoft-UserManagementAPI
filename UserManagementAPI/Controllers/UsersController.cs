using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> _users = [];
    private static int _nextId = 1;

    // GET /api/users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        return Ok(_users);
    }

    // GET /api/users/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound(new { error = $"User with ID {id} was not found." });

        return Ok(user);
    }

    // POST /api/users
    [HttpPost]
    public ActionResult<User> Create([FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            Id = _nextId++,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        _users.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public ActionResult<User> Update(int id, [FromBody] UpdateUserRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound(new { error = $"User with ID {id} was not found." });

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        return Ok(user);
    }

    // DELETE /api/users/{id}
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound(new { error = $"User with ID {id} was not found." });

        _users.Remove(user);
        return NoContent();
    }
}
