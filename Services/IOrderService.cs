using testTask.Models;

namespace testTask.Services;

public interface IOrderService
{
    public void Create(Order order);
    public IEnumerable<Order> GetAll();
}