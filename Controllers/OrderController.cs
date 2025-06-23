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
    public IActionResult Lox(OrderRequest request)
    {
        // Здесь логика: сохранение в БД, отправка email и т.д.
  //string connectionString = "Server=localhost;Database=Hookah;UserId=root;Password=;";;
  //string command = "INSERT INTO `order` ( `id`, `Name`, `Phone`, `Date`, `Guests`, `Description`) VALUES ( @id, @name, @phone, @date, @guests, @description) ";
  //MySqlConnection connection = new MySqlConnection(connectionString);
  //connection.Open();
  //MySqlCommand cmd = new MySqlCommand(command, connection);
  //cmd.Parameters.AddWithValue("id", "1");
  //cmd.Parameters.AddWithValue("@name", "Вася");
  //cmd.Parameters.AddWithValue("@phone", "88888888");
  //cmd.Parameters.AddWithValue("@date", DateTime.Now);
  //cmd.Parameters.AddWithValue("@guests", "7");
  //cmd.Parameters.AddWithValue("@description", "Здесь типа описание");
  //cmd.ExecuteNonQuery();

        
        
         Console.WriteLine(request.Name);
         return RedirectToAction("Index", "Home");
    }

 
}