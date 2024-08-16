using BurgerManiaProject.Data;
using BurgerManiaProject.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : ControllerBase
{
    private readonly BurgerMgmtDbContext _context;

    public CartItemController(BurgerMgmtDbContext context)
    {
        _context = context;
    }

    // POST: api/CartItem
    [HttpPost]
    public async Task<ActionResult<CartItems>> AddCartItem([FromBody] CartItems cartItem)
    {
        _context.CartItems.Add(cartItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartItemId }, cartItem);
    }

    // Optional: Get a specific CartItem (if needed)
    [HttpGet("{id}")]
    public async Task<ActionResult<CartItems>> GetCartItem(int id)
    {
        var cartItem = await _context.CartItems.FindAsync(id);

        if (cartItem == null)
        {
            return NotFound("CartItem not found.");
        }

        return Ok(cartItem);
    }
}
