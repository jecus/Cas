using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.NewGrid;
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
	public partial class PowerPlantListView : BaseGridViewControl<BaseComponent>
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
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.20f));
			AddColumn("Engine", (int)(radGridView1.Width * 0.20f));
			AddColumn("Position", (int)(radGridView1.Width * 0.20f));
			AddColumn("Part No", (int)(radGridView1.Width * 0.20f));
			AddColumn("Serial No", (int)(radGridView1.Width * 0.20f));
			AddDateColumn("Manuf. Date", (int)(radGridView1.Width * 0.20f));
			AddDateColumn("Install. Date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Aircraft (Flight)", (int)(radGridView1.Width * 0.20f));
			AddColumn("Engine (Flight)", (int)(radGridView1.Width * 0.20f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		protected override List<CustomCell> GetListViewSubItems(BaseComponent item)
		{
			var tcsnLifeLenght = Lifelength.Zero;
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentAircraftId);
			if(aircraft != null)
				tcsnLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);

			var temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(item);
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var transferDate = item.TransferRecords.GetLast().TransferDate;

			return new List<CustomCell>
			{
				CreateRow(aircraft.ToString(), aircraft ),
				CreateRow(item.Description, item.Description ),
				CreateRow(item.PositionNumber, item.PositionNumber ),
				CreateRow(item.PartNumber, item.PartNumber ),
				CreateRow(item.SerialNumber, item.SerialNumber ),
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.ManufactureDate), item.ManufactureDate ),
				CreateRow(transferDate > DateTimeExtend.GetCASMinDateTime() ? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "", transferDate),
				CreateRow(tcsnLifeLenght.ToString(), tcsnLifeLenght ),
				CreateRow(temp.ToString(), temp ),
				CreateRow(author, author )
			};
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
