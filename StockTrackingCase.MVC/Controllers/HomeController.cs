using Microsoft.AspNetCore.Mvc;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.MVC.Controllers;
public class HomeController(IStockService stockService, ILogger<HomeController> _logger) : Controller
{
   

    public IActionResult Index()
    {
        _logger.LogInformation(" Stok Dizin cagrildi");
        List<Stock>? stock = stockService.GetAll().Data;
        return View(stock);
    }
    

    [HttpPost]
    public IActionResult Add(AddStockDto request)
    {
        //var response = stockService.Add(request);

        //if (!response.IsSuccess)
        //{
        //    TempData["Error"] = response.ErrorMessage;
        //}

        //return RedirectToAction("Index");
        try
        {
            var response = stockService.Add(request);

            if (!response.IsSuccess)
            {
                TempData["Error"] = response.ErrorMessage;
            }

            _logger.LogInformation("Yeni stok eklendi: {Type}", request.Type);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Stok eklenirken bir hata oluþtu.");
            TempData["Error"] = "Stok eklenirken bir hata oluþtu.";
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        //var response = stockService.RemoveById(id);

        //if (!response.IsSuccess)
        //{
        //    TempData["Error"] = response.ErrorMessage;
        //}

        //return RedirectToAction("Index");
        try
        {
            var response = stockService.RemoveById(id);

            if (!response.IsSuccess)
            {
                TempData["Error"] = response.ErrorMessage;
            }

            _logger.LogInformation("Stok silindi. Stok Id: {StockId}", id);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Stok silinirken bir hata oluþtu.");
            TempData["Error"] = "Stok silinirken bir hata oluþtu.";
            return RedirectToAction("Index");
        }
    }


    [HttpGet]
    public IActionResult Update(Guid Id)
    {
        var response = stockService.Update(Id);

        if (!response.IsSuccess)
        {
            TempData["Error"] = response.ErrorMessage;
        }

        return View();
    }
}
