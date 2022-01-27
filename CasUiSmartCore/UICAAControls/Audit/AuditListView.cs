
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UICAAControls.RoutineAudit;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.CAA.Audit;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.Audit
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class AuditListView : BaseGridViewControl<CAAAudit>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

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
        public AuditListView(AnimatedThreadWorker animatedThreadWorker)
		{
            _animatedThreadWorker = animatedThreadWorker;
            InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 1;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
            AddColumn("Operator", (int)(radGridView1.Width * 0.20f));
			AddColumn("Audit №", (int)(radGridView1.Width * 0.20f));
            AddColumn("Status", (int)(radGridView1.Width * 0.20f));
			AddColumn("CreateDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("PublishedDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("ClosingDate", (int)(radGridView1.Width * 0.30f));
            AddColumn("MH", (int)(radGridView1.Width * 0.30f));
			AddColumn("Stage", (int)(radGridView1.Width * 0.30f));
			AddColumn("K for MH", (int)(radGridView1.Width * 0.30f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.30f));
            AddColumn("Author", (int)(radGridView1.Width * 0.30f));
            AddColumn("Published By", (int)(radGridView1.Width * 0.30f));
            AddColumn("Closed By", (int)(radGridView1.Width * 0.30f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

        protected override void GroupingItems()
        {
            this.radGridView1.GroupDescriptors.Clear();
            var descriptor = new GroupDescriptor();
            foreach (var colName in new List<string> { "Status" })
                descriptor.GroupNames.Add(colName, ListSortDirection.Ascending);
            this.radGridView1.GroupDescriptors.Add(descriptor);


        }

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CAAAudit item)
        {
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.AuthorId);
            var published = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.PublishedId);
            var closed = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.ClosedId);
            var stage = WorkFlowStage.GetItemById(item.Settings.WorkflowStageId);

            var publishedDate = item.Settings.PublishingDate > DateTimeExtend.GetCASMinDateTime() ? Convert.GetDateFormat(item.Settings.PublishingDate) : "";
            var closedDate = item.Settings.ClosingDate > DateTimeExtend.GetCASMinDateTime() ? Convert.GetDateFormat(item.Settings.ClosingDate) : "";

			var subItems = new List<CustomCell>()
            {
                CreateRow(item.Operator.ToString(), item.Operator),
				CreateRow(item.AuditNumber, item.AuditNumber),
				CreateRow(item.Settings.Status.ToString(), item.Settings.Status),
				CreateRow(Convert.GetDateFormat(item.Settings.CreateDate), item.Settings.CreateDate),
				CreateRow(publishedDate, item.Settings.PublishingDate),
				CreateRow(closedDate, item.Settings.ClosingDate),
				CreateRow(item.MH.ToString(), item.MH),

				CreateRow(stage.ToString(), stage),
				CreateRow(item.Settings.KMH.ToString(), item.Settings.KMH),
				CreateRow(item.Settings.Remark, item.Settings.Remark),

                CreateRow(author, author),
                CreateRow(published, published),
                CreateRow(closed, closed),
                CreateRow(corrector, corrector)
            };

            return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
            if (SelectedItem != null)
            {
                e.RequestedEntity = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(),null,  SelectedItem.ItemId);
                e.DisplayerText = $"Audit: {SelectedItem.AuditNumber}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
		}
		#endregion

		#endregion
	}
}
