using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.Audit.PEL
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class PelPersonnelListView : BaseGridViewControl<PelSpecialist>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public PelPersonnelListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 0;
		}

        public int OperatorId { get; set; }

		#endregion

		#endregion

		#region Methods

		protected override void GroupingItems()
		{
			Grouping("Operator");
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Roles", (int)(radGridView1.Width * 0.24f));
			AddColumn("Responsibilities", (int)(radGridView1.Width * 0.24f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.24f));
		}
		#endregion
		
		
		protected override List<CustomCell> GetListViewSubItems(PelSpecialist item)
		{
			var subItems = new List<CustomCell>()
			{
				CreateRow(item.FirstName, item.FirstName),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.Specialization.ToString(), item.Specialization),
				CreateRow(item.Role.ToString(), item.Role),
				CreateRow(item.PELResponsibilities.ToString(), item.PELResponsibilities),
				CreateRow(item.Operator.ToString(), item.Operator),
			};

			return subItems;
		}


		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.Cancel = true;
		}

		#endregion
	}
}
