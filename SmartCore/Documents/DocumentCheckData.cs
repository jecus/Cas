using SmartCore.Entities.Dictionaries;

namespace SmartCore.Documents
{
	public class DocumentCheckData
	{
		public int DocumentId { get; set; }
		public DocumentType DocumentType { get; set; }
		public DocumentSubType DocumentSubType { get; set; }
	}
}