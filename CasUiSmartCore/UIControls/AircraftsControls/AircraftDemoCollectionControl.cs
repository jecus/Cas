using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.Fleet;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CAS.UI.UIControls.PowerPlants;
using CAS.UI.UIControls.TemplatesControls.Forms;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;

namespace CAS.UI.UIControls.AircraftsControls
{
	///<summary>
	/// Контрол для представления коллекции ВС и кнопок для манипуляции с ней
	///</summary>
	public partial class AircraftDemoCollectionControl : UserControl
	{
		#region Fields

		private WaitForm waitForm;
		private AnimatedThreadWorker animatedThreadWorker;
		private CommonCollection<Aircraft> _itemsCollection;
		private List<ReferenceStatusImageLinkLabel> _controlItems;
		//private const int HEIGHT = 520;

		#endregion

		#region Constructors
		///<summary>
		/// Простой конструктор по умолчанию
		///</summary>
		public AircraftDemoCollectionControl()
		{
			InitializeComponent();
		}

		///<summary>
		/// Cоздается графический элемент на основе данной коллекции
		///</summary>
		///<param name="aircraftCollection">Данная бизнес коллекция</param>
		public AircraftDemoCollectionControl(CommonCollection<Aircraft> aircraftCollection)
		{

			waitForm = StaticWaitFormProvider.WaitForm;
			extendableRichContainer.Caption = aircraftCollection.Count + " Aircraft";
			_itemsCollection = aircraftCollection;
			FillUiElementsFromCollection();
		}
		#endregion

		#region Properties

		#region public bool Extended
		public bool Extended
		{
			get { return extendableRichContainer.Extended; }
			set { extendableRichContainer.Extended = value; }
		}
		#endregion

		#region public CommonCollection<Aircraft> AircraftCollection
		/// <summary>
		/// Возвращает или задает коллекцию ВС
		/// </summary>
		public CommonCollection<Aircraft> AircraftCollection
		{
			get { return _itemsCollection; }
			set
			{
				_itemsCollection = value;
				FillUiElementsFromCollection();
			}
		}

		#endregion

		#endregion

		#region Methods

		#region public void FillUiElementsFromCollection()
		/// <summary>
		/// Заполняет графический элемент из бизнес коллекции
		/// </summary>
		public void FillUiElementsFromCollection()
		{
			if (_itemsCollection == null) return;
			int count = _itemsCollection.Count;
			_controlItems = new List<ReferenceStatusImageLinkLabel>();
			flowLayoutPanelAircrafts.Controls.Clear();
			for (int i = 0; i < count; i++)
			{

#if SCAT
				var tempLabel = new ReferenceStatusImageLinkLabel
				{
					ActiveLinkColor = Color.FromArgb(62, 155, 246),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					//Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
					HoveredLinkColor = Color.FromArgb(62, 155, 246),
					LinkColor = Color.FromArgb(62, 155, 246),
					MaximumSize = new Size(200, 20),
					Size = new Size(190, 20),
					Tag = _itemsCollection[i],
					Text = _itemsCollection[i].RegistrationNumber + " " +
						   _itemsCollection[i].Model.ShortName,
					TextAlign = ContentAlignment.MiddleLeft,
					TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),

					Enabled = true,
					Status = Statuses.Satisfactory
				};

				var atlbLabel = new ReferenceStatusImageLinkLabel
				{
					ActiveLinkColor = Color.FromArgb(62, 155, 246),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					//Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
					HoveredLinkColor = Color.FromArgb(62, 155, 246),
					LinkColor = Color.FromArgb(62, 155, 246),
					MaximumSize = new Size(90, 20),
					Size = new Size(90, 20),
					Tag = _itemsCollection[i],
					Text = "ATLB",
					TextAlign = ContentAlignment.MiddleLeft,
					TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),

					Enabled = true,
					Status = Statuses.Satisfactory
				};

				var wpLabel = new ReferenceStatusImageLinkLabel
				{
					ActiveLinkColor = Color.FromArgb(62, 155, 246),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					//Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
					HoveredLinkColor = Color.FromArgb(62, 155, 246),
					LinkColor = Color.FromArgb(62, 155, 246),
					MaximumSize = new Size(60, 20),
					Size = new Size(60, 20),
					Tag = _itemsCollection[i],
					Text = "WP",
					TextAlign = ContentAlignment.MiddleLeft,
					TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),

					Enabled = true,
					Status = Statuses.Satisfactory
				};


