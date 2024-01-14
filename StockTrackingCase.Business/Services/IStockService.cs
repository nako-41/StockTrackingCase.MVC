using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Business.Services;
public interface IStockService
{
    Response<Stock> Add(AddStockDto request);
    Response<Stock> RemoveById(Guid id);
    Response<List<Stock>> GetAll();
    Response<Stock> Update(Guid id);
}
