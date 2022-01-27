using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;

namespace CAS.UI.UICAAControls.RoutineAudit
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
            AddColumn("Code", (int)(radGridView1.Width * 0.20f));
			AddColumn("Program Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("Object", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.45f));
            AddColumn("Remark", (int)(radGridView1.Width * 0.45f));
            AddColumn("Author", (int)(radGridView1.Width * 0.24f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(SmartCore.CAA.RoutineAudits.RoutineAudit item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item.Settings.AuthorId);
            var corrector = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
                CreateRow(item.Title, item.Title),
                CreateRow(item.Type.ToString(), item.Type),
                CreateRow(item.RoutineObject.ToString(), item.Type),
                CreateRow(item.Description, item.Description),
                CreateRow(item.Remark, item.Remark),
                CreateRow($"{author} ({SmartCore.Auxiliary.Convert.GetDateFormat(item.Settings.Created)} {item.Settings.Created.TimeOfDay.Hours}:{item.Settings.Created.TimeOfDay.Minutes}:{item.Settings.Created.TimeOfDay.Seconds})", author),
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

                e.RequestedEntity = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), SelectedItem.ItemId);
                e.DisplayerText = $"Routine Audit: {SelectedItem.Title}";
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;

            }
		}
		#endregion

		#endregion
	}
}
