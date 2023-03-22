using System.ComponentModel.DataAnnotations;
using TanvirArjel.CustomValidation.Attributes;

namespace CRUD_app.ViewModels
{
	public class FiltersViewModel
	{
		[CompareTo(nameof(EndDate), ComparisonType.SmallerThanOrEqual)]
		public DateTime StartingDate { get; set; }

		[CompareTo(nameof(StartingDate), ComparisonType.GreaterThanOrEqual)]
		public DateTime EndDate { get; set; }
	}
}
