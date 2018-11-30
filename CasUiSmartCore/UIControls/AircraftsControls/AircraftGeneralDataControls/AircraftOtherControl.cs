using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	public partial class AircraftOtherControl : EditObjectControl
	{
		private AircraftEquipmetType _aircraftEquipmetType;
		private Aircraft _aircraft;


		#region Properties

		public string Title
		{
			get { return lableTitle.Text; }
			set { lableTitle.Text = value; }
		}

		#endregion

		#region Constructor

		public AircraftOtherControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public void UpdateControl(int aircraftId, AircraftEquipmetType aircraftEquipmetType, IEnumerable<AircraftEquipments> aircraftEquipments)

		public void UpdateControl(Aircraft aircraft, AircraftEquipmetType aircraftEquipmetType)
		{
			_aircraft = aircraft;
			_aircraftEquipmetType = aircraftEquipmetType;

			FillControls();
		}

		#endregion

		#region public override void FillControls()

		public override void FillControls()
		{
			BeginUpdate();

			// Освобождаем старые контролы
			foreach (Control control in flowLayoutPanel.Controls)
			{
				if (control is AircraftApprovalControl)
				{
					var c = (AircraftApprovalControl)control;
					c.Deleted -= Control_Deleted;
				}
			}
			flowLayoutPanel.Controls.Clear();
			flowLayoutPanel.Controls.Add(panel1);

			foreach (var aircraftEquipmet in _aircraft.AircraftEquipments.Where(a => a.AircraftEquipmetType == _aircraftEquipmetType))
			{
				var control = new AircraftApprovalControl();
				control.UpdateControl(_aircraft, aircraftEquipmet);
				control.Deleted += Control_Deleted;
				
				flowLayoutPanel.Controls.Add(control);
			}

			flowLayoutPanel.Controls.Add(panelAdd);

			EndUpdate();
		}

		#endregion

		#region public override bool GetChangeStatus()

		public override bool GetChangeStatus()
		{
			var constols = flowLayoutPanel.Controls.OfType<AircraftApprovalControl>();

			try
			{
				return constols.Any(c => c.GetChangeStatus());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while check data", ex);
				return true;
			}
		}

		#endregion

		#region public override void SaveData()

		public override void SaveData()
		{
			var constols = flowLayoutPanel.Controls.OfType<AircraftApprovalControl>();
			foreach (var control in constols)
			{
				control.SaveData();
			}
		}

		#endregion

		#region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var control = new AircraftApprovalControl();
			var newEquipment = new AircraftEquipments
			{
				AircraftId = _aircraft.ItemId,
				AircraftEquipmetType = _aircraftEquipmetType,
				AircraftOtherParameter = AircraftOtherParameters.Unknown
			};

			control.UpdateControl(_aircraft, newEquipment);
			control.Deleted += Control_Deleted;

			flowLayoutPanel.Controls.Remove(panelAdd);
			flowLayoutPanel.Controls.Add(control);
			flowLayoutPanel.Controls.Add(panelAdd);
		}

		#endregion

		#region private void Control_Deleted(object sender, EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
		{
			var control = sender as AircraftApprovalControl;
			var aircraftEquipment = control.AircraftEquipment;

			if (aircraftEquipment.ItemId > 0 && MessageBox.Show("Do you really want to delete detail params?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				try
				{
					_aircraft.AircraftEquipments.Remove(aircraftEquipment);
					GlobalObjects.CasEnvironment.Manipulator.Delete(aircraftEquipment, false);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while removing data", ex);
				}

				flowLayoutPanel.Controls.Remove(control);
				control.Deleted -= Control_Deleted; ;
				control.Dispose();
			}
			else if (aircraftEquipment.ItemId <= 0)
			{
				flowLayoutPanel.Controls.Remove(control);
				control.Deleted -= Control_Deleted; ;
				control.Dispose();
			}

		}

		#endregion
	}
}
