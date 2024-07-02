using Microsoft.AspNetCore.Mvc;
using testTask.Models;

namespace testTask.Controllers;

public interface IOrderController
{
    public IActionResult Create(Order order);
    public IActionResult GetAll();
}