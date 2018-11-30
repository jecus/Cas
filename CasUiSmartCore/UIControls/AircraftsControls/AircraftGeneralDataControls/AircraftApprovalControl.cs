using System;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	public partial class AircraftApprovalControl : EditObjectControl
	{
		private  AircraftEquipments _aircraftEquipment;
		private  Aircraft _aircraft;

		public AircraftEquipments AircraftEquipment
		{
			get { return _aircraftEquipment; }
		}

		#region Constructor

		public AircraftApprovalControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public void UpdateControl(AircraftEquipments aircraftEquipment)

		public void UpdateControl(Aircraft aircraft, AircraftEquipments aircraftEquipment)
		{
			if (aircraftEquipment == null)
				throw new ArgumentNullException("aircraftEquipment", "can not be null");

			_aircraftEquipment = aircraftEquipment;
			_aircraft = aircraft;

			FillControls();
		}

		#endregion

		#region public override void FillControls()

		public override void FillControls()
		{
			BeginUpdate();

			aircraftParametrComboBox.Type = typeof(AircraftOtherParameters);
			aircraftParametrComboBox.AddItem(AircraftOtherParameters.Unknown);
			aircraftParametrComboBox.SelectedItem = _aircraftEquipment.AircraftOtherParameter;
			textBoxDescription.Text = _aircraftEquipment.Description;

			EndUpdate();
		}

		#endregion

		#region public override bool GetChangeStatus()

		public override bool GetChangeStatus()
		{
			if (_aircraftEquipment.Description != textBoxDescription.Text ||
			    _aircraftEquipment.AircraftOtherParameter.ItemId != aircraftParametrComboBox.SelectedItem?.ItemId)
			{
				return true;
			}
			return false;
		}

		#endregion

		#region public override void SaveData()

		public override void SaveData()
		{
			_aircraftEquipment.AircraftOtherParameter = (AircraftOtherParameters) aircraftParametrComboBox.SelectedItem;
			_aircraftEquipment.Description = textBoxDescription.Text;

			if (_aircraftEquipment.ItemId <= 0)
			{
				_aircraft.AircraftEquipments.Add(_aircraftEquipment);
			}

			GlobalObjects.CasEnvironment.NewKeeper.Save(_aircraftEquipment);
				
		}

		#endregion

		#region Events

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}

		public event EventHandler Deleted;

		#endregion
	}
}
