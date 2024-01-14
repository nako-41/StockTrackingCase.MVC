using StockTrackingCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Entities.DTOs;
public sealed class StockUnitIndexDto
{
    public List<StockUnit> StockUnits { get; set; } = new();
    public List<Stock> Stocks { get; set; } = new();
}

