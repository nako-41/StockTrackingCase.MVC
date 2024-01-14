using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Entities.Models;
public sealed class StockUnit
{
    public StockUnit()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    [ForeignKey("Stock")]
    public Guid StockId { get; set; }
    public Stock? Stock { get; set; }

    public string UnitCode { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public string PurchasePriceCurrency { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public string SellingPriceCurrency { get; set; } = string.Empty;
    public int? PaperWeight { get; set; }
    public bool IsActive { get; set; } = true;

}