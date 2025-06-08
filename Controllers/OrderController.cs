namespace Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;

public class OrderController : Controller
{
    // Отображает форму (GET)
    public IActionResult Index()
    {
        return View();
    }

    // Обрабатывает отправку (POST)
    [HttpPost]
    public IActionResult Submit(OrderRequest request)
    {
        // Здесь логика: сохранение в БД, отправка email и т.д.
        Console.WriteLine($"Заказ от {request.Name}, тел.: {request.Phone}");

        // Перенаправляем на "Спасибо"
        return RedirectToAction("ThankYou");
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}