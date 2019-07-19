using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.MaintananceProgram
{
	/// <summary>
	/// Форма для переноса шаблона ВС в рабочую базу данных
	/// </summary>
	public partial class MaintenanceDirectiveAPUCalculationForm : MetroForm
	{

		#region Fields

		private List<MaintenanceDirective> _calcItems = new List<MaintenanceDirective>();
		private List<MaintenanceDirective> _items = new List<MaintenanceDirective>();
		private List<MaintenanceDirective> _remove = new List<MaintenanceDirective>();

		#endregion

		#region Constructors

		#region private MaintenanceDirectiveBindDetailForm()

		/// <summary>
		/// Создает форму для переноса шаблона ВС в рабочую базу данных
		/// </summary>
		private MaintenanceDirectiveAPUCalculationForm()
		{
			InitializeComponent();
		}

		#endregion

		#region public MaintenanceDirectiveBindDetailForm(MaintenanceCheck maintenanceCheck) : this()

		/// <summary>
		/// Создает форму для привязки задач к выполнению чека программы обслуживания
		/// </summary>
		public MaintenanceDirectiveAPUCalculationForm(List<MaintenanceDirective> directives)
			: this()
		{
			if(_items == null)
				throw new ArgumentNullException("maintenanceDirective", "must be not null");
			_items.AddRange(directives.Where(i => i.Threshold.RepeatInterval.Hours.HasValue));
			_calcItems.AddRange(directives.Where(i => i.APUCalc));

			UpdateConrols();
		}

		#endregion

		#endregion


		#region Methods

		private void UpdateConrols()
		{
			listViewMpdAll.SetItemsArray(_items.ToArray());
			listViewMpdApu.SetItemsArray(_calcItems.ToArray());
		}


		#region private void ButtonCloseClick(object sender, EventArgs e)

		private void ButtonCloseClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void ButtonAddClick(object sender, EventArgs e)

		private void ButtonAddClick(object sender, EventArgs e)
		{
			if(listViewMpdAll.SelectedItem == null)
				return;

			listViewMpdApu.InsertItems(listViewMpdAll.SelectedItems.ToArray());
			_calcItems.AddRange(listViewMpdAll.SelectedItems.ToArray());
		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (listViewMpdApu.SelectedItem == null)
				return;

			foreach (var item in listViewMpdApu.SelectedItems)
			{
				_remove.Add(item);
				_calcItems.Remove(item);
			}

			listViewMpdApu.SetItemsArray(_calcItems.ToArray());
		}
		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (var item in _calcItems)
				{
					item.APUCalc = true;
					GlobalObjects.CasEnvironment.NewKeeper.Save(item);
				}

				foreach (var item in _remove)
				{
					item.APUCalc = false;
					GlobalObjects.CasEnvironment.NewKeeper.Save(item);
				}

			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while update record", ex);
			}
		}

		#endregion

		#endregion
	}

}