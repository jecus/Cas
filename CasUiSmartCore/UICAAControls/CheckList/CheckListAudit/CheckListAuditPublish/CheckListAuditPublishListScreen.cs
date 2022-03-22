using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.CAA.Audit;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit.CheckListAuditPublish
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class CheckListAuditPublishListScreen : ScreenControl
	{
		private readonly int _operatorId;
		private readonly CAAAudit _selectedItem;
		private readonly CheckListAuditType _type;
		private readonly int _auditId;
		private CommonCollection<AuditPublish> _initialDocumentArray = new CommonCollection<AuditPublish>();
		private CommonCollection<AuditPublish> _resultDocumentArray = new CommonCollection<AuditPublish>();
		private CommonFilterCollection _filter;

		private CheckListAuditPublishListView _directivesViewer;



		public CheckListAuditPublishListScreen(Operator currentOperator, int operatorId, CAAAudit selectedItem, CheckListAuditType type)
		{
			_operatorId = operatorId;
			_selectedItem = selectedItem;
			_type = type;
			InitializeComponent();
			
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			
			_auditId = selectedItem.ItemId;
			InitListView();
			
			
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
	        _directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}

        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDocumentArray.Clear();
            _resultDocumentArray.Clear();


            if (_type == CheckListAuditType.Admin)
            {
	            var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"select 
 JSON_VALUE(SettingsJSON, '$.WorkflowStageId') as WorkflowStagId,
 Count(*) as AllTask 
-- Sum(case when JSON_VALUE(SettingsJSON, '$.WorkflowStatusId') = 1 then 1 else 0 end) as [Open],
 --Sum(case when JSON_VALUE(SettingsJSON, '$.WorkflowStatusId') = 2 then 1 else 0 end) as [Review],
 --Sum(case when JSON_VALUE(SettingsJSON, '$.WorkflowStatusId') = 6 then 1 else 0 end) as [Closed]
 from dbo.AuditChecks 
 where AuditId = {_auditId} and IsDeleted = 0
 group by JSON_VALUE(SettingsJSON, '$.WorkflowStageId')");
	            
	            var dtC = ds.Tables[0];
	            foreach (DataRow dr in dtC.Rows)
	            {
		            _initialDocumentArray.Add(new AuditPublish()
		            {
			            WorkFlowStageId = int.Parse(dr[0].ToString()),
			            AllTask = int.Parse(dr[1].ToString()),
		            });
	            }
	            
            }
            else
            {
	            var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"select 
WorkflowStageId as WorkflowStagId,
Count(*) as AllTask 
from dbo.CheckListTransfer 
where AuditId = {_auditId} and IsDeleted = 0 and ([To] = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId} or [From] = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId})
group by WorkflowStageId");
	            
	            var dtC = ds.Tables[0];
	            foreach (DataRow dr in dtC.Rows)
	            {
		            _initialDocumentArray.Add(new AuditPublish()
		            {
			            WorkFlowStageId = int.Parse(dr[0].ToString()),
			            AllTask = int.Parse(dr[1].ToString()),
		            });
	            }
            }
            
            
            _resultDocumentArray.AddRange(_initialDocumentArray.ToList());

            AnimatedThreadWorker.ReportProgress(100, "Complete");

		}
		#endregion

		#region private void InitListView()

		private void InitListView()
        {
            _directivesViewer = new CheckListAuditPublishListView(_selectedItem, _operatorId, _type);
            _directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			Controls.Add(_directivesViewer);
			
			_directivesViewer.DisableCopyPaste();
			_directivesViewer.DisableDeleteContext();
			_directivesViewer.DisableContectMenu();

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion
		

		#endregion
	}
}
