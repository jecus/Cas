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
			
			labelTitle.Text = $"Audit Status : {selectedItem.StatusName}";
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
	            var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"
DECLARE @count INT
DECLARE @countNotSatis INT
DECLARE @countNotSatisRCA INT
SELECT
@count =  COUNT(*),
@countNotSatis = Sum(case when IsSatisfactory = 0 then 1 else 0 end),
@countNotSatisRCA = Sum(case when IsSatisfactory = 0 and WorkflowStageId in (4) then 1 else 0 end)
FROM [dbo].[AuditChecks]  where AuditId = {_auditId} and IsDeleted = 0




select 
 WorkflowStageId as WorkflowStageId,
 case when WorkflowStageId in(2,3,6) then @count else @countNotSatis end as AllTask,
 case when WorkflowStageId in (4) then @countNotSatisRCA
 else Count(*) end as TaskInProgress
 from dbo.AuditChecks 
 where AuditId = {_auditId} and IsDeleted = 0
 group by WorkflowStageId
");
	            
	            var dtC = ds.Tables[0];
	            foreach (DataRow dr in dtC.Rows)
	            {
		            _initialDocumentArray.Add(new AuditPublish()
		            {
			            WorkFlowStageId = int.Parse(dr[0].ToString()),
			            AllTask = int.Parse(dr[1].ToString()),
			            TaskInProgress = int.Parse(dr[2].ToString()),
		            });
	            }
	            
            }
            else
            {
	            var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@" ;WITH cte AS
(
   SELECT rec.*, auditor.Auditor ,auditee.Auditee, ac.*, ROW_NUMBER() OVER (PARTITION BY rec.CheckListId ORDER BY rec.ItemId DESC) AS rn
   FROM [AuditPelRecords] rec
   cross apply
   (
		select SpecialistId as Auditor from  [dbo].[PelSpecialist] where ItemId = rec.AuditorId
   ) as auditor
   cross apply
   (
		select SpecialistId as Auditee from  [dbo].[PelSpecialist] where ItemId = rec.AuditeeId
   ) as auditee
   cross apply
   (
		select JSON_VALUE(SettingsJSON, '$.WorkflowStageId') as WorkflowStageId, JSON_VALUE(SettingsJSON, '$.WorkflowStatusId') as WorkflowStatusId   from  [dbo].AuditChecks 
		where AuditId = rec.AuditId and CheckListId = rec.CheckListId
   ) as ac
   where rec.AuditId in ({_auditId}) and rec.IsDeleted = 0
)
SELECT WorkflowStageId, Count(*), Sum(case when ([Auditor] = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId} or [Auditee] = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId}) then 1 else 0 end)
FROM cte
WHERE rn = 1
group by WorkflowStageId");
	            
	            var dtC = ds.Tables[0];
	            foreach (DataRow dr in dtC.Rows)
	            {
		            _initialDocumentArray.Add(new AuditPublish()
		            {
			            WorkFlowStageId = int.Parse(dr[0].ToString()),
			            AllTask = int.Parse(dr[1].ToString()),
			            MyTask = int.Parse(dr[2].ToString()),
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
