using Microsoft.AspNetCore.Mvc;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.MVC.Controllers;
public class StockUnitsController(
    IStockUnitService stockUnitService,
    IStockService stockService, ILogger<StockUnitsController> _logger) : Controller
{
    public IActionResult Index()
    {
        List<StockUnit>? stockUnits = stockUnitService.GetAll().Data;
        List<Stock>? stocks = stockService.GetAll().Data;

        _logger.LogInformation("Stok Birim cagrildi");

        StockUnitIndexDto response = new()
        {
            Stocks = stocks ?? new(),
            StockUnits = stockUnits ?? new()
        };

        return View(response);
    }

    [HttpPost]
    public IActionResult Add(AddStockUnitDto request)
    {
        //var response = stockUnitService.Add(request);

        //if (!response.IsSuccess)
        //{
        //    TempData["Error"] = response.ErrorMessage;
        //}

        //return RedirectToAction("Index");

        try
        {
            var response = stockUnitService.Add(request);

            if (!response.IsSuccess)
            {
                TempData["Error"] = response.ErrorMessage;
            }

            _logger.LogInformation("Yeni stokBirim eklendi: {Type}", request.Type);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Stok eklenirken bir hata oluştu.");
            TempData["Error"] = "Stok eklenirken bir hata oluştu.";
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        //var response = stockUnitService.RemoveById(id);

        //if (!response.IsSuccess)
        //{
        //    TempData["Error"] = response.ErrorMessage;
        //}

        //return RedirectToAction("Index");

        try
        {
            var response = stockUnitService.RemoveById(id);

            if (!response.IsSuccess)
            {
                TempData["Error"] = response.ErrorMessage;
            }

            _logger.LogInformation("Stok silindi. Stok Id: {StockId}", id);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Stok silinirken bir hata oluştu.");
            TempData["Error"] = "Stok silinirken bir hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
