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

		///<summary>
		///</summary>
		public PelPersonnelListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 0;
		}


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
			AddColumn("Position", (int)(radGridView1.Width * 0.24f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.24f));
		}
		#endregion
		
		
		protected override List<CustomCell> GetListViewSubItems(PelSpecialist item)
		{
			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Specialist.FirstName, item.Specialist.FirstName),
				CreateRow(item.Specialist.LastName, item.Specialist.LastName),
				CreateRow(item.Specialist.Occupation.ToString(), item.Specialist.Occupation),
				CreateRow(item.Role.ToString(), item.Role),
				CreateRow(item.PELResponsibilities.ToString(), item.PELResponsibilities),
				CreateRow(item.PELPosition.ToString(), item.PELPosition),
				CreateRow(item.Specialist.Operator.ToString(), item.Specialist.Operator),
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
