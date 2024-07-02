using Microsoft.AspNetCore.Mvc;
using testTask.Models;
using testTask.Services;

namespace testTask.Controllers;

public class OrderController : Controller, IOrderController
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] Order order)
    {
        _service.Create(order);
        return RedirectToAction("Index");
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        return View(_service.GetAll());
    }
}