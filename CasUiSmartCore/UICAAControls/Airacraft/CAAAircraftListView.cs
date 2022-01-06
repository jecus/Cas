using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.Airacraft
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAAAircraftlListView : BaseGridViewControl<Aircraft>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CAAAircraftlListView(AnimatedThreadWorker animatedThreadWorker)
		{
            _animatedThreadWorker = animatedThreadWorker;
            InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 0;
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
			AddColumn("Registration Number", (int)(radGridView1.Width * 0.20f));
			AddColumn("Serial Number", (int)(radGridView1.Width * 0.24f));
			AddColumn("Variable Number", (int)(radGridView1.Width * 0.24f));
			AddColumn("Line Number", (int)(radGridView1.Width * 0.4f));
            AddColumn("ManufactureDate", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(Aircraft item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
				CreateRow(item.RegistrationNumber, item.RegistrationNumber),
				CreateRow(item.SerialNumber, item.SerialNumber),
				CreateRow(item.VariableNumber, item.VariableNumber),
				CreateRow(item.LineNumber, item.LineNumber),
                CreateRow(item.ManufactureDate.ToString("dd-MMMM-yyyy"), item.ManufactureDate),
                CreateRow(author, author)
			};

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            e.DisplayerText = SelectedItem.RegistrationNumber;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new CAAAircraftGeneralDataScreen(SelectedItem);
        }
		#endregion

		#endregion
	}
}
