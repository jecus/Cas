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
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CheckListLiteView : BaseGridViewControl<CheckLists>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public CheckListLiteView()
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
        public CheckListLiteView(AnimatedThreadWorker animatedThreadWorker)
		{
            _animatedThreadWorker = animatedThreadWorker;
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

		#endregion

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

            AddColumn("Requirement", (int)(radGridView1.Width * 0.35f));

            AddColumn("Level", (int)(radGridView1.Width * 0.2f));
            AddColumn("Condition", (int)(radGridView1.Width * 0.2f));
            AddColumn("Root Cause", (int)(radGridView1.Width * 0.35f));
            AddColumn("Workflow Status", (int)(radGridView1.Width * 0.2f));

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
            if (item.AuditCheck != null)
            {
                root = item.AuditCheck.Settings.RootCause;
                status = WorkFlowStatus.GetItemById(item.AuditCheck.Settings.WorkflowStatusId);

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
                    CreateRow(status.ToString(), status),

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
                    var form = new CheckListForm(SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        _animatedThreadWorker.RunWorkerAsync();
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
}
