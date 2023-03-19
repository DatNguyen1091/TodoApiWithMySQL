using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoitemsController : Controller
    {
        private readonly TodoitemsContext _context;

        public TodoitemsController(TodoitemsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("/Todoitems/Complete")]
        public ActionResult GetComplete()
        {
            return Ok(_context.Products.Where(pr => (bool)pr.CompletePr!));
        }

        [HttpGet("/Todoitems/{id}")]
        public ActionResult GetItems(int id)
        {
            var item = _context.Products.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public ActionResult PostItems(Product pr)
        {
            _context.Products.Add(pr);
            _context.SaveChanges();
            return Created("Todoitems", pr);
        }

        [HttpPut("{id}")]
        public ActionResult PutItems(Product pr, int id)
        {
            var Item = _context.Products.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            else
            {
                Item.NamePr = pr.NamePr;
                Item.PricePr = pr.PricePr;
                Item.CompletePr = pr.CompletePr;
                _context.SaveChanges();
                return NoContent();
            }               
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItems(int id)
        {
            var Item = _context.Products.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(Item);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
