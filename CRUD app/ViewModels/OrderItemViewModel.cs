using System.ComponentModel.DataAnnotations;

namespace CRUD_app.ViewModels
{
	public class OrderItemViewModel
	{
		public int OrderId { get; set; }

		[Required(ErrorMessage = "Заполните поле названия")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Заполните поле количество")]
		public decimal Quantity { get; set; }

		[Required(ErrorMessage = "Заполните поле единица измерения")]
		public string Unit { get; set; }
	}
}
