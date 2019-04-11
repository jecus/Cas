using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.PowerPlants
{
	public partial class PowerPlantListView : BaseListViewControl<BaseComponent>
	{
		public PowerPlantListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Aircraft" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Engine" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Position" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Part No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Serial No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Manuf. Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Install. Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Aircraft (Flight)" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Engine (Flight)" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseComponent item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var tcsnLifeLenght = Lifelength.Zero;
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentAircraftId);
			if(aircraft != null)
				tcsnLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);

			var temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(item);
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var transferDate = item.TransferRecords.GetLast().TransferDate;

			subItems.Add(new ListViewItem.ListViewSubItem { Text = aircraft.ToString(), Tag = aircraft });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PositionNumber, Tag = item.PositionNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PartNumber, Tag = item.PartNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.SerialNumber, Tag = item.SerialNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = SmartCore.Auxiliary.Convert.GetDateFormat(item.ManufactureDate), Tag = item.ManufactureDate });
			subItems.Add(new ListViewItem.ListViewSubItem
			{
				Text = transferDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "",
				Tag = transferDate
			});
			subItems.Add(new ListViewItem.ListViewSubItem { Text = tcsnLifeLenght.ToString(), Tag = tcsnLifeLenght });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = temp.ToString(), Tag = temp });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				Component d = SelectedItem;
				if (d.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
					d.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools))
				{
					e.Cancel = true;
					ConsumablePartAndKitForm form = new ConsumablePartAndKitForm(d);
					form.ShowDialog();
				}
				else
				{
					var location = d.ParentAircraftId > 0
						? $"{d.GetParentAircraftRegNumber()}."
						: d.ParentOperator != null ? $"{d.ParentOperator.Name}." : ""; //TODO:(Evgenii Babak) заменить на использование OperatorCore 
					e.DisplayerText = location + " Component PN " + d.PartNumber;
					e.RequestedEntity = new ComponentScreenNew(d);
				}
			}
		}
		#endregion
	}
}
