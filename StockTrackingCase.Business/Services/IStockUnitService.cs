using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Business.Services;
public interface IStockUnitService
{
    Response<StockUnit> Add(AddStockUnitDto request);
    Response<StockUnit> RemoveById(Guid id);
    Response<List<StockUnit>> GetAll();
}
