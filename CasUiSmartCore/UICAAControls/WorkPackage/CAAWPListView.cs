using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.WorkPackage
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAAWPListView : BaseGridViewControl<CAAWorkPackage>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        private readonly Operator _operator;

        public CAAWPListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        /// <param
        ///     name="operator">
        /// </param>
        public CAAWPListView(AnimatedThreadWorker animatedThreadWorker, Operator @operator) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            _operator = @operator;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        

		#region Methods

		protected override void GroupingItems()
		{
			Grouping("Status");
		}


		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Number", (int)(radGridView1.Width * 0.24f));
			AddColumn("Title", (int)(radGridView1.Width * 0.24f));
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

		protected override List<CustomCell> GetListViewSubItems(CAAWorkPackage item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
	        var op = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == item.OperatorId) ?? AllOperators.Unknown;
	        
	        var subItems = new List<CustomCell>()
			{
				CreateRow(item.StatusName, item.Status),
				CreateRow(item.Settings.Number, item.Settings.Number),
				CreateRow(item.Title, item.Title),
				CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion
		
		
		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.DisplayerText = "";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new CAAWPRecordListScreen(_operator, SelectedItem.ItemId);
			
			var form = new CAAWorkPackageEditorForm(SelectedItem);
			if(form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();

			e.Cancel = true;
		}


		#endregion
	}
}
