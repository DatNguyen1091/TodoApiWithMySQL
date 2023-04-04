using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Todoitems1Controller : ControllerBase
    {
        private readonly TodoitemsContext _context;

        public Todoitems1Controller(TodoitemsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _context.Products.ToListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
       
        [HttpGet("/Todoitems1/{id}")]
        public async Task<ActionResult> GetItems(int id)
        {
            var item = await _context.Products.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> PostItems(Product model)
        {            
            _context.Products?.Add(model);
            await _context.SaveChangesAsync();
            return Created("Todoitems1", model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutItems(Product model, int id)
        {         
            var Item = await _context.Products.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }
            else
            {              
                Item.NamePr = model.NamePr;
                Item.PricePr = model.PricePr;
                Item.CompletePr = model.CompletePr;
                await _context.SaveChangesAsync()!;
                return NoContent();
            }       
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItems(int id)
        {
           var Item = await _context.Products.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(Item);
                _context?.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