				var flowLayoutPanel = new FlowLayoutPanel{AutoSize = true, FlowDirection = FlowDirection.LeftToRight};

				flowLayoutPanel.Controls.Add(tempLabel);
				flowLayoutPanel.Controls.Add(atlbLabel);
				flowLayoutPanel.Controls.Add(wpLabel);

				flowLayoutPanelAircrafts.Controls.Add(flowLayoutPanel);

				atlbLabel.DisplayerText = _itemsCollection[i].RegistrationNumber + ". List of Aircraft Technical Log Books";
				wpLabel.DisplayerText = _itemsCollection[i].RegistrationNumber + ". List of WP";
				atlbLabel.DisplayerRequested += TempButtonDisplayerRequested;
				wpLabel.DisplayerRequested += TempButtonDisplayerRequested;
#else
				var tempLabel = new ReferenceStatusImageLinkLabel
															  {
																  ActiveLinkColor = Color.FromArgb(62, 155, 246),
																  AutoSize = true,
																  AutoSizeMode = AutoSizeMode.GrowAndShrink,
																  //Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
																  HoveredLinkColor = Color.FromArgb(62, 155, 246),
																  LinkColor = Color.FromArgb(62, 155, 246),
																  MaximumSize = new Size(250,20),
																  Size = new Size(250, 20),
																  Tag = _itemsCollection[i],
																  Text = _itemsCollection[i].RegistrationNumber + " " + 
																		 _itemsCollection[i].Model.ShortName,
																  TextAlign = ContentAlignment.MiddleLeft,
																  TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),
			
																  Enabled = true,
																  Status = Statuses.Satisfactory
															  };	
				
#endif
				_controlItems.Add(tempLabel);
				if (GlobalObjects.CasEnvironment.Operators.Count == 1)
					tempLabel.DisplayerText = _itemsCollection[i].RegistrationNumber;
				else
					tempLabel.DisplayerText = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _itemsCollection[i].OperatorId).Name + ". " + _itemsCollection[i].RegistrationNumber;

				

				tempLabel.DisplayerRequested += TempButtonDisplayerRequested;
				
				
			}
			extendableRichContainer.Caption = _controlItems.Count + " Aircraft";
			_controlItems.Sort(new Comparison<ReferenceStatusImageLinkLabel>((x,y)=> string.Compare(x.Text,y.Text)));
			linkBiWeekly.Enabled = linkPowerPlants.Enabled = linkReliability.Enabled = true;
#if !SCAT
			flowLayoutPanelAircrafts.Controls.AddRange(_controlItems.ToArray());
#endif
			flowLayoutPanelAircrafts.Controls.Add(linkBiWeekly);
			flowLayoutPanelAircrafts.Controls.Add(linkPowerPlants);
			flowLayoutPanelAircrafts.Controls.Add(linkReliability);
			flowLayoutPanelAircrafts.Controls.Add(aDFleet);
			flowLayoutPanelAircrafts.Controls.Add(componentFleet);
			flowLayoutPanelAircrafts.Controls.Add(maintenanceDirectiveFleet);
			flowLayoutPanelAircrafts.Controls.Add(panelButtons);
		}

#endregion

		#region private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)

		private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var aircraft = ((ReferenceStatusImageLinkLabel)sender).Tag as Aircraft;
			if (aircraft == null)
			{
				e.Cancel = true;
				return;
			}

			var k = new Keyboard();
			if (k.ShiftKeyDown && e.TypeOfReflection == ReflectionTypes.DisplayInCurrent)
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			var text = ((ReferenceStatusImageLinkLabel) sender).Text;

			if (text.Equals("ATLB"))
			{
				e.RequestedEntity = new ATLBListScreen(aircraft);
			}
			else if (text.Equals("WP"))
			{
				e.RequestedEntity = new WorkPackageListScreen(aircraft);
			}
			else
			{
				e.RequestedEntity = new AircraftScreen(aircraft);
			}
		}

#endregion

		#region private void linkReport_DisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkReportDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "Air International. Air Fleet.";
			e.RequestedEntity = new ReportScreen(new AirFleetBuilder(_itemsCollection.ToList()));
		}

