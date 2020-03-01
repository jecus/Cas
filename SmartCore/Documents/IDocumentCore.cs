using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace SmartCore.Documents
{
	public interface IDocumentCore
	{
		List<Document> GetDocuments(BaseEntityObject parent, DocumentType docType, bool onlyOperatorDocs = false);

		List<Document> GetDocumentsByParentType(BaseEntityObject parent, DocumentType docType);

		List<Document> GetAircraftDocuments(Aircraft parentAircraft, DocumentType type = null);

		List<Document> GetOperatorDocuments(Operator parentOperator);

		List<Document> GetOperatorDocuments(Operator parentOperator, DocumentType docType);

		void SaveDocumentsList(BaseEntityObject parent, IList<Document> unsavedDocuments);
	}
}