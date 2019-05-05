using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface ILogistic : IBaseEntityObject
	{
		[Filter("Number:", Order = 1)]
		string Number { get; set; }

		[Filter("Title:", Order = 2)]
		string Title { get; set; }

		[Filter("Author:", Order = 3)]
		string Author { get; set; }

		[Filter("PublishedByUser:", Order = 4)]
		string PublishedByUser { get; set; }

		[Filter("CloseByUser:", Order = 5)]
		string CloseByUser { get; set; }

		[Filter("Remarks:", Order = 6)]
		string Remarks { get; set; }

		[Filter("OpeningDate:", Order = 7)]
		DateTime OpeningDate { get; set; }

		[Filter("PublishingDate:", Order = 8)]
		DateTime PublishingDate { get; set; }

		[Filter("ClosingDate:", Order = 9)]
		DateTime ClosingDate { get; set; }

		[Filter("Status:", Order = 10)]
		WorkPackageStatus Status { get; set; }

		int CorrectorId { get; set; }

		int ClosedById { get; set; }

		int PublishedById { get; set; }
	}
}