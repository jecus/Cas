using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CheckListRevisionView : BaseGridViewControl<CheckLists>
	{
        public CheckListRevisionView()
        {
            InitializeComponent();

            ColumnIndexes = new List<string>()
            {
                "Section №", "Part №","SubPart №","Item №"
            };
            SortDirection = SortDirection.Desc;
            EnableCustomSorting = true;

            this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
        }

		#region Methods

        protected override void GroupingItems()
        {
            this.radGridView1.GroupDescriptors.Clear();
			var descriptor = new GroupDescriptor();
            foreach (var colName in new List<string>{ "Section №" , "Section Name" , "Part №" , "Part Name", "SubPart №","SubPart Name" })
                descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
            this.radGridView1.GroupDescriptors.Add(descriptor);

            
		}

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Section №", (int)(radGridView1.Width * 0.20f));
            AddColumn("Section Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart №", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Item №", (int)(radGridView1.Width * 0.2f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.12f));
            AddColumn("Next Edition", (int)(radGridView1.Width * 0.12f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.12f));
            AddColumn("Next Revision", (int)(radGridView1.Width * 0.12f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.12f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>();

            subItems.Add(CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber));
            subItems.Add(CreateRow(item.Settings.SectionName, item.Settings.SectionName));
            subItems.Add(CreateRow(item.Settings.PartNumber, item.Settings.PartNumber));
            subItems.Add(CreateRow(item.Settings.PartName, item.Settings.PartName));
            subItems.Add(CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber));
            subItems.Add(CreateRow(item.Settings.SubPartName, item.Settings.SubPartName));
            subItems.Add(CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber));

            subItems.Add(CreateRow(item.EditionNumber, item.EditionNumber));
            subItems.Add(CreateRow(item.NextEditionNumber, item.NextEditionNumber));
            
            subItems.Add(CreateRow(item.RevisionNumber, item.RevisionNumber));
            subItems.Add(CreateRow(item.NextRevisionNumber, item.NextRevisionNumber));
            
            
            subItems.Add(CreateRow(author, author));

            return subItems;
        }

        #endregion

        
        #endregion
        
    }
}
