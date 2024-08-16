using BurgerManiaProject.Data;
using BurgerManiaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly BurgerMgmtDbContext _context;

    public UserController(BurgerMgmtDbContext context)
    {
        _context = context;
    }

     [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPost("{login}")]
    public async Task<ActionResult<User>> Login([FromBody] User loginUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.MobileNumber == loginUser.MobileNumber && u.Name == loginUser.Name);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpGet("mobile/{mobileNumber}")]
    public async Task<ActionResult<User>> GetUserByMobileNumber(string mobileNumber)
    {
        // Assuming mobileNumber is stored as a string in the database
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.MobileNumber == mobileNumber);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(string mobileNumber, string name)
    {
        // Check if the user already exists
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.MobileNumber == mobileNumber);

        if (existingUser != null)
        {
            return Conflict("User with this mobile number already exists.");
        }

        var user = new User { MobileNumber = mobileNumber, Name = name };

        try
        {
            // Add the user to the context
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); // Save changes to ensure the user is created

            // Now you can safely create a cart or any related entity
            var cart = new Cart { UserId = user.UserId }; // Assuming UserId is the primary key
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync(); // Save changes for the cart

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }
        catch (DbUpdateException ex)
        {
            // Handle the exception (log it, return an error response, etc.)
            return BadRequest("An error occurred while creating the user.");
        }
    }
}
