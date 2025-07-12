using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

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
  
public async Task<IActionResult> Lox(OrderRequest request)
{
    string connectionString = "Server=localhost;Port=3306;Database=cr30805_hookah;UserId=cr30805;Password=xzR54rwiN#vV;SslMode=None;ConnectionTimeout=30;";
    
    try
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();
            
            string command = @"INSERT INTO `order` (`Name`, `Phone`, `Date`, `Guests`, `Description`, `Deadline`) VALUES (@name, @phone, @date, @guests, @description, @deadline)";

            using (var cmd = new MySqlCommand(command, connection))
            {
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@phone", request.Tel);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@guests", request.Guests);
                cmd.Parameters.AddWithValue("@description", request.Description ?? "");
                cmd.Parameters.AddWithValue("@deadline", request.EventDate);
                
                await cmd.ExecuteNonQueryAsync();
                await Message(request.Name);
                
                // Добавляем временную переменную для уведомления
                TempData["SuccessMessage"] = "Заказ успешно создан!";
            }
        }
        
        return RedirectToAction("Index", "Home");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        TempData["ErrorMessage"] = "Заказ создан";
        return RedirectToAction("Index", "Home");
    }
}

private async Task Message(string userName)
{
    try
    {
        var botToken = "7000867226:AAFHZjmGfVVsHrC5hT5RNqEyCyJZvPCi7EA"; // В кавычках!
        var chatId = "1054580792";
        var message = $"Новый заказ от {userName}";
        var encodedMessage = Uri.EscapeDataString(message);
        
        using (var httpClient = new HttpClient())
        {
            var url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={encodedMessage}";
            var response = await httpClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ошибка Telegram: {error}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка отправки в Telegram: {ex.Message}");
    }
}



}