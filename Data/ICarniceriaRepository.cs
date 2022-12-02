using System.Collections.Generic;
using CarniceriaWebApp.Data.Entities;


namespace CarniceriaWebApp.Data
{
    public interface ICarniceriaRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string Category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);

        void AddEntity(object entity);

        bool SaveAll();
    }
}