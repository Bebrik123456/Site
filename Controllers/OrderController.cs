using Microsoft.AspNetCore.Mvc.Razor.Compilation;
namespace Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using MySql.Data;

public class OrderController : Controller
{
    // Отображает форму (GET)
    public IActionResult Index()
    {
        return View();
    }

    // Обрабатывает отправку (POST)
    [HttpPost]
    public IActionResult Lox(OrderRequest request)
    {
        // Здесь логика: сохранение в БД, отправка email и т.д.
     //   Console.WriteLine($"Заказ от {request.Name}, тел.: {request.Phone}");
     
        
     
         Console.WriteLine("Заказ сделан ");
         return RedirectToAction("Index", "Home"); 
    }

 
}