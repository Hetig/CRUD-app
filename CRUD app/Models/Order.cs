namespace CRUD_app.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string Number { get; set; }
		public DateTime Date { get; set; }
		public Provider? Provider { get; set; }
	}
}
