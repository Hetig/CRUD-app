using CRUD_app.Models;
using System.Linq.Expressions;

namespace CRUD_app.Interfaces
{
	public class OrderStorage : IOrderStorage
	{
		private readonly DatabaseContext databaseContext;
		public OrderStorage(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public List<Order> GetAll()
		{
			return databaseContext.Orders.ToList();
		}

		public void Add(Order newOrder)
		{
			databaseContext.Orders.Add(newOrder);
			databaseContext.SaveChanges();
		}

		public void Delete(int orderId)
		{
			var order = TryGetById(orderId);
			databaseContext.Orders.Remove(order); 
			databaseContext.SaveChanges();
		}

		public List<Provider> GetProviders()
		{
			return databaseContext.Providers.ToList();
		}

		public Order TryGetById(int orderId)
		{
			return databaseContext.Orders.FirstOrDefault(o => o.Id == orderId);
		}

		public List<OrderItem> GetItemsById(int id)
		{
			return databaseContext.OrderItems.Where(x => x.Order.Id == id).ToList();
		}

		public void AddItem(OrderItem orderItem)
		{
			databaseContext.OrderItems.Add(orderItem);
			databaseContext.SaveChanges();
		}

		public void DeleteItem(int itemId)
		{
			var orderItem = databaseContext.OrderItems.FirstOrDefault(o => o.Id == itemId);

			databaseContext.OrderItems.Remove(orderItem);
			databaseContext.SaveChanges();
		}

		public void ChangeProvider(int orderId, int providerId)
		{
			var order = TryGetById(orderId);
			var provider = databaseContext.Providers.FirstOrDefault(p => p.Id == providerId);

			order.Provider = provider;
			databaseContext.SaveChanges();
		}

		public void Edit(Order newOrder)
		{
			var order = TryGetById(newOrder.Id);

			order.Number = newOrder.Number;
			order.Date = newOrder.Date;

			databaseContext.SaveChanges();
		}

	}
}
