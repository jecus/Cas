using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.WorkPakage
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class WorkPackageListView : BaseGridViewControl<WorkPackage>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public WorkPackageListView()
		///<summary>
		///</summary>
		public WorkPackageListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Desc;
			OldColumnIndex = 1;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override List<PropertyInfo> GetTypeProperties()
		protected override List<PropertyInfo> GetTypeProperties()
		{
			var props = base.GetTypeProperties();
			var prop = props.FirstOrDefault(p => p.Name.ToLower() == "aircraft");
			props.Remove(prop);

			return props;
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		protected override void GroupingItems()
		{
			Grouping("Status");
		}
		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var item = SelectedItem;
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = item.Aircraft != null ? item.Aircraft.RegistrationNumber + "." + item.Title : item.Title;
				e.RequestedEntity = new WorkPackageScreen(item);
			}
		}
		#endregion

		#endregion
	}
}
