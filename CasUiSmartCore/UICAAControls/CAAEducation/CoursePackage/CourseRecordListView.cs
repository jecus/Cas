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
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CourseRecordListView : BaseGridViewControl<CourseRecord>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public CourseRecordListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CourseRecordListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        public Operator CurrentOperator { get; set; }

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
			AddColumn("SubTaskName", (int)(radGridView1.Width * 0.45f));
            AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Level", (int)(radGridView1.Width * 0.24f));
            AddColumn("Priority", (int)(radGridView1.Width * 0.24f));
            AddColumn("Start", (int)(radGridView1.Width * 0.24f));
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
                var ids = this.SelectedItems.ToList().Select(i => i.ObjectId);
                GlobalObjects.CaaEnvironment.Execute($"update [dbo].[EducationRecords] set SettingsJSON = JSON_MODIFY(SettingsJSON, '$.BlockedWpId', null)" +
                                                     $" where ItemId in ({string.Join(",", ids)})");
                
                
                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
		}
        
        
        #region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

        protected override void SetItemColor(GridViewRowInfo listViewItem, CourseRecord item)
        {
	        var itemBackColor = UsefulMethods.GetColor(item);
	        var itemForeColor = Color.Gray;

	        foreach (GridViewCellInfo cell in listViewItem.Cells)
	        {
		        cell.Style.DrawFill = true;
		        cell.Style.CustomizeFill = true;
		        cell.Style.BackColor = UsefulMethods.GetColor(item.Parent);

		        var listViewForeColor = cell.Style.ForeColor;

		        if (listViewForeColor != Color.MediumVioletRed)
			        cell.Style.ForeColor = itemForeColor;
		        cell.Style.BackColor = itemBackColor;
	        }
        }


        #endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CourseRecord item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item.Parent.Specialist);
	        var occupation = item.Parent.IsCombination ? null : item.Parent.Occupation;
	        var combination = item.Parent.IsCombination ?  item.Parent.Occupation : null;

	        var next = item.Parent.Record == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat(item.Parent.Record?.Settings?.Next);
	        var last = item.Parent.Record == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat(item.Parent.Record?.Settings?.LastCompliances?.LastOrDefault()?.LastDate);
	        

	        return  new List<CustomCell>()
	        {
		        CreateRow(item.Parent.Specialist.FirstName, item.Parent.Specialist.FirstName),
		        CreateRow(item.Parent.Specialist.LastName,item.Parent.Specialist.LastName),
		        CreateRow(occupation?.FullName, occupation?.FullName),
		        CreateRow(combination?.FullName, combination?.FullName),
		        CreateRow(item.Parent.Education?.Task?.Code, item.Parent.Education?.Task?.Code),
		        CreateRow(item.Parent.Education?.Task?.CodeName, item.Parent.Education?.Task?.CodeName),
		        CreateRow(item.Parent.Education?.Task?.SubTaskCode, item.Parent.Education?.Task?.SubTaskCode),
		        CreateRow(item.Parent.Education?.Task?.FullName, item.Parent.Education?.Task?.FullName),
		        CreateRow(item.Parent.Education?.Task?.Description, item.Parent.Education?.Task?.Description),
		        CreateRow(item.Parent.Education?.Task?.Level.ToString(), item.Parent.Education?.Task?.Level),
		        CreateRow(item.Parent.Education?.Priority?.ToString(), item.Parent.Education?.Priority),
		        CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Parent.Record?.Settings?.StartDate), item.Parent.Record?.Settings?.StartDate),
		        CreateRow(item.Parent.Record?.Settings?.Repeat.ToRepeatIntervalsFormat(), item.Parent.Record?.Settings?.Repeat),
		        CreateRow(next, item.Parent.Record?.Settings?.Next),
		        CreateRow(item.Parent.Record?.Settings?.Remains?.ToRepeatIntervalsFormat(), item.Parent.Record?.Settings?.Remains),
		        CreateRow(last, item.Parent.Record?.Settings?.LastCompliances?.LastOrDefault()?.LastDate),
		        CreateRow(corrector, corrector)
	        };
        }

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem.Parent.Occupation != null && SelectedItem.Parent.Education != null)
			{
				e.DisplayerText = SelectedItem.Parent.Education?.Task?.FullName;
				e.RequestedEntity = new EducationScreen(CurrentOperator, SelectedItem.Parent);
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			}
			else e.Cancel = true;
		}
		#endregion

		#endregion
	}
}
