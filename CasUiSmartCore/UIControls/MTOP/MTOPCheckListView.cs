using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPCheckListView : BaseGridViewControl<MTOPCheck>
	{
		#region Constructor

		public MTOPCheckListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("CheckType", (int)(radGridView1.Width * 0.2f));
			AddColumn(" ", (int)(radGridView1.Width * 0.2f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.30f));
			AddColumn("Repeat", (int)(radGridView1.Width * 0.30f));
			AddColumn("Notify", (int)(radGridView1.Width * 0.30f));
			AddColumn("Estimated Thresh", (int)(radGridView1.Width * 0.36f));
			AddColumn("Estimated Thresh Limit", (int)(radGridView1.Width * 0.4f));
			AddColumn("Estimated Repeat", (int)(radGridView1.Width * 0.36f));
			AddColumn("Estimated Repeat Limit", (int)(radGridView1.Width * 0.4f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override List<CustomCell> GetListViewSubItems(MTOPCheck item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var temp = "";
			if (item.IsZeroPhase)
				temp = $"Zero Phase: {item.CheckType.FullName}";
			else temp = $"{item.CheckType.FullName}";
			return new List<CustomCell>
			{
				CreateRow(temp, temp ),
				CreateRow(item.Name, item.Name ),
				CreateRow(item.Thresh.ToRepeatIntervalsFormat(), item.Thresh ),
				CreateRow(item.Repeat.ToRepeatIntervalsFormat(), item.Repeat ),
				CreateRow(item.Notify.ToRepeatIntervalsFormat(), item.Repeat ),
				CreateRow(item.PhaseThreshLimit.ToRepeatIntervalsFormat(), item.PhaseThreshLimit ),
				CreateRow(item.PhaseThresh.ToRepeatIntervalsFormat(), item.PhaseThresh ),
				CreateRow(item.PhaseRepeatLimit == null ? "": item.PhaseRepeatLimit.ToRepeatIntervalsFormat(), item.PhaseRepeatLimit ),
				CreateRow(item.PhaseRepeat == null ? "" : item.PhaseRepeat.ToRepeatIntervalsFormat(), item.PhaseRepeat ),
				CreateRow(author, author )
			};
		}

		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("CheckType");
		}

		#endregion


		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			
		}

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			
		}
	}
}
