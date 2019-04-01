using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Quality
{
    #region public class ProcedureDocumentReference : BaseEntityObject

    [Table("ProcedureDocumentReferences", "dbo", "ItemId")]
    [Dto(typeof(ProcedureDocumentReferenceDTO))]
	[Condition("IsDeleted", "0")]
    public class ProcedureDocumentReference : BaseEntityObject
    {
        #region public Procedure Procedure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("ProcedureId")]
        [Parent]
        public Procedure Procedure { get; set; }

        #endregion

        #region public Document Document { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DocumentId")]
        [ListViewData(0.2f, "Document")]
        [FormControl(120, "Document")]
        [NotNull]
        [Child]
        public Document Document { get; set; }

        #endregion

        public ProcedureDocumentReference()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.ProcedureDocumentReference;
        }
    }
    #endregion

}
