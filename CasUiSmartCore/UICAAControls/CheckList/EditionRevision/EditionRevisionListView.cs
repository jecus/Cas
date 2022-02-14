using System;
using System.Collections.Generic;
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

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EditionRevisionListView : BaseGridViewControl<CheckListRevision>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        public EditionRevisionListView()
        {
            InitializeComponent();
            OldColumnIndex = 3;
            SortDirection = SortDirection.Asc;
        }
         
        public EditionRevisionListView(AnimatedThreadWorker animatedThreadWorker)
        {
            
            
            InitializeComponent();
            _animatedThreadWorker = animatedThreadWorker;
            OldColumnIndex = 3;
            SortDirection = SortDirection.Asc;
        }

        public int OperatorId { get; set; }

        #region Methods

        protected override void GroupingItems()
        {
            SortDirection = SortDirection.Desc;
            Grouping("Status");
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
            AddColumn("Status", (int)(radGridView1.Width * 0.24f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.24f));
        }
        #endregion

        #region protected override List<CustomCell> GetListViewSubItems(Specialization item)

        protected override List<CustomCell> GetListViewSubItems(CheckListRevision item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>();

            subItems.Add(CreateRow(item.Number.ToString(), item.Number));
            subItems.Add(CreateRow(item.Type.ToString(), item.Type));
            subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Date), item.Date));
            subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.EffDate), item.EffDate));
            subItems.Add(CreateRow(item.Status.ToString(), item.Status));
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
                            $"update dbo.CheckListRevisionRecord set IsDeleted = 1 where ParentId = {check.ItemId})");
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
                e.DisplayerText = $"{SelectedItem.Type} : {SelectedItem.Number}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new EditionRevisionRecordListScreen(GlobalObjects.CaaEnvironment.Operators[0], SelectedItem, OperatorId);
            }
        }
        #endregion

        #endregion

    }
}
