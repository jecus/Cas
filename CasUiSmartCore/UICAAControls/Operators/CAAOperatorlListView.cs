using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;

namespace CAS.UI.UICAAControls.Operators
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAAOperatorlListView : BaseGridViewControl<AllOperators>
	{
        private readonly AnimatedThreadWorker _animatedThreadWorker;

        #region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()

        /// <summary>
        /// </summary>
        /// <param name="animatedThreadWorker"></param>
        public CAAOperatorlListView(AnimatedThreadWorker animatedThreadWorker)
		{
            _animatedThreadWorker = animatedThreadWorker;
            InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 6;
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
			AddColumn("Name", (int)(radGridView1.Width * 0.20f));
			AddColumn("Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("ICAO", (int)(radGridView1.Width * 0.24f));
			AddColumn("IATA", (int)(radGridView1.Width * 0.24f));
			AddColumn("CAT/NC", (int)(radGridView1.Width * 0.4f));
			AddColumn("Type of Operation", (int)(radGridView1.Width * 0.4f));
			AddColumn("SPO", (int)(radGridView1.Width * 0.3f));
			AddColumn("Fleet", (int)(radGridView1.Width * 0.5f));
			AddColumn("Aircraft Type", (int)(radGridView1.Width * 0.3f));
			AddColumn("Privilages", (int)(radGridView1.Width * 0.3f));
			AddColumn("Address", (int)(radGridView1.Width * 0.3f));
			AddColumn("Phone", (int)(radGridView1.Width * 0.3f));
			AddColumn("Fax", (int)(radGridView1.Width * 0.3f));
			AddColumn("Web", (int)(radGridView1.Width * 0.3f));
			AddColumn("Email", (int)(radGridView1.Width * 0.3f));
            AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(AllOperators item)
        {
            var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

            var subItems = new List<CustomCell>()
			{
				CreateRow(item.FullName, item.FullName),
				CreateRow(item.TypeString, item.TypeString),
				CreateRow(item.ICAOCode, item.ICAOCode),
				CreateRow(item.IATACode, item.IATACode),
				CreateRow(item.CommertialString, item.CommertialString),
				CreateRow(item.TPOString, item.TPOString),
				CreateRow(item.SPOString, item.SPOString),
				CreateRow(item.FleetString, item.FleetString),
				CreateRow(item.Description, item.Description),
				CreateRow(item.PrivilagesString, item.PrivilagesString),
				CreateRow(item.Address, item.Address),
				CreateRow(item.Phone, item.Phone),
				CreateRow(item.Fax, item.Fax),
				CreateRow(item.Web, item.Web),
				CreateRow(item.Email, item.Email),
                CreateRow(author, author)
			};

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
                var form = new AddOperatorFrom(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                    _animatedThreadWorker.RunWorkerAsync();
                e.Cancel = true;
			}
		}
		#endregion

		#endregion
	}
}
