using CRUD_app.Models;

namespace CRUD_app.ViewModels
{
	public class OrderInfoViewModel
	{
		public List<OrderItem> Items { get; set; }
		public Order Order { get; set; }
		public List<Provider> Providers { get; set; }
	}
}
