﻿namespace CRUD_app.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public Order Order { get; set; }
		public string Name { get; set; }
		public decimal Quantity { get; set; }
		public string Unit { get; set; }
	}
}
