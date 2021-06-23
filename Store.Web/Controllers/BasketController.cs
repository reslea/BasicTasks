using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public BasketController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> Create()
        {
            var basket = new Basket();
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();

            return Ok(basket);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Basket>> Get(int id)
        {
            var basket = await _context.Baskets
                .Include(b => b.BasketItems)
                .ThenInclude(_ => _.Product)
                .Select(b => new
                {
                    Id = b.Id,
                    BasketItems = b.BasketItems.Select(bi => new
                    {
                        Id = bi.Id,
                        ProductId = bi.ProductId,
                        Product = bi.Product,
                        BasketId = bi.BasketId,
                        Count = bi.Count
                    }),
                    IsPayed = b.IsPayed
                })
                .FirstOrDefaultAsync(b => b.Id == id);

            return Ok(basket);
        }

        [HttpGet("{id:int}/count")]
        public async Task<ActionResult> ItemsCount(int id)
        {
            var basketItemsCount = await _context.Baskets
                .Include(b => b.BasketItems)
                .Where(b => b.Id == id)
                .Select(b => b.BasketItems.Count())
                .FirstAsync();

            return Ok(new { basketItemsCount });
        }

        [HttpPost("{id:int}/close")]
        public async Task<ActionResult> CloseBasket(int id)
        {
            var basket = await _context.Baskets
                .FirstOrDefaultAsync(b => b.Id == id);

            basket.IsPayed = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("item")]
        public async Task<ActionResult<BasketItem>> AddItem(BasketItem item)
        {
            await _context.BasketItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }
    }
}
