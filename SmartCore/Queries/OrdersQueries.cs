using EntityCore.DTO;

namespace SmartCore.Queries
{
	public static class OrdersQueries
	{
		public static string InitialSearch(string text) => $@"SELECT DISTINCT  i.ParentPackageId from InitionalOrderRecords i
			inner join Dictionaries.AccessoryDescriptions d on i.ProductId = d.ItemId
			where i.IsDeleted = 0 and d.PartNumber like '%{text}%'";
	}
}