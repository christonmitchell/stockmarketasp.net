using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers // extension method
    {
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            // Map properties from Stock model to StockDTO
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }

        // Map CreateStockRequestDto to Stock model
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockRequestDto)
        {
            return new Stock
            {
                Symbol = stockRequestDto.Symbol,  // Fixed: Use the properties from stockRequestDto
                CompanyName = stockRequestDto.CompanyName,
                Purchase = stockRequestDto.Purchase,
                LastDiv = stockRequestDto.LastDiv,
                Industry = stockRequestDto.Industry,
                MarketCap = stockRequestDto.MarketCap,  // Fixed: Use the correct property
            };
        }
    }
}
