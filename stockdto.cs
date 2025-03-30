using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class StockDTO
    {

        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty; //to avoid null ref errors
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; } // Store Divedends
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; } //Value of Company