#endregion

		#region private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)
		{

#region --Проверка--
			foreach (var item in GlobalObjects.AircraftsCore.GetAllAircrafts())
			{
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);

				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
				{
					if (MessageBox.Show("Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
					{
						var form = new AverageUtilizationForm(item);
						form.ShowDialog();
					}
				}

				averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);
				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
				{
					MessageBox.Show(
						"Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Abort operation",
						"", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
			}
#endregion

			List<Aircraft> tempArray = new List<Aircraft>();
			ForecastFilterAircraft temp = new ForecastFilterAircraft();
			temp.ShowDialog();
			if (temp.FilteAircraft != null)
			{
				tempArray.AddRange(temp.FilteAircraft.ToArray());
			}
			else
			{
				e.Cancel = true;
				MessageBox.Show("not selected item");
				return;

			}
			e.DisplayerText = "All Aircraft Forecast";
			e.RequestedEntity = new AirFleetForecastListScreen(tempArray);

		}

#endregion

		#region private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "All Work packages";
			e.RequestedEntity = new AirFleetWorkPackageListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

#endregion

		#region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

		private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
		{
			//animatedThreadWorker.StopThread();
			//animatedThreadWorker = null;
			//dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
			//UpdateHeader();
			//ShowDetails();
		}

#endregion

		#region private void BackgroundAircraftLoad(object sender)

		private void BackgroundAircraftLoad(object sender)
		{
			waitForm.Visible = true;
			waitForm.Show();
			StaticWaitFormProvider.IsActive = true;

			try
			{
				//tempAircraft = GlobalObjects.CasEnvironment.Aircrafts.GetItemById(tempAircraft.ItemId);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while loading data", ex);
				return;
			}
		}

#endregion

		#region private void SetEnabledToAircraftButtons(bool isEnabled)
		/// <summary>
		/// Изменяет свойство Enabled у кнопок
		/// </summary>
		/// <param name="isEnabled"></param>
		public void SetEnabledToAircraftButtons(bool isEnabled)
		{
			foreach (ReferenceStatusImageLinkLabel t in _controlItems)
			{
				t.Enabled = isEnabled;
			}
		}

#endregion

		#region private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		
		private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayFewPages;

			TemplateAircraftAddToDataBaseForm form =
				new TemplateAircraftAddToDataBaseForm(GlobalObjects.CasEnvironment.Operators[0]);
			DialogResult formResult = form.ShowDialog();

			if (formResult == DialogResult.OK)
			{
				_itemsCollection.Add(form.TransferedAircraft);
				FillUiElementsFromCollection();

				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = form.TransferedAircraft.RegistrationNumber;
				//e.RequestedEntity = new DispatcheredAircraftScreen(form.TransferedAircraft);
				e.RequestedEntity = new AircraftScreen(form.TransferedAircraft);
			}
			else
			{
				e.Cancel = true;
			}
		}
#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			CommonCollection<Aircraft> aircrafts = new CommonCollection<Aircraft>();
			foreach (ReferenceStatusImageLinkLabel item in _controlItems)
			{
				aircrafts.Add((Aircraft)item.Tag);
			}
			CommonDeletingForm cdf = new CommonDeletingForm(typeof(Aircraft), aircrafts);
			if (cdf.ShowDialog() == DialogResult.OK)
			{
				if (cdf.DeletedObjects.Count == 0)
				{
					return;
				}

				foreach (BaseEntityObject o in cdf.DeletedObjects)
				{
					Aircraft s = o as Aircraft;
					if (s != null) _itemsCollection.Remove(s);
				}
				FillUiElementsFromCollection();
			}
		}
#endregion

		#region private void ExtendableRichContainerExtending(object sender, EventArgs e)
		private void ExtendableRichContainerExtending(object sender, EventArgs e)
		{
			flowLayoutPanelAircrafts.Visible = extendableRichContainer.Extended;
		}
#endregion

#endregion

		#region Events
		/// <summary>
		/// Событие оповещающее о начале работы в другом потоке
		/// </summary>
		public event EventHandler TaskStart;

		/// <summary>
		/// Событие оповещающее о конце работы в другом потоке
		/// </summary>
		public event EventHandler TaskEnd;

#endregion
	
		private void LinkPowerPlanst(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "Power plants";
			e.RequestedEntity = new PowerPlantListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		private void LinkAdFleet(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "AD Fleet";
			e.RequestedEntity = new DirectiveFleetListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		private void LinkComponentFleet(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "Component Fleet";
			e.RequestedEntity = new ComponentsFleetListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		private void LinkMaintenanceDirectiveFleet(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "AMP Program";
			e.RequestedEntity = new MaintenanceDirectiveFleetListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}
	}
}
