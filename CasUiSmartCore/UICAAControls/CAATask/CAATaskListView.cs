using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.CAATask
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAATaskListView : BaseGridViewControl<SmartCore.CAA.Tasks.CAATask>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public CAATaskListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CAATaskListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;


            OldColumnIndex = 2;
            SortDirection = SortDirection.Desc;
            EnableCustomSorting = true;

            //this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
		}

        public int OperatorId { get; set; }

        #endregion

		#endregion

		#region Methods
		
		
		protected override void GroupingItems()
		{
			this.radGridView1.GroupDescriptors.Clear();
			var descriptor = new GroupDescriptor();
			foreach (var colName in new List<string>{ "Code", "CodeName" })
				descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
			this.radGridView1.GroupDescriptors.Add(descriptor);

            
		}
		
		
		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
            AddColumn("Code", (int)(radGridView1.Width * 0.20f));
            AddColumn("CodeName", (int)(radGridView1.Width * 0.20f));
            AddColumn("SubTaskCode", (int)(radGridView1.Width * 0.20f));
			AddColumn("SubTaskName", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.3f));
			AddColumn("Level", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(SmartCore.CAA.RoutineAudits.RoutineAudit);

            DialogResult confirmResult =
                MessageBox.Show(this.SelectedItems.Count == 1
                        ? "Do you really want to delete " + typeName + " " + this.SelectedItems[0] + "?"
                        : "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                this.radGridView1.BeginUpdate();
                GlobalObjects.NewKeeper.Delete(this.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
		}

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.Tasks.CAATask item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
                CreateRow(item.Code.ToString(), item.Code),
                CreateRow(item.CodeName.ToString(), item.CodeName),
                CreateRow(item.SubTaskCode, item.SubTaskCode),
                CreateRow(item.ShortName, item.ShortName),
                CreateRow(item.Description, item.Description),
                CreateRow(item.Level.ToString(), item.Level),
                CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			var form = new CommonEditorForm(SelectedItem);
			if(form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();
			e.Cancel = true;
		}
		#endregion

		#endregion
	}
}
