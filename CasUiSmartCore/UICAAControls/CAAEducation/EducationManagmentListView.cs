using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.CAAEducation
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EducationManagmentListView : BaseGridViewControl<CAAEducationManagment>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public EducationManagmentListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public EducationManagmentListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }

        #endregion

		#endregion

		#region Methods
		
		
		protected override void GroupingItems()
		{
			this.radGridView1.GroupDescriptors.Clear();
			var descriptor = new GroupDescriptor();
			foreach (var colName in new List<string>{ "First Name", "Last Name" })
				descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
			this.radGridView1.GroupDescriptors.Add(descriptor);
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
            AddColumn("First Name", (int)(radGridView1.Width * 0.20f));
            AddColumn("Last Name", (int)(radGridView1.Width * 0.20f));
            AddColumn("Occupation", (int)(radGridView1.Width * 0.20f));
            AddColumn("Combination", (int)(radGridView1.Width * 0.20f));
			AddColumn("Code", (int)(radGridView1.Width * 0.20f));
			AddColumn("CodeName", (int)(radGridView1.Width * 0.24f));
			AddColumn("SubTaskCode", (int)(radGridView1.Width * 0.3f));
			AddColumn("FullName", (int)(radGridView1.Width * 0.45f));
            AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Level", (int)(radGridView1.Width * 0.24f));
            AddColumn("Priority", (int)(radGridView1.Width * 0.24f));
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

		protected override List<CustomCell> GetListViewSubItems(CAAEducationManagment item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item.Specialist);
	        var occupation = item.IsCombination ? null : item.Occupation;
	        var combination = item.IsCombination ?  item.Occupation : null;

	        return  new List<CustomCell>()
	        {
		        CreateRow(item.Specialist.FirstName, item.Specialist.FirstName),
		        CreateRow(item.Specialist.LastName,item.Specialist.LastName),
		        CreateRow(occupation?.FullName, occupation?.FullName),
		        CreateRow(combination?.FullName, combination?.FullName),
		        CreateRow(item.Education?.Task?.Code, item.Education?.Task?.Code),
		        CreateRow(item.Education?.Task?.CodeName, item.Education?.Task?.CodeName),
		        CreateRow(item.Education?.Task?.SubTaskCode, item.Education?.Task?.SubTaskCode),
		        CreateRow(item.Education?.Task?.FullName, item.Education?.Task?.FullName),
		        CreateRow(item.Education?.Task?.Description, item.Education?.Task?.Description),
		        CreateRow(item.Education?.Task?.Level.ToString(), item.Education?.Task?.Level),
		        CreateRow(item.Education?.Priority?.ToString(), item.Education?.Priority),
		        CreateRow(corrector, corrector)
	        };
        }

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.Cancel = true;
		}
		#endregion

		#endregion
	}



	public class CAAEducationManagment : BaseEntityObject
	{
		public Specialist Specialist { get; set; }
		public Occupation Occupation { get; set; }
		public bool IsCombination { get; set; }
		public SmartCore.CAA.CAAEducation.CAAEducation Education { get; set; }

		public CAAEducationManagment()
		{
			IsCombination = true;
		}
	}
}
