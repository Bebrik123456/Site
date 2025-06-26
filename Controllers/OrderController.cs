using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using MySql.Data.MySqlClient;
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
    public IActionResult Lox(OrderRequest request, Exception ex)
    {
        // Здесь логика: сохранение в БД, отправка email и т.д.
        string connectionString = "Server=localhost;Database=Hookah;UserId=root;Password=;";;
        string command = "INSERT INTO `order` (`Name`, `Phone`, `Date`, `Guests`, `Description`,`Deadline`) VALUES (@name, @phone, @date, @guests, @description, @deadline)";
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();
        MySqlCommand cmd = new MySqlCommand(command, connection);

        try
        {
            cmd.Parameters.AddWithValue("@name", request.Name);
            cmd.Parameters.AddWithValue("@phone", request.Tel);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@guests", request.Guests);
            cmd.Parameters.AddWithValue("@description", request.Description);
            cmd.Parameters.AddWithValue("@deadline", request.EventDate);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }
        catch
        {
            Console.WriteLine(ex);
            return RedirectToAction("Index", "Home");
        }
    }

 
}