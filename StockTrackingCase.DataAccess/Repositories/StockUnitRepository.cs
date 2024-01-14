using StockTrackingCase.DataAccess.Context;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.DataAccess.Repositories;
public sealed class StockUnitRepository : Repository<StockUnit>, IStockUnitRepository
{
    public StockUnitRepository(ApplicationDbContext context) : base(context)
    {
    }
}

