using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.Specialists;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

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
			AddColumn("Full Name", (int)(radGridView1.Width * 0.20f));
			AddColumn("Short Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("ICAOCode", (int)(radGridView1.Width * 0.24f));
			AddColumn("Address", (int)(radGridView1.Width * 0.4f));
			AddColumn("Phone", (int)(radGridView1.Width * 0.4f));
			AddColumn("Fax", (int)(radGridView1.Width * 0.3f));
			AddColumn("Web", (int)(radGridView1.Width * 0.5f));
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
				CreateRow(item.ShortName, item.ShortName),
				CreateRow(item.ICAOCode, item.ICAOCode),
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
