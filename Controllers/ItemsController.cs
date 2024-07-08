using Microsoft.AspNetCore.Mvc;
using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1" },
            new Item { Id = 2, Name = "Item2" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<Item> Post(Item item)
        {
            item.Id = items.Max(i => i.Id) + 1;
            items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
    }
}

