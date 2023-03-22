using CRUD_app.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUD_app.ViewModels
{
	public class OrderViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Заполните номер заказа")]
		public string Number { get; set; }

		[Required(ErrorMessage = "Заполните дату заказа")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "Заполните ID заказа")]
		public int ProviderId {get; set; }
	}
}
