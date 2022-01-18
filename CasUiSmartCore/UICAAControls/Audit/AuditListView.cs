using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.RoutineAudit;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Audit;

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
			AddColumn("Audit №", (int)(radGridView1.Width * 0.20f));
			AddColumn("Title", (int)(radGridView1.Width * 0.20f));
			AddColumn("Create Date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Opening date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Publishing date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Closing date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Author", (int)(radGridView1.Width * 0.20f));
			AddColumn("Published By", (int)(radGridView1.Width * 0.20f));
			AddColumn("Publishing Remark", (int)(radGridView1.Width * 0.20f));
            AddColumn("Closed By", (int)(radGridView1.Width * 0.20f));
            AddColumn("Closing Remark", (int)(radGridView1.Width * 0.20f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CAAAudit item)
        {
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.AuthorId);
            var published = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.PublishedById);
            var closed = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.ClosedById);

            var subItems = new List<CustomCell>()
			{
                CreateRow(item.AuditNumber, item.AuditNumber),
                CreateRow(item.Title, item.Title),
                CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.CreateDate), item.Settings.CreateDate),
                CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.OpeningDate), item.Settings.OpeningDate),
                CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.PublishingDate), item.Settings.PublishingDate),
                CreateRow(author, author),
                CreateRow(published, published),
				CreateRow(item.Settings.PublishedRemark, item.Settings.PublishedRemark),
                CreateRow(closed, closed),
                CreateRow(item.Settings.ClosedRemark, item.Settings.ClosedRemark),

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
                var form = new AuditForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                    _animatedThreadWorker.RunWorkerAsync();
                e.Cancel = true;

			}
		}
		#endregion

		#endregion
	}
}
