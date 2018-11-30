namespace SmartCore.Tests.DataAccess
{
	public class ItemFileLink
	{
		public int ItemId { get; set; }
		public bool IsDeleted { get; set; }
		public int ParentId { get; set; }
		public int ParentTypeId { get; set; }
		public short LinkTypeId { get; set; }
		public int? FileId { get; set; }


		public NonRoutineJob NonRoutineJob { get; set; }
	}
}