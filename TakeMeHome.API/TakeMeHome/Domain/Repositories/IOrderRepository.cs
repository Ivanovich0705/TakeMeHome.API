using TakeMeHome.API.TakeMeHome.Domain.Models;

namespace TakeMeHome.API.TakeMeHome.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(int id);
    Task<IEnumerable<Order>> FindByOrderStatusId(string orderStatusId);
    void Update(Order order);
    void Remove(Order order);
}