using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;

namespace CAS.UI.UIControls.Users
{
	public partial class CopyADToAircraftForm : MetroForm
	{
		#region Fields

		
		#endregion

		#region Constructor

		public CopyADToAircraftForm()
		{
			InitializeComponent();
			UpdateInformation();
		}
		
		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			var aircraft = GlobalObjects.AircraftsCore.GetAllAircrafts();
			
			checkedListBoxAircraft.Items.Clear();
			checkedListBoxAircraft.Items.AddRange(aircraft.ToArray());
			checkedListBoxApplicability.Items.Clear();
			checkedListBoxApplicability.Items.AddRange(aircraft.ToArray());
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			{
				ApplyChanges();
				
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		private void checkedListBoxAircraft_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}
