using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.FindingLevel
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class FindingLevelsListView : BaseGridViewControl<SmartCore.CAA.FindingLevel.FindingLevels>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        
        public FindingLevelsListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public FindingLevelsListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        

		#region Methods

		protected override void GroupingItems()
		{
			Grouping("Operator");
		}


		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Operator", (int)(radGridView1.Width * 0.24f));
			AddColumn("Level/Category", (int)(radGridView1.Width * 0.24f));
			AddColumn("Class", (int)(radGridView1.Width * 0.24f));
			AddColumn("Action", (int)(radGridView1.Width * 0.24f));
			AddColumn("Color", (int)(radGridView1.Width * 0.24f));
			AddColumn("Corrective Action", (int)(radGridView1.Width * 0.24f));
			AddColumn("Final Action", (int)(radGridView1.Width * 0.24f));
			AddColumn("Program Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(SmartCore.CAA.FindingLevel.FindingLevels);

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

		#region protected override List<CustomCell> GetListViewSubItems(FindingLevels item)

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.FindingLevel.FindingLevels item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
	        var op = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == item.OperatorId) ?? AllOperators.Unknown;
	        
	        var subItems = new List<CustomCell>()
			{
				CreateRow(op.ToString(), op),
				CreateRow(item.LevelName, item.LevelName),
				CreateRow(item.LevelClass.ToString(), item.LevelClass),
				CreateRow(item.ActionProgramType?.ToString() ?? ActionProgramType.Unknown.ToString(), item.ActionProgramType),
				CreateRow(item.LevelColor.ToString(), item.LevelColor),
				CreateRow(item.CorrectiveAction.ToString(), item.CorrectiveAction),
				CreateRow(item.FinalAction.ToString(), item.FinalAction),
				CreateRow(item.ProgramType.ToString(), item.ProgramType),
				CreateRow(item.Remark, item.Remark),
				CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion
		



		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			var form = new FindingLevelsForm(SelectedItem);
			if(form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();
		}


		#endregion
	}
}
