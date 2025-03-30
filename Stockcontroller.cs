using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.DTOs.Stock;  // Assuming you have the Stock model in this namespace
using System.Linq;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET api/stock
        [HttpGet]
        public IActionResult GetAll()
        {
            // Fetch all stocks from the database
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);  // Return all stocks as a response
        }

        // GET api/stock/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Find stock by id
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();  // Return 404 if stock not found
            }
            return Ok(stock);  // Return the stock as a response if found
        }

        // POST api/stock
        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDTO) // Data to be stored in JSON
        {
            // Convert the DTO to the stock model
            var stockModel = new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap,
            };

            // Add the new stock to the database
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();  // Save the changes to the database

            // Return the created stock with a 201 status and location
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);  
        }

        // PUT api/stock/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Stock stock)
        {
            // Find the existing stock in the database by id
            var existingStock = _context.Stocks.Find(id);

            if (existingStock == null)
            {
                return NotFound();  // Return 404 if the stock doesn't exist
            }

            // Update the stock properties with new values from the request body
            existingStock.Symbol = stock.Symbol;
            existingStock.CompanyName = stock.CompanyName;
            existingStock.Purchase = stock.Purchase;
            existingStock.LastDiv = stock.LastDiv;
            existingStock.Industry = stock.Industry;
            existingStock.MarketCap = stock.MarketCap;

            // Save the updated stock in the database
            _context.SaveChanges();

            // Return the updated stock data
            return Ok(existingStock);  
        }

        // DELETE api/stock/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the stock by id in the database
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();  // Return 404 if stock is not found
            }

            // Remove the stock from the database
            _context.Stocks.Remove(stock);  
            _context.SaveChanges();  // Commit the changes to the database

            return NoContent();  // Return 204 No Content after successful deletion
        }
    }
}
