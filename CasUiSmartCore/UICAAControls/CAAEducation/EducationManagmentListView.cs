using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

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
            SortDirection = SortDirection.Desc;
			OldColumnIndex = 12;
		}

        public int OperatorId { get; set; }
        public Operator CurrentOperator { get; set; }
        public bool DisableEdit { get; set; }

        #endregion

		#endregion

		#region Methods
		
		
		protected override void GroupingItems()
		{
			// this.radGridView1.GroupDescriptors.Clear();
			// var descriptor = new GroupDescriptor();
			// foreach (var colName in new List<string>{ "First Name", "Last Name" })
			// 	descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
			// this.radGridView1.GroupDescriptors.Add(descriptor);
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
			AddColumn("SubTaskName", (int)(radGridView1.Width * 0.45f));
            AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Level", (int)(radGridView1.Width * 0.24f));
            AddColumn("Priority", (int)(radGridView1.Width * 0.24f));
            AddColumn("Repeat", (int)(radGridView1.Width * 0.24f));
            AddColumn("Next", (int)(radGridView1.Width * 0.24f));
            AddColumn("Remain", (int)(radGridView1.Width * 0.24f));
            AddColumn("Last", (int)(radGridView1.Width * 0.24f));
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
        
        
        #region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

        protected override void SetItemColor(GridViewRowInfo listViewItem, CAAEducationManagment item)
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

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CAAEducationManagment item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item.Specialist);
	        var occupation = item.IsCombination ? null : item.Occupation;
	        var combination = item.IsCombination ?  item.Occupation : null;

	        var next = item.Record == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat(item.Record?.Settings?.NextCompliance?.Next);
	        var last = item.Record == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat(item.Record?.Settings?.LastCompliances?.LastOrDefault()?.LastDate);
	        

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
		        CreateRow(item?.Education?.Task?.Repeat.ToRepeatIntervalsFormat(), item?.Education?.Task?.Repeat),
		        CreateRow(next, item.Record?.Settings?.NextCompliance?.Next),
		        CreateRow(item.Record?.Settings?.NextCompliance?.Remains?.ToRepeatIntervalsFormat(), item.Record?.Settings?.NextCompliance?.Remains),
		        CreateRow(last, item.Record?.Settings?.LastCompliances?.LastOrDefault()?.LastDate),
		        CreateRow(corrector, corrector)
	        };
        }

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if(DisableEdit)
				e.Cancel = true;
			if (SelectedItem.Occupation != null && SelectedItem.Education != null)
			{
				e.DisplayerText = $"{SelectedItem.Specialist.ToString()} - {SelectedItem.Education?.Task?.FullName}";;
				e.RequestedEntity = new EducationScreen(CurrentOperator, SelectedItem);
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			}
			else e.Cancel = true;
		}
		#endregion

		#endregion
	}
}
