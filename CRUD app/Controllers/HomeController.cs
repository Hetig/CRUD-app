using CRUD_app.Interfaces;
using CRUD_app.Models;
using CRUD_app.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CRUD_app.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOrderStorage orderStorage;
		public HomeController(IOrderStorage orderStorage)
		{
			this.orderStorage = orderStorage;
		}

		public IActionResult Index()
		{
			return View(new IndexViewModel { Orders = orderStorage.GetAll() });
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(OrderViewModel orderViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(orderViewModel);
			}

			var order = new Order { Date = orderViewModel.Date, Number = orderViewModel.Number, Provider = orderStorage.GetProviders().First() };
			orderStorage.Add(order);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult SortForDate(FiltersViewModel filters)
		{
			if (!ModelState.IsValid)
			{
				return View("Index", new IndexViewModel { Orders = orderStorage.GetAll() });
			}

			var orders = orderStorage.GetAll().Where(order => order.Date >= filters.StartingDate && order.Date <= filters.EndDate).ToList();
			return View("Index", new IndexViewModel { Orders = orders, Filters = filters });
		}

		public IActionResult Order(int orderId)
		{
			var orderItems = orderStorage.GetItemsById(orderId);
			var order = orderStorage.TryGetById(orderId);
			var providers = orderStorage.GetProviders();

			return View(new OrderInfoViewModel { Items = orderItems, Order = order, Providers = providers });
		}

		public IActionResult Delete(int orderId)
		{
			orderStorage.Delete(orderId);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int orderId)
		{
			ViewBag.OrderId = orderId;
			return View();
		}

		[HttpPost]
		public IActionResult Edit(OrderViewModel orderViewModel)
		{
			var order = new Order
			{
				Id = orderViewModel.Id,
				Date = orderViewModel.Date,
				Number = orderViewModel.Number,
			};

			orderStorage.Edit(order);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeProvider(int orderId, int providerId)
		{
			orderStorage.ChangeProvider(orderId, providerId);
			return RedirectToAction("Index");
		}

		public IActionResult AddItem(int orderId)
		{
			ViewBag.OrderId = orderId;
			return View();
		}

		[HttpPost]
		public IActionResult AddItem(OrderItemViewModel orderItem)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.OrderId = orderItem.OrderId;
				return View(orderItem);
			}

			var order = new OrderItem
			{
				Name = orderItem.Name,
				Quantity = orderItem.Quantity,
				Unit = orderItem.Unit,
				Order = orderStorage.TryGetById(orderItem.OrderId)
			};

			orderStorage.AddItem(order);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteItem(int itemId)
		{
			orderStorage.DeleteItem(itemId);
			return RedirectToAction("Index");
		}
	}
}