using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
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
	public partial class CAAWPRecordListView : BaseGridViewControl<CAAWorkPackageRecord>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        
        public CAAWPRecordListView()
        {
            InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CAAWPRecordListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }
        

		#region Methods

		protected override void GroupingItems()
		{
			
		}


		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
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

		protected override List<CustomCell> GetListViewSubItems(CAAWorkPackageRecord item)
        {
	        var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
	        
	        var subItems = new List<CustomCell>()
			{
				CreateRow(corrector, corrector)
			};

			return subItems;
		}

		#endregion
		
		
		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.Cancel = true;
		}


		#endregion
	}
}
