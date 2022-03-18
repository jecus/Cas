
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UICAAControls.CheckList.CheckListAudit;
using CAS.UI.UICAAControls.RoutineAudit;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UICAAControls.Audit
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class AuditListView : BaseGridViewControl<CAAAudit>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;
        private readonly CheckListAuditType _checkListAuditType;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public AuditListView()
        {
            SortDirection = SortDirection.Asc;
			InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        /// <param
        ///     name="checkListAuditType">
        /// </param>
        public AuditListView(AnimatedThreadWorker animatedThreadWorker, CheckListAuditType checkListAuditType) : this()
		{
            _animatedThreadWorker = animatedThreadWorker;
            _checkListAuditType = checkListAuditType;
            SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }

        #endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("All Tasks", (int)(radGridView1.Width * 0.20f));
			AddColumn("My Tasks", (int)(radGridView1.Width * 0.20f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.20f));
			AddColumn("Audit №", (int)(radGridView1.Width * 0.20f));
            AddColumn("Status", (int)(radGridView1.Width * 0.20f));
			AddColumn("CreateDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("PublishedDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("Perform", (int)(radGridView1.Width * 0.30f));
            AddColumn("ClosingDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("MH", (int)(radGridView1.Width * 0.30f));
			
			AddColumn("K for MH", (int)(radGridView1.Width * 0.30f));
			AddColumn("K * MH", (int)(radGridView1.Width * 0.30f));

            AddColumn("WorkTime", (int)(radGridView1.Width * 0.30f));
            AddColumn("Stage", (int)(radGridView1.Width * 0.30f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.30f));
            AddColumn("Author", (int)(radGridView1.Width * 0.30f));
            AddColumn("Published By", (int)(radGridView1.Width * 0.30f));
            AddColumn("Closed By", (int)(radGridView1.Width * 0.30f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        protected override void GroupingItems()
        {
            
            Grouping("Status");
        }

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CAAAudit item)
		{
			if (_checkListAuditType == CheckListAuditType.Admin)
			{
				radGridView1.Columns[0].Width = 0;
				radGridView1.Columns[0].IsVisible = false;
				radGridView1.Columns[1].IsVisible = false;
			}
	        
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.AuthorId);
            var published = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.PublishedId);
            var closed = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.ClosedId);
            var stage = WorkFlowStage.GetItemById(item.Settings.WorkflowStageId);

            var publishedDate = item.Settings.PublishingDate > DateTimeExtend.GetCASMinDateTime() ? Convert.GetDateFormat(item.Settings.PublishingDate) : "";
            var closedDate = item.Settings.ClosingDate > DateTimeExtend.GetCASMinDateTime() ? Convert.GetDateFormat(item.Settings.ClosingDate) : "";

            var subItems = new List<CustomCell>();
            
            
			subItems.AddRange(new List<CustomCell>()
            {
	            CreateRow($"{item.TaskCount} tasks",item.TaskCount),
	            CreateRow($"{item.MyTask} tasks",item.MyTask),
                CreateRow(item.Operator.ToString(), item.Operator),
				CreateRow(item.AuditNumber, item.AuditNumber),
				CreateRow(item.Settings.Status.ToString(), item.Settings.Status),

				CreateRow(Convert.GetDateFormat(item.Settings.CreateDate), item.Settings.CreateDate),
				CreateRow(publishedDate, item.Settings.PublishingDate),
				CreateRow($"{Convert.GetDateFormat(item.Settings.From)} - {Convert.GetDateFormat(item.Settings.To)}", item.Settings.PublishingDate),
				CreateRow(closedDate, item.Settings.ClosingDate),

				CreateRow(item.MH.ToString(), item.MH),
                CreateRow(item.Settings.KMH.ToString(), item.Settings.KMH),
                CreateRow(item.KMLW, item.KMLW),

				
                CreateRow(item.WorkTime, item.WorkTime),
                CreateRow(stage.ToString(), stage),
                CreateRow(item.Settings.Remark, item.Settings.Remark),
                CreateRow(author, author),
                CreateRow(published, published),
                CreateRow(closed, closed),
                CreateRow(corrector, corrector)
            });

            return subItems;
		}

		#endregion

        public override void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.SelectedItems == null ||
                this.SelectedItems.Count == 0) return;

            string typeName = nameof(CheckLists);

            DialogResult confirmResult =
                MessageBox.Show(this.SelectedItems.Count == 1
                        ? "Do you really want to delete " + typeName + " " + this.SelectedItems[0] + "?"
                        : "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                this.radGridView1.BeginUpdate();
                GlobalObjects.NewKeeper.Delete(this.SelectedItems.OfType<BaseEntityObject>().ToList(), true);

                foreach (var audit in this.SelectedItems)
                {
                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update dbo.AuditCheckRecords set IsDeleted = 1 where AuditRecordId in (select ItemId from dbo.AuditChecks where AuditId = {audit.ItemId})");

                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update dbo.AuditRecords set IsDeleted = 1 where AuditId = {audit.ItemId}");

                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update [dbo].[AuditChecks] set IsDeleted = 1 where AuditId = {audit.ItemId}");
                    
                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
	                    $"update [dbo].[AuditPelRecords] set IsDeleted = 1 where AuditId = {audit.ItemId}");
                }


                this.radGridView1.EndUpdate();
                _animatedThreadWorker.RunWorkerAsync();
            }
        }

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
            if (SelectedItem != null)
            {
                e.RequestedEntity = new CheckListAuditScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), OperatorId ,  SelectedItem.ItemId, _checkListAuditType);
                e.DisplayerText = $"Audit: {SelectedItem.AuditNumber}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
		}
		#endregion

		#endregion
	}
}
