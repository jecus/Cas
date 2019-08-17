using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
	/// <summary>
	/// Форма для установки агрегата со склада на ВС
	/// </summary>
	public partial class MoveProductForm : MetroForm
	{
		

		#region Fields

		private Store[] _stores;
		private readonly PurchaseOrder _order;
		
		#endregion

		#region Constructors

		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public MoveProductForm()
		{
			InitializeComponent();
		}

		public MoveProductForm(PurchaseOrder order) : this()
		{
			_order = order;
			UpdateInformation();
		}
		
		#endregion

		#region Methods

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			var personnel = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SpecialistDTO, Specialist>();
			comboBoxReleased.Items.Clear();
			comboBoxReleased.Items.AddRange(personnel.ToArray());

			comboBoxRecived.Items.Clear();
			comboBoxRecived.Items.AddRange(personnel.ToArray());

			dataGridViewComponents.Rows.Clear();
			
			_stores = GlobalObjects.CasEnvironment.Stores.ToArray();
			comboBoxStore.Items.Clear();
			comboBoxStore.Items.AddRange(_stores);
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)

		private void ButtonCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#endregion

		


	}
}
