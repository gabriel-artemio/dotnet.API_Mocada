using Microsoft.AspNetCore.Mvc;
using MinhaWebAPI.Models;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private static List<Item> _itens = new List<Item>
        {
            new Item { Id = 1, Nome = "Item 1", Preco = 10.99m },
            new Item { Id = 2, Nome = "Item 2", Preco = 20.49m },
            new Item { Id = 3, Nome = "Item 3", Preco = 5.99m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return _itens;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = _itens.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            item.Id = _itens.Count + 1;
            _itens.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Item item)
        {
            var index = _itens.FindIndex(i => i.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            _itens[index] = item;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _itens.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _itens.Remove(item);
            return NoContent();
        }
    }
}