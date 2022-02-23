using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.CheckList.CheckListAudit;
using CAS.UI.UICAAControls.CheckList.EditionRevision.Iosa;
using CAS.UI.UICAAControls.CheckList.EditionRevision.Safa;
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
	public partial class CheckListView : BaseGridViewControl<CheckLists>
	{
        protected AnimatedThreadWorker _animatedThreadWorker;
        protected  bool _enable;

        #region Fields

		#endregion

		#region Constructors



        public CheckListView()
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

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CheckListView(AnimatedThreadWorker animatedThreadWorker, bool enable = true)
		{
            _animatedThreadWorker = animatedThreadWorker;
            _enable = enable;
            InitializeComponent();
            ColumnIndexes = new List<string>()
            {
                "Section №", "Part №","SubPart №","Item №"
            };
            SortDirection = SortDirection.Desc;
            EnableCustomSorting = true;

            this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
        }

        public bool IsAuditCheck { get; set; }
        public int? AuditId { get; set; }
        public bool IsRevision { get; set; }
        public int RevisionId { get; set; }
        

		#endregion

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
            AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
            AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
            AddColumn("Requirement", (int)(radGridView1.Width * 0.3f));
            AddColumn("Auditor Action", (int)(radGridView1.Width * 0.3f));
            AddColumn("Source", (int)(radGridView1.Width * 0.3f));
            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Remain", (int)(radGridView1.Width * 0.1f));
            AddColumn("Phase", (int)(radGridView1.Width * 0.1f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber),
                CreateRow(item.Settings.SectionName, item.Settings.SectionName),
                CreateRow(item.Settings.PartNumber, item.Settings.PartNumber),
                CreateRow(item.Settings.PartName, item.Settings.PartName),
                CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber),
                CreateRow(item.Settings.SubPartName, item.Settings.SubPartName),
                CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber),
                CreateRow(item.Settings.ItemtName, item.Settings.ItemtName),
                CreateRow(item.Settings.Requirement, item.Settings.Requirement),
                CreateRow("", ""),
                CreateRow(item.Source, item.Source),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.NextEditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.NextRevisionNumber),
                CreateRow(item.Remains.ToString(), item.Remains),
                CreateRow(item.Settings.Phase, item.Settings.Phase),
                CreateRow(author, author)
            };

            return subItems;
        }

        #endregion


        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				if (IsAuditCheck)
				{
					var form = new CheckListAuditForm(SelectedItem, AuditId.Value);
					if (form.ShowDialog() == DialogResult.OK)
                        _animatedThreadWorker.RunWorkerAsync();
				}
				else
				{
                    if (IsRevision)
                    {
                        if (SelectedItem.CheckUIType == CheckUIType.Iosa)
                        {
                            var form = new CheckListRevEditForm(SelectedItem,RevisionId);
                            if (form.ShowDialog() == DialogResult.OK)
                                _animatedThreadWorker.RunWorkerAsync();
                        }
                        else if (SelectedItem.CheckUIType == CheckUIType.Safa)
                        {
                            var form = new CheckListSAFARevEditForm(SelectedItem,RevisionId);
                            if (form.ShowDialog() == DialogResult.OK)
                                _animatedThreadWorker.RunWorkerAsync();
                        }
                        
                    }
                    else 
                    {
                        if (SelectedItem.CheckUIType == CheckUIType.Iosa)
                        {
                            var form = new CheckListForm.CheckListForm(SelectedItem,_enable);
                            if (form.ShowDialog() == DialogResult.OK)
                                _animatedThreadWorker.RunWorkerAsync();
                        }
                        else if (SelectedItem.CheckUIType == CheckUIType.Safa)
                        {
                            var form = new CheckListForm.CheckListSAFAForm(SelectedItem, _enable);
                            if (form.ShowDialog() == DialogResult.OK)
                                _animatedThreadWorker.RunWorkerAsync();
                        }
                        else if (SelectedItem.CheckUIType == CheckUIType.Icao)
                        {
                            var form = new CheckListForm.CheckListICAOForm(SelectedItem, _enable);
                            if (form.ShowDialog() == DialogResult.OK)
                                _animatedThreadWorker.RunWorkerAsync();
                        }
                        else e.Cancel = true;
                    }
                }
                
                e.Cancel = true;
			}
		}
		#endregion

        #region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

        protected override void SetItemColor(GridViewRowInfo listViewItem, CheckLists item)
        {
            var itemBackColor = UsefulMethods.GetColor(item);
            var itemForeColor = Color.Gray;

            foreach (GridViewCellInfo cell in listViewItem.Cells)
            {
                cell.Style.DrawFill = true;
                cell.Style.CustomizeFill = true;
                cell.Style.BackColor = UsefulMethods.GetColor(item);

                var listViewForeColor = cell.Style.ForeColor;

                if (listViewForeColor != Color.MediumVioletRed)
                    cell.Style.ForeColor = itemForeColor;
                cell.Style.BackColor = itemBackColor;
            }
        }


        #endregion


        #endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(CheckLists);

            DialogResult confirmResult =
                MessageBox.Show(this.SelectedItems.Count == 1
                        ? "Do you really want to delete " + typeName + " " + this.SelectedItems[0] + "?"
                        : "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                this.radGridView1.BeginUpdate();
                GlobalObjects.NewKeeper.Delete(this.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
                foreach (var audit in this.SelectedItems)
                {
                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update dbo.CheckListRecord set IsDeleted = 1 where CheckListId = {audit.ItemId}");

                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update [dbo].[AuditChecks] set IsDeleted = 1 where CheckListId = {audit.ItemId}");
                }
                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
        }

    }

    public class CheckListRevisionView : CheckListView
    {
        public CheckListRevisionView(AnimatedThreadWorker worker) : base(worker)
        {
            
        }
        
        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Status", (int)(radGridView1.Width * 0.1f));
            AddColumn("Section №", (int)(radGridView1.Width * 0.20f));
            AddColumn("Section Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart №", (int)(radGridView1.Width * 0.24f));
            AddColumn("SubPart Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
            AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
            AddColumn("Requirement", (int)(radGridView1.Width * 0.3f));
            AddColumn("Auditor Action", (int)(radGridView1.Width * 0.3f));
            AddColumn("Source", (int)(radGridView1.Width * 0.3f));
            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Remain", (int)(radGridView1.Width * 0.1f));
            AddColumn("Phase", (int)(radGridView1.Width * 0.1f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.RevisionStatus.ToString(), item.RevisionStatus),
                CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber),
                CreateRow(item.Settings.SectionName, item.Settings.SectionName),
                CreateRow(item.Settings.PartNumber, item.Settings.PartNumber),
                CreateRow(item.Settings.PartName, item.Settings.PartName),
                CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber),
                CreateRow(item.Settings.SubPartName, item.Settings.SubPartName),
                CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber),
                CreateRow(item.Settings.ItemtName, item.Settings.ItemtName),
                CreateRow(item.Settings.Requirement, item.Settings.Requirement),
                CreateRow("", ""),
                CreateRow(item.Source, item.Source),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.NextEditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.NextRevisionNumber),
                CreateRow(item.Remains.ToString(), item.Remains),
                CreateRow(item.Settings.Phase, item.Settings.Phase),
                CreateRow(author, author)
            };

            return subItems;
        }

        #endregion
    }
    
    
    
    public class CheckListSAFAView : CheckListView
    {
        public CheckListSAFAView() : base()
        {
            
        }
        
        public CheckListSAFAView(AnimatedThreadWorker worker, bool enable = true) :  base(worker, enable)
        {
        }
        
        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Source", (int)(radGridView1.Width * 0.24f));
            AddColumn("Inspection Item", (int)(radGridView1.Width * 0.24f));
            AddColumn("Inspection Title", (int)(radGridView1.Width * 0.24f));
            AddColumn("Standard", (int)(radGridView1.Width * 0.24f));
            AddColumn("Standard Ref", (int)(radGridView1.Width * 0.24f));
            AddColumn("PDF Code", (int)(radGridView1.Width * 0.24f));
            AddColumn("Category", (int)(radGridView1.Width * 0.24f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsSafa.Item, item.SettingsSafa.Item),
                CreateRow(item.SettingsSafa.Title, item.SettingsSafa.Title),
                CreateRow(item.SettingsSafa.Standard, item.SettingsSafa.Standard),
                CreateRow(item.SettingsSafa.StandardRef, item.SettingsSafa.StandardRef),
                CreateRow(item.SettingsSafa.PdfCode, item.SettingsSafa.PdfCode),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.EditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.RevisionNumber),

                CreateRow(author, author)
            };

            return subItems;
        }

        protected override void GroupingItems()
        {
            
        }

        #endregion
    }
    
    public class CheckListRevisionSAFAView : CheckListView
    {
        
        public CheckListRevisionSAFAView()  :  base()
        {
        }
        public CheckListRevisionSAFAView(AnimatedThreadWorker worker, bool enable = true)  :  base(worker, enable)
        {
        }
        
        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Status", (int)(radGridView1.Width * 0.24f));
            AddColumn("Source", (int)(radGridView1.Width * 0.24f));
            AddColumn("Inspection Item", (int)(radGridView1.Width * 0.24f));
            AddColumn("Inspection Title", (int)(radGridView1.Width * 0.24f));
            AddColumn("Standard", (int)(radGridView1.Width * 0.24f));
            AddColumn("Standard Ref", (int)(radGridView1.Width * 0.24f));
            AddColumn("PDF Code", (int)(radGridView1.Width * 0.24f));
            AddColumn("Category", (int)(radGridView1.Width * 0.24f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.RevisionStatus.ToString(), item.RevisionStatus),
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsSafa.Item, item.SettingsSafa.Item),
                CreateRow(item.SettingsSafa.Title, item.SettingsSafa.Title),
                CreateRow(item.SettingsSafa.Standard, item.SettingsSafa.Standard),
                CreateRow(item.SettingsSafa.StandardRef, item.SettingsSafa.StandardRef),
                CreateRow(item.SettingsSafa.PdfCode, item.SettingsSafa.PdfCode),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.EditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.RevisionNumber),
                CreateRow(author, author)
            };

            return subItems;
        }

        #endregion
        
        protected override void GroupingItems()
        {
            
        }
    }
    
    
    
    public class CheckListICAOView : CheckListView
    {
        public CheckListICAOView() : base()
        {
            
        }
        
        public CheckListICAOView(AnimatedThreadWorker worker, bool enable = true) :  base(worker, enable)
        {
        }
        
        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Source", (int)(radGridView1.Width * 0.24f));
            AddColumn("Annex Ref", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Chapter №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Chapter Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
            AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
            AddColumn("Standard or Recommended Practice", (int)(radGridView1.Width * 0.3f));
            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsIosa.AnnexRef, item.SettingsIosa.AnnexRef),
                CreateRow(item.SettingsIosa.PartNumber, item.SettingsIosa.PartNumber),
                CreateRow(item.SettingsIosa.PartName, item.SettingsIosa.PartName),
                CreateRow(item.SettingsIosa.ChapterNumber, item.SettingsIosa.ChapterName),
                CreateRow(item.SettingsIosa.ChapterName, item.SettingsIosa.ChapterName),
                CreateRow(item.SettingsIosa.ItemNumber, item.SettingsIosa.ItemNumber),
                CreateRow(item.SettingsIosa.ItemtName, item.SettingsIosa.ItemtName),
                CreateRow(item.SettingsIosa.Standard, item.SettingsIosa.Standard),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.EditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.RevisionNumber),
                CreateRow(author, author),
            };

            return subItems;
        }

        protected override void GroupingItems()
        {
            
        }

        #endregion
    }
    
    public class CheckListRevisionICAOView : CheckListView
    {
        
        public CheckListRevisionICAOView()  :  base()
        {
        }
        public CheckListRevisionICAOView(AnimatedThreadWorker worker, bool enable = true)  :  base(worker, enable)
        {
        }
        
        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("Status", (int)(radGridView1.Width * 0.24f));
            AddColumn("Source", (int)(radGridView1.Width * 0.24f));
            AddColumn("Annex Ref", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Chapter №", (int)(radGridView1.Width * 0.24f));
            AddColumn("Chapter Name", (int)(radGridView1.Width * 0.24f));
            AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
            AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
            AddColumn("Standard or Recommended Practice", (int)(radGridView1.Width * 0.3f));
            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Edition", (int)(radGridView1.Width * 0.3f));
            AddColumn("Revision", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.RevisionStatus.ToString(), item.RevisionStatus),
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsIosa.AnnexRef, item.SettingsIosa.AnnexRef),
                CreateRow(item.SettingsIosa.PartNumber, item.SettingsIosa.PartNumber),
                CreateRow(item.SettingsIosa.PartName, item.SettingsIosa.PartName),
                CreateRow(item.SettingsIosa.ChapterNumber, item.SettingsIosa.ChapterName),
                CreateRow(item.SettingsIosa.ChapterName, item.SettingsIosa.ChapterName),
                CreateRow(item.SettingsIosa.ItemNumber, item.SettingsIosa.ItemNumber),
                CreateRow(item.SettingsIosa.ItemtName, item.SettingsIosa.ItemtName),
                CreateRow(item.SettingsIosa.Standard, item.SettingsIosa.Standard),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(item.EditionNumber.ToString(), item.EditionNumber),
                CreateRow(item.RevisionNumber.ToString(), item.RevisionNumber),
                CreateRow(author, author),
                
            };

            return subItems;
        }
        
        #endregion
        
        protected override void GroupingItems()
        {
            
        }
    }
    
    
    
}
