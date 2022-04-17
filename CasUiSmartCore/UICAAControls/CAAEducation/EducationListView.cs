using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CAAEducation
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EducationListView : BaseGridViewControl<SmartCore.CAA.CAAEducation.CAAEducation>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public EducationListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public EducationListView(AnimatedThreadWorker animatedThreadWorker) : this()
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
			Grouping("Occupation");
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
            AddColumn("Occupation", (int)(radGridView1.Width * 0.20f));
            AddColumn("Department", (int)(radGridView1.Width * 0.20f));
            AddColumn("Code", (int)(radGridView1.Width * 0.20f));
			AddColumn("CodeName", (int)(radGridView1.Width * 0.24f));
			AddColumn("SubTaskCode", (int)(radGridView1.Width * 0.3f));
			AddColumn("SubTask code", (int)(radGridView1.Width * 0.24f));
			AddColumn("FullName", (int)(radGridView1.Width * 0.45f));
            AddColumn("Description", (int)(radGridView1.Width * 0.45f));
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

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.CAAEducation.CAAEducation item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
                CreateRow(item.Occupation.ToString(), item.Occupation),
                CreateRow(item.Occupation.Department.ToString(), item.Occupation.Department),
                CreateRow(item.Task.Code, item.Task.Code),
                CreateRow(item.Task.CodeName, item.Task.CodeName),
                CreateRow(item.Task.SubTaskCode, item.Task.SubTaskCode),
                CreateRow(item.Task.FullName, item.Task.FullName),
                CreateRow(item.Task.Description, item.Task.Description),
                CreateRow(item.Task.Level.ToString(), item.Task.Level),
                CreateRow(item.Task.ShortName.ToString(), item.Task.ShortName),
                CreateRow(corrector, corrector)
			};

			return subItems;
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
}
