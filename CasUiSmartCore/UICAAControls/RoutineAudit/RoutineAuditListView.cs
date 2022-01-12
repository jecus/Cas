using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.CAA.RoutineAudits;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class RoutineAuditListView : BaseGridViewControl<SmartCore.CAA.RoutineAudits.RoutineAudit>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        public RoutineAuditListView()
        {
            SortDirection = SortDirection.Asc;
			InitializeComponent();
		}

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public RoutineAuditListView(AnimatedThreadWorker animatedThreadWorker)
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
			AddColumn("Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Remark", (int)(radGridView1.Width * 0.45f));
			AddColumn("Create Date", (int)(radGridView1.Width * 0.24f));
            AddColumn("Author", (int)(radGridView1.Width * 0.24f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.RoutineAudits.RoutineAudit item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
                CreateRow(item.AuditNumber, item.AuditNumber),
                CreateRow(item.Title, item.Title),
                CreateRow(item.Type, item.Type),
                CreateRow(item.Description, item.Description),
                CreateRow(item.Remark, item.Remark),
				CreateRow(item.Created.ToString(), item.Created),
                CreateRow(author, author),
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
                var form = new CommonEditorForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                    _animatedThreadWorker.RunWorkerAsync();
                e.Cancel = true;
			}
		}
		#endregion

		#endregion
	}
}
