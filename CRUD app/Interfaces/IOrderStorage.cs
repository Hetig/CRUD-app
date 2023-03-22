using CRUD_app.Models;

namespace CRUD_app.Interfaces
{
	public interface IOrderStorage
	{
		List<Order> GetAll();
		void Delete(int order);

		void Add(Order newOrder);
		List<Provider> GetProviders();
		Order TryGetById(int id);
		List<OrderItem> GetItemsById(int id);
		void AddItem(OrderItem orderItem);
		void DeleteItem(int itemId);
		void ChangeProvider(int orderId, int providerId);
		void Edit(Order newOrder);
	}
}