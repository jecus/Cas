using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface ILogistic : IBaseEntityObject
	{
		[Filter("Number:", Order = 1)]
		string Number { get; }

		[Filter("NumTitleber:", Order = 2)]
		string Title { get; }

		[Filter("Author:", Order = 3)]
		string Author { get; }

		[Filter("PublishedByUser:", Order = 4)]
		string PublishedByUser { get; }

		[Filter("CloseByUser:", Order = 5)]
		string CloseByUser { get; }

		[Filter("Remarks:", Order = 6)]
		string Remarks { get; }

		[Filter("OpeningDate:", Order = 7)]
		DateTime OpeningDate { get; }

		[Filter("PublishingDate:", Order = 8)]
		DateTime PublishingDate { get; }

		[Filter("ClosingDate:", Order = 9)]
		DateTime ClosingDate { get; }

		[Filter("Status:", Order = 10)]
		WorkPackageStatus Status { get; }

		int CorrectorId { get; }
	}
}