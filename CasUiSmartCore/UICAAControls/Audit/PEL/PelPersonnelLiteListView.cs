using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.Audit.PEL
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class PelPersonnelLiteListView : BaseGridViewControl<PelSpecialist>
	{
		public PelPersonnelLiteListView()
		{
			InitializeComponent();
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
