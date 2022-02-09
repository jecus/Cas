using System.Collections.Generic;
using System.ComponentModel;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EditionRevisionListView : BaseGridViewControl<CheckListRevision>
	{
        public EditionRevisionListView()
        {
            InitializeComponent();
        }

		#region Methods


        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("№", (int)(radGridView1.Width * 0.20f));
            AddColumn("Type", (int)(radGridView1.Width * 0.24f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.24f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckListRevision item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>();

            subItems.Add(CreateRow(item.Number, item.Number));
            subItems.Add(CreateRow(item.Type.ToString(), item.Type));
            subItems.Add(CreateRow(author, author));

            return subItems;
        }

        #endregion

        
        #endregion
        
    }
}
