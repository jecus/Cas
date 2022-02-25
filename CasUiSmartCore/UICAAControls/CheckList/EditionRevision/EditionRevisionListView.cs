using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EditionRevisionListView : BaseGridViewControl<CheckListRevision>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        private readonly SmartCore.CAA.StandartManual.StandartManual _manual;

        public EditionRevisionListView()
        {
            InitializeComponent();
            SortDirection = SortDirection.Asc;
            EnableCustomSorting = true;
        }
         
        public EditionRevisionListView(AnimatedThreadWorker animatedThreadWorker, SmartCore.CAA.StandartManual.StandartManual manual)
        {
            
            InitializeComponent();
            _animatedThreadWorker = animatedThreadWorker;
            _manual = manual;
            SortDirection = SortDirection.Asc;
            EnableCustomSorting = true;
            OldColumnIndex = 3;

        }

        public int OperatorId { get; set; }

        #region Methods

        protected override void GroupingItems()
        {
            this.radGridView1.GroupDescriptors.Clear();
            var descriptor = new GroupDescriptor();
            foreach (var colName in new List<string>{ "Edition Status" })
                descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
            this.radGridView1.GroupDescriptors.Add(descriptor);
        }

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            AddColumn("№", (int)(radGridView1.Width * 0.20f));
            AddColumn("Type", (int)(radGridView1.Width * 0.24f));
            AddColumn("Date", (int)(radGridView1.Width * 0.24f));
            AddColumn("Eff Date", (int)(radGridView1.Width * 0.24f));
            AddColumn("Edition Status", (int)(radGridView1.Width * 0.24f));
            AddColumn("Status", (int)(radGridView1.Width * 0.24f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.24f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckListRevision item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>();

            var status = "";
            if (item.CurrentStatus == EditionRevisionStatus.Current)
                status = "1.Current";
            else if (item.CurrentStatus == EditionRevisionStatus.Temporary)
                status = "2.Temporary";
            else if (item.CurrentStatus == EditionRevisionStatus.Previous)
                status = "3.Previous";

            subItems.Add(CreateRow(item.Number.ToString(), item.Number));
            subItems.Add(CreateRow(item.Type.ToString(), item.Type));
            subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Date), item.Date));
            subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.EffDate), item.EffDate));
            subItems.Add(CreateRow(status, status));
            subItems.Add(CreateRow(item.Status.ToString(), item.Status.ToString()));
            subItems.Add(CreateRow(author, author));

            return subItems;
        }

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

                foreach (var check in this.SelectedItems)
                {
                    if (check.Type == RevisionType.Revision)
                    {
                        GlobalObjects.CaaEnvironment.NewLoader.Execute(
                            $"update dbo.CheckListRevisionRecord set IsDeleted = 1 where ParentId = {check.ItemId}");
                    }
                    else
                    {
                        GlobalObjects.CaaEnvironment.NewLoader.Execute(
                            $"update dbo.CheckList set IsDeleted = 1 where ItemId = {check.CheckListId})");
                    }
                    
                }
                
                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
        }

        
        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.DisplayerText = $"{SelectedItem.Type} : {SelectedItem.Number} {_manual.ProgramType}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new EditionRevisionRecordListScreen(GlobalObjects.CaaEnvironment.Operators[0], SelectedItem, OperatorId,_manual);
            }
        }
        #endregion

        #endregion

    }
}
