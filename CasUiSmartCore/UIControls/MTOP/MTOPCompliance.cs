using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
    ///<summary>
    ///</summary>
    public partial class MTOPCompliance : ComplianceControl
    {
        private Aircraft _currentAircraft;
	    private AverageUtilization _averageUtilization;

	    #region public MaintenanceComplianceNew()
        ///<summary>
        ///</summary>
        public MTOPCompliance()
        {
            InitializeComponent();
        }
		#endregion

		public void UpdateControl(List<MTOPCheck> maintenanceChecks, List<MTOPCheck> maintenanceChecksDeleted,
			Aircraft currentAircraft, AverageUtilization averageUtilization)
		{
			_averageUtilization = averageUtilization;
			_currentAircraft = currentAircraft;
			listViewCompliance.Items.Clear();

			ListViewItem newItem;
			string[] subs;

			var mtopCheckRecords = new List<MTOPCheckRecord>();
			mtopCheckRecords.AddRange(maintenanceChecksDeleted.SelectMany(i => i.PerformanceRecords));
			mtopCheckRecords.AddRange(maintenanceChecks.SelectMany(i => i.PerformanceRecords));

			var nps = maintenanceChecks.SelectMany(i => i.NextPerformances);

			foreach (var np in nps.OrderByDescending(i => i.PerformanceSource.Days))
			{
				string perfDate = "";
				if (np.PerformanceDate.HasValue)
					perfDate = UsefulMethods.NormalizeDate(np.PerformanceDate.Value);

				var group = np.ParentCheck.IsZeroPhase ? $"0{np.Group}" : np.Group.ToString();


				subs = new[]  {
					group,
					np.ParentCheck.Name,
					perfDate,
					np.PerformanceSource.ToRepeatIntervalsFormat(),
					$"HRS/DAY: {Math.Round(np.ParentCheck.AverageUtilization.Hours, 2)} CYC/DAY: {Math.Round((double) (np.ParentCheck?.AverageUtilization?.Hours / np.ParentCheck.AverageUtilization?.CyclesPerDay), 2)}",
					""
				};

				newItem = new ListViewItem(subs)
				{
					Group = listViewCompliance.Groups["next"],
					Tag = np,
					BackColor = UsefulMethods.GetColor(np)
				};

				listViewCompliance.Items.Add(newItem);
			}			

			foreach (var record in mtopCheckRecords.OrderByDescending(i => i.CalculatedPerformanceSource.Days))
			{
				var group = record.Parent.IsZeroPhase ? $"0{record.GroupName}" : record.GroupName.ToString();

				subs = new[]  {
					group,
					record.CheckName,
					UsefulMethods.NormalizeDate(record.RecordDate),
					record.CalculatedPerformanceSource.ToRepeatIntervalsFormat(),
					record.AverageUtilization != null ? $"HRS/DAY: {Math.Round(record.AverageUtilization.Hours, 2)} CYC/DAY: {Math.Round((double) (record.AverageUtilization?.Hours / record.AverageUtilization?.CyclesPerDay), 2)}" : "",
					record.Remarks
				};

				newItem = new ListViewItem(subs)
				{
					Group = listViewCompliance.Groups["last"],
					Tag = record
				};

				listViewCompliance.Items.Add(newItem);
			}
		}

		#region private void ButtonEditClick(object sender, EventArgs e)
		private void ButtonEditClick(object sender, EventArgs e)
        {
			Edit();
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
		{
			Edit();
		}
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
	        if (listViewCompliance.SelectedItems.Count == 0 ||
			    listViewCompliance.SelectedItems[0].Group != listViewCompliance.Groups["last"] ||
			    (!(listViewCompliance.SelectedItems[0].Tag is MTOPCheckRecord))) return;
	        {
		        MTOPCheckRecord record = (MTOPCheckRecord)listViewCompliance.SelectedItems[0].Tag;
		        switch (MessageBox.Show(@"Delete this Maintenance program change record ?", (string)new GlobalTermsProvider()["SystemName"],
			        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
			        MessageBoxDefaultButton.Button2))
		        {
			        case DialogResult.Yes:
				        GlobalObjects.CasEnvironment.Manipulator.Delete(record, false);
				        InvokeComplianceAdded(null);
				        break;
			        case DialogResult.No:
				        //arguments.Cancel = true;
				        break;
		        }
	        }
        }
		#endregion

		#region private void Edit()

		private void Edit()
	    {
		    DialogResult dlgResult = DialogResult.None;

		    if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["next"])
		    {
			    if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
			    {
				    var np = listViewCompliance.SelectedItems[0].Tag as NextPerformance;

				    var checkRecord = new MTOPCheckRecord
				    {
					    RecordDate = np.PerformanceDate ?? DateTime.Today,
					    CheckName = np.ParentCheck.Name,
					    GroupName = np.Group,
					    CalculatedPerformanceSource = np.PerformanceSource,
					    ParentId = np.ParentCheck.ItemId
				    };

					var form = new MTOPComplainceForm(checkRecord, _currentAircraft, _averageUtilization);
				    dlgResult = form.ShowDialog();
			    }
		    }
		    if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["last"])
		    {
			    if (listViewCompliance.SelectedItems[0].Tag is MTOPCheckRecord)
			    {
				    var check = listViewCompliance.SelectedItems[0].Tag as MTOPCheckRecord;
				    var form = new MTOPComplainceForm(check, _currentAircraft, _averageUtilization);
				    dlgResult = form.ShowDialog();
			    }
		    }

		    if (dlgResult == DialogResult.OK) InvokeComplianceAdded(null);
	    }

	    #endregion

        #region private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
        #endregion

        #region private void ListViewComplianceClick(object sender, EventArgs e)
        private void ListViewComplianceClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = false;
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["next"])
            {
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = false;
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["last"])
            {
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = true;
                ButtonEdit.Enabled = true;
            }
        }
		#endregion

	}
}
