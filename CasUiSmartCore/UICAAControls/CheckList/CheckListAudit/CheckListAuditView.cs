using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.Entities.General.Personnel;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CheckListAuditView : BaseGridViewControl<CheckLists>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        private readonly CheckListAuditType _type;

        public bool IsAuditCheck { get; set; }
        public int? AuditId { get; set; }

        public CheckListAuditView()
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
        /// <param
        ///     name="checkListAuditType">
        /// </param>
        public CheckListAuditView(AnimatedThreadWorker animatedThreadWorker, CheckListAuditType type)
		{
            _animatedThreadWorker = animatedThreadWorker;
            _type = type;
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

            if (_type == CheckListAuditType.User)
            {
                var descriptor1 = new GroupDescriptor();
                descriptor1.GroupNames.Add("Current",  ListSortDirection.Ascending);
                this.radGridView1.GroupDescriptors.Add(descriptor1);
            }
            
            
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

            AddColumn("Requirement", (int)(radGridView1.Width * 0.35f));

            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Condition", (int)(radGridView1.Width * 0.2f));
            AddColumn("Root Cause", (int)(radGridView1.Width * 0.35f));
            AddColumn("Workflow Stage", (int)(radGridView1.Width * 0.2f));
            AddColumn("Workflow Status", (int)(radGridView1.Width * 0.2f));
            
            AddColumn("Auditor", (int)(radGridView1.Width * 0.3f));
            AddColumn("Auditee", (int)(radGridView1.Width * 0.3f));
            AddColumn("Current", (int)(radGridView1.Width * 0.3f));

            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);


            var condition = "Unknown";
            var root = "";
            var status = WorkFlowStatus.Unknown;
            var stage = WorkFlowStage.Unknown;
            if (item.AuditCheck != null)
            {
                root = item.AuditCheck.Settings.RootCause;
                status = WorkFlowStatus.GetItemById(item.AuditCheck.Settings.WorkflowStatusId);
                stage = WorkFlowStage.GetItemById(item.AuditCheck.Settings.WorkflowStageId);

                if (item.AuditCheck.Settings.IsApplicable.HasValue &&item.AuditCheck.Settings.IsApplicable.Value)
                    condition = "Not Applicable";
                else
                {
                    if (item.AuditCheck.Settings.IsSatisfactory.HasValue)
                    {
                        if (item.AuditCheck.Settings.IsSatisfactory.Value)
                            condition = "Satisfactory";
                        else condition = "Not Satisfactory";
                    }
                }
            }

            var auditor = Specialist.Unknown.FirstName;
            var auditee = Specialist.Unknown.FirstName;
            var current = "";
            if (item.PelRecord != null)
            {
                auditor = $"{item.PelRecord?.Auditor.FirstName} {item.PelRecord?.Auditor.LastName}";
                auditee = $"{item.PelRecord?.Auditee.FirstName} {item.PelRecord?.Auditee.LastName}";
                if(item.PelRecord?.CurrentAuditor != null)
                    current = $"{item.PelRecord?.CurrentAuditor.FirstName} {item.PelRecord?.CurrentAuditor.LastName}";
                else current = $"My Tasks";
            }
            

            var subItems = new List<CustomCell>()
                {
                    CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber),
                    CreateRow(item.Settings.SectionName, item.Settings.SectionName),
                    CreateRow(item.Settings.PartNumber, item.Settings.PartNumber),
                    CreateRow(item.Settings.PartName, item.Settings.PartName),
                    CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber),
                    CreateRow(item.Settings.SubPartName, item.Settings.SubPartName),
                    CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber),
                    CreateRow(item.Settings.Requirement, item.Settings.Requirement),
                    CreateRow(item.Level.ToString(), item.Level),
                    CreateRow(condition, condition),
                    CreateRow(root, root),
                    CreateRow(stage.ToString(), stage),
                    CreateRow(status.ToString(), status),
                    
                    CreateRow(auditor, item.PelRecord?.Auditor),
                    CreateRow(auditee, item.PelRecord?.Auditee),
                    CreateRow(current, item.PelRecord?.CurrentAuditor),
                    CreateRow(author, author),
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
                    if (SelectedItem.AuditCheck.WorkflowStageId == WorkFlowStage.RCA.ItemId)
                    {
                        var form = new CheckListAuditRootCaseForm(SelectedItem, AuditId.Value, SelectedItem.IsEditable);
                        if (form.ShowDialog() == DialogResult.OK)
                            _animatedThreadWorker.RunWorkerAsync();
                    }
                    else
                    {
                        var form = new CheckListAuditForm(SelectedItem, AuditId.Value, SelectedItem.IsEditable);
                        if (form.ShowDialog() == DialogResult.OK)
                            _animatedThreadWorker.RunWorkerAsync();
                    }
                    
				}
				else
				{
                    var form = new CheckListForm.CheckListForm(SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        _animatedThreadWorker.RunWorkerAsync();
				}
            }
            
            
            e.Cancel = true;
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
        
    }
    
    public class CheckListSAFAAuditView : CheckListAuditView
    {
        public CheckListSAFAAuditView() : base()
        {
            
        }
        
        public CheckListSAFAAuditView(AnimatedThreadWorker worker, CheckListAuditType type) :  base(worker, type)
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
            AddColumn("Workflow Stage", (int)(radGridView1.Width * 0.2f));
            AddColumn("Workflow Status", (int)(radGridView1.Width * 0.2f));
            AddColumn("Auditor", (int)(radGridView1.Width * 0.3f));
            AddColumn("Auditee", (int)(radGridView1.Width * 0.3f));
            AddColumn("Current", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var auditor = Specialist.Unknown.FirstName;
            var auditee = Specialist.Unknown.FirstName;
            var current = "";
            
            var status = WorkFlowStatus.Unknown;
            var stage = WorkFlowStage.Unknown;
            if (item.AuditCheck != null)
            {
                status = WorkFlowStatus.GetItemById(item.AuditCheck.Settings.WorkflowStatusId);
                stage = WorkFlowStage.GetItemById(item.AuditCheck.Settings.WorkflowStageId);
            }

            if (item.PelRecord != null)
            {
                auditor = $"{item.PelRecord?.Auditor.FirstName} {item.PelRecord?.Auditor.LastName}";
                auditee = $"{item.PelRecord?.Auditee.FirstName} {item.PelRecord?.Auditee.LastName}";
                if(item.PelRecord?.CurrentAuditor != null)
                    current = $"{item.PelRecord?.CurrentAuditor.FirstName} {item.PelRecord?.CurrentAuditor.LastName}";
                else current = $"My Tasks";
            }
            
            var subItems = new List<CustomCell>()
            {
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsSafa.Item, item.SettingsSafa.Item),
                CreateRow(item.SettingsSafa.Title, item.SettingsSafa.Title),
                CreateRow(item.SettingsSafa.Standard, item.SettingsSafa.Standard),
                CreateRow(item.SettingsSafa.StandardRef, item.SettingsSafa.StandardRef),
                CreateRow(item.SettingsSafa.PdfCode, item.SettingsSafa.PdfCode),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(stage.ToString(), stage),
                CreateRow(status.ToString(), status),
                CreateRow(auditor, item.PelRecord?.Auditor),
                CreateRow(auditee, item.PelRecord?.Auditee),
                CreateRow(current, item.PelRecord?.CurrentAuditor),
                CreateRow(author, author)
            };

            return subItems;
        }

        protected override void GroupingItems()
        {
            
        }

        #endregion
    }
    
    public class CheckListICAOAuditView : CheckListAuditView
    {
        public CheckListICAOAuditView() : base()
        {
            
        }
        
        public CheckListICAOAuditView(AnimatedThreadWorker worker, CheckListAuditType type) :  base(worker, type)
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
            AddColumn("Workflow Stage", (int)(radGridView1.Width * 0.2f));
            AddColumn("Workflow Status", (int)(radGridView1.Width * 0.2f));
            AddColumn("Auditor", (int)(radGridView1.Width * 0.3f));
            AddColumn("Auditee", (int)(radGridView1.Width * 0.3f));
            AddColumn("Current", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckLists item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var auditor = Specialist.Unknown.FirstName;
            var auditee = Specialist.Unknown.FirstName;
            var current = "";
            
            var status = WorkFlowStatus.Unknown;
            var stage = WorkFlowStage.Unknown;
            if (item.AuditCheck != null)
            {
                status = WorkFlowStatus.GetItemById(item.AuditCheck.Settings.WorkflowStatusId);
                stage = WorkFlowStage.GetItemById(item.AuditCheck.Settings.WorkflowStageId);
            }
            
            if (item.PelRecord != null)
            {
                auditor = $"{item.PelRecord?.Auditor.FirstName} {item.PelRecord?.Auditor.LastName}";
                auditee = $"{item.PelRecord?.Auditee.FirstName} {item.PelRecord?.Auditee.LastName}";
                if(item.PelRecord?.CurrentAuditor != null)
                    current = $"{item.PelRecord?.CurrentAuditor.FirstName} {item.PelRecord?.CurrentAuditor.LastName}";
                else current = $"My Tasks";
            }
            
            var subItems = new List<CustomCell>()
            {
                CreateRow(item.Source, item.Source),
                CreateRow(item.SettingsIcao.AnnexRef, item.SettingsIcao.AnnexRef),
                CreateRow(item.SettingsIcao.PartNumber, item.SettingsIcao.PartNumber),
                CreateRow(item.SettingsIcao.PartName, item.SettingsIcao.PartName),
                CreateRow(item.SettingsIcao.ChapterNumber, item.SettingsIcao.ChapterName),
                CreateRow(item.SettingsIcao.ChapterName, item.SettingsIcao.ChapterName),
                CreateRow(item.SettingsIcao.ItemNumber, item.SettingsIcao.ItemNumber),
                CreateRow(item.SettingsIcao.ItemtName, item.SettingsIcao.ItemtName),
                CreateRow(item.SettingsIcao.Standard, item.SettingsIcao.Standard),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(stage.ToString(), stage),
                CreateRow(status.ToString(), status),
                CreateRow(auditor, item.PelRecord?.Auditor),
                CreateRow(auditee, item.PelRecord?.Auditee),
                CreateRow(current, item.PelRecord?.CurrentAuditor),
                CreateRow(author, author),
            };

            return subItems;
        }

        protected override void GroupingItems()
        {
            
        }

        #endregion
    }
    
    
}
