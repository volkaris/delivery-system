using testTask.DbContexts;
using testTask.Models;

namespace testTask.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;

    public OrderService(OrderDbContext context)
    {
        _context = context;
    }

    public void Create(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();

    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders.ToList();
    }
}