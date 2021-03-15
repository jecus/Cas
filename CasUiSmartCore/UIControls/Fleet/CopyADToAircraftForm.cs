using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.Users
{
	public partial class CopyADToAircraftForm : MetroForm
	{
		private readonly Directive _directive;

		#region Fields

		
		#endregion

		public List<Directive> Directives { get; set; }
		

		#region Constructor

		public CopyADToAircraftForm(Directive directive)
		{
			_directive = directive;
			InitializeComponent();
			UpdateInformation();
			Directives = new List<Directive>();
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
			var aircrafts = checkedListBoxAircraft.CheckedItems.Cast<Aircraft>();
			var applicability = checkedListBoxApplicability.CheckedItems.Cast<Aircraft>();

			foreach (var aircraft in aircrafts)
			{
				var a = aircraft;
				var newDirective = _directive.GetCopyUnsaved();
				newDirective.ParentBaseComponent = GlobalObjects.ComponentCore.GetAircraftFrame(a.ItemId);
				newDirective.IsApplicability = applicability.FirstOrDefault(i => i.ItemId == a.ItemId) != null;
				newDirective.IsClosed = !newDirective.IsApplicability;
				Directives.Add(newDirective);
			}
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
