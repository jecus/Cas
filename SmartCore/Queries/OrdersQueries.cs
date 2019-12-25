namespace SmartCore.Queries
{
	public static class OrdersQueries
	{
		public static string InitialSearch(string text) => $@"SELECT DISTINCT  i.ParentPackageId from InitionalOrderRecords i
			inner join Dictionaries.AccessoryDescriptions d on i.ProductId = d.ItemId
			where i.IsDeleted = 0 and d.PartNumber like '%{text}%'";

		public static string QuotationSearch(string text) => $@"SELECT DISTINCT  i.ParentPackageId from RequestForQuotationRecords i
			inner join Dictionaries.AccessoryDescriptions d on i.PackageItemId = d.ItemId
			where i.IsDeleted = 0 and d.PartNumber like '%{text}%'";

		public static string PurchaseSearch(string text) => $@"SELECT DISTINCT  i.ParentPackageId from PurchaseRequestsRecords i
			inner join Dictionaries.AccessoryDescriptions d on i.PackageItemId = d.ItemId
			where i.IsDeleted = 0 and d.PartNumber like '%{text}%'";
	}
}