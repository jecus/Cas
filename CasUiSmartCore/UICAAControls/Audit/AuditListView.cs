using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
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
			AddColumn("Operator", (int)(radGridView1.Width * 0.20f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.30f));
			AddColumn("CreateDate", (int)(radGridView1.Width * 0.30f));
			AddColumn("Autor", (int)(radGridView1.Width * 0.30f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(CAAAudit item)
        {
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.AutorId);

            var subItems = new List<CustomCell>()
            {
                CreateRow(item.AuditNumber, item.AuditNumber),
                CreateRow(item.Operator.ToString(), item.Operator),
                CreateRow(item.Settings.Remark, item.Settings.Remark),
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.CreateDate), item.Settings.CreateDate),
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
                e.RequestedEntity = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(),null,  SelectedItem.ItemId);
                e.DisplayerText = $"Audit: {SelectedItem.AuditNumber}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
		}
		#endregion

		#endregion
	}
}
