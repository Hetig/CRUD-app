using CRUD_app.Models;

namespace CRUD_app.ViewModels
{
	public class IndexViewModel
	{
		public FiltersViewModel Filters { get; set; }
		public List<Order> Orders { get; set; }
	}
}
