using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP.Interfaces;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPPerformanceControl : UserControl
	{
		#region Constructor

		public MTOPPerformanceControl()
		{
			InitializeComponent();
		}

		#endregion

		public void UpdateControl(Dictionary<int, Lifelength> groupLifelengths, CommonCollection<IMtopCalc> maintenanceDirectives, List<MTOPCheck> maintenanceChecks)
		{
			Controls.Clear();

			mtopDirectiveListView1 = new MTOPDirectiveListView(groupLifelengths, maintenanceChecks)
			{
				Location = new Point(0, 0),
				Size = new Size(1310, 400)
			};
			Controls.Add(mtopDirectiveListView1);
			mtopDirectiveListView1.SetItemsArray(maintenanceDirectives.ToArray());

			mtopDirectiveListView1.radGridView1.MasterTemplate.CollapseAllGroups();
		}
	}
}
