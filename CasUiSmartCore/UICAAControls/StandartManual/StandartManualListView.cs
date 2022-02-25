using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.Entities.General;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.StandartManual
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class StandartManualListView : BaseGridViewControl<SmartCore.CAA.StandartManual.StandartManual>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        
        public StandartManualListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public StandartManualListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        

		#region Methods

		protected override void GroupingItems()
		{
			Grouping("Program Type");
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Program Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("Source", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Remark", (int)(radGridView1.Width * 0.45f));
            AddColumn("Check/Valid", (int)(radGridView1.Width * 0.45f));
            AddColumn("Remain", (int)(radGridView1.Width * 0.45f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(SmartCore.CAA.StandartManual.StandartManual);

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

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.StandartManual.StandartManual item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

	        var subItems = new List<CustomCell>()
			{
				CreateRow(item.ProgramType.ToString(), item.ProgramType),
				CreateRow(item.Source, item.Source),
                CreateRow(item.Settings.Description, item.Settings.Description),
                CreateRow(item.Settings.Remark, item.Settings.Remark),
                CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.ValidTo), item.Settings.ValidTo),
                CreateRow(item.Remains.ToString(), item.Remains),
                CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion
		
		#region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, SmartCore.CAA.StandartManual.StandartManual item)
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

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
            {
	            e.RequestedEntity = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(),OperatorId, SelectedItem);
                e.DisplayerText = $"Check List: {SelectedItem.ProgramType}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
		}
		#endregion

		#endregion
	}
}
