using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using Telerik.WinControls.UI;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.SupplierControls
{
	public partial class ProcessingListScreen : ScreenControl
	{
		#region Fields

		private bool _firstLoad;

		private TransferedComponentForm _transferedComponentForm;
		private CommonFilterCollection _additionalfilter = new CommonFilterCollection(typeof(IProcessingFilterParams));

		private ProcessingListView _directivesViewer;
		private ICommonCollection<BaseEntityObject> _preResultDirectiveArray = new CommonCollection<BaseEntityObject>();
		private ICommonCollection<BaseEntityObject> _resultDirectiveArray = new CommonCollection<BaseEntityObject>();

		private ComponentCollection _removedComponents = new ComponentCollection();
		private ComponentCollection _waitRemoveConfirmComponents = new ComponentCollection();
		private ComponentCollection _installedComponents = new ComponentCollection();
		private TransferRecordCollection _removedTransfers = new TransferRecordCollection();
		private TransferRecordCollection _installedTransfers = new TransferRecordCollection();
		private TransferRecordCollection _waitRemoveConfirmTransfers = new TransferRecordCollection();
		
		private RadMenuItem _toolStripMenuItemMoveTo;

		#endregion

		#region Constructors

		public ProcessingListScreen()
		{
			InitializeComponent();
		}

		public ProcessingListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;

			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region public override void OnInitCompletion(object sender)

		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{

			_directivesViewer = new ProcessingListView()
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};
			
			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
			};

			_directivesViewer.AddMenuItems(_toolStripMenuItemMoveTo);

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemMoveTo = new RadMenuItem();
			// 
			// toolStripMenuItemInstallToAnAircraft
			// 
			_toolStripMenuItemMoveTo.Size = new Size(178, 22);
			_toolStripMenuItemMoveTo.Text = "Move To...";
			_toolStripMenuItemMoveTo.Click += ToolStripMenuItemInstallToAnAircraftClick;
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;

			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());

			if (_removedComponents.Count > 0
			    || _waitRemoveConfirmComponents.Count > 0
			    || _installedComponents.Count > 0)
				_buttonTransferDetails.Enabled = true;
			else _buttonTransferDetails.Enabled = false;

			//так делается для того, чот бы форма перемещенных деталей
			//отобразилась сама только при первом открытии экрана
			if (_firstLoad == false)
				TransferedDetailFormShow();
			_firstLoad = true;
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			AnimatedThreadWorker.ReportProgress(0, "load components");

			var resultCollection = new ComponentCollection();
			_preResultDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
			_removedComponents.Clear();
			_removedTransfers.Clear();
			_waitRemoveConfirmComponents.Clear();
			_waitRemoveConfirmTransfers.Clear();
			_installedComponents.Clear();
			_installedTransfers.Clear();

			#region Загрузка всех компонентов

			resultCollection = GlobalObjects.ComponentCore.GetSupplierProcessing();


			//////////////////////////////////////////////////////
			//     проверка на установленные компоненты         //
			//////////////////////////////////////////////////////
			var lastInstalledDetails = resultCollection.GetLastInstalledComponentsOnProcessing();
			foreach (var component in lastInstalledDetails)
			{
				_installedComponents.Add(component);
				_installedTransfers.Add(component.TransferRecords.GetLast());

				//удаление данного компонента из коллекции
				//т.к. его отображать не нужно
				resultCollection.Remove(component);
			}

			//////////////////////////////////////////////////////
			//        проверка на удаленные компоненты          //
			//////////////////////////////////////////////////////

			//извлечение из базы данных всех записей о перемещении
			//компонентов с данного базового агрегата
			var records = new TransferRecordCollection();
			records.AddRange(GlobalObjects.TransferRecordCore.GetLastTransferRecordsFromSuppliers().ToArray());
			records.AddRange(GlobalObjects.TransferRecordCore.GetLastTransferRecordsFromSpecialist().ToArray());

			foreach (var record in records)
			{
				//загрузка и БД детали, которой пренадлежит данная запись о перемещении
				var component = GlobalObjects.ComponentCore.GetComponentById(record.ParentId);

				if (component == null)
					continue;

				if (record.DODR)
				{
					//если перемещение подтверждено, то деталь записывается в "перемещенные"
					//окна "TransferedDetails"
					if (_removedComponents.CompareAndAdd(component)) _removedTransfers.Add(record);
				}
				else
				{
					//если перемещение не подтверждено, то деталь записывается в 
					//"ожидабщие подтверждения" окна "TransferedDetails"
					if (_waitRemoveConfirmComponents.CompareAndAdd(component)) _waitRemoveConfirmTransfers.Add(record);
				}
			}


			#endregion

			#region Слияние компонентов в одну коллекцию

			AnimatedThreadWorker.ReportProgress(40, "calculation of components");

			foreach (var component in resultCollection)
				_preResultDirectiveArray.Add(component);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

			AnimatedThreadWorker.ReportProgress(100, "calculation over");

		}

		#endregion

		#region private void ButtonTransferedDetailsClick(object sender, EventArgs e)

		private void ButtonTransferedDetailsClick(object sender, EventArgs e)
		{
			TransferedDetailFormShow();
		}

		#endregion

		#region private void MoveToCommand()

		private void MoveToCommand()
		{
			if (_directivesViewer.SelectedItems.Count == 0)
				return;

			if (GlobalObjects.AircraftsCore.GetAircraftsCount() == 0 &&
			    GlobalObjects.CasEnvironment.Stores.Count == 0)
			{
				MessageBox.Show("You dont remove this component because you dont have a aircrafts", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var components = new CommonCollection<Component>();
			foreach (var o in _directivesViewer.SelectedItems)
			{
				IDirective dir;
				if (o is NextPerformance)
					dir = ((NextPerformance)o).Parent;
				else dir = o as IDirective;

				if (dir == null) continue;
				if (dir is ComponentDirective && !components.Contains(((ComponentDirective)dir).ParentComponent))
					components.Add(((ComponentDirective)dir).ParentComponent);
				else if (dir is Component && !components.Contains((Component)dir))
					components.Add((Component)dir);
			}

			if (components.Count <= 0)
				return;

			var dlg = new MoveComponentForm(components.ToArray(), CurrentStore);
			dlg.Text = "Move " +
			           (components.Count > 1
				           ? "components"
				           : "component " + components[0].Description)
			           + " to aircraft";

			dlg.ShowDialog();

			if (dlg.DialogResult == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				//AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}

		}
		#endregion

		#region private void TransferedDetailFormShow()
		private void TransferedDetailFormShow()
		{
			if (_transferedComponentForm != null) _transferedComponentForm.Show();
			else
			{
				if (_removedComponents.Count > 0 || _waitRemoveConfirmComponents.Count > 0
				    || _installedComponents.Count > 0)
				{
					_transferedComponentForm = new TransferedComponentForm(_removedComponents.ToArray(),
						_removedTransfers.ToArray(),
						_waitRemoveConfirmComponents.ToArray(),
						_waitRemoveConfirmTransfers.ToArray(),
						_installedComponents.ToArray(),
						_installedTransfers.ToArray(),
						SmartCoreType.Supplier);
					_transferedComponentForm.Show();
					_transferedComponentForm.Closed += TransferedComponentFormClosed;
					_transferedComponentForm.ButtonAddClick += TransferedComponentFormButtonAddClick;
					_transferedComponentForm.ButtonDeleteClick += TransferedComponentFormButtonDeleteClick;
					_transferedComponentForm.ButtonCancelClick += TransferedComponentFormButtonCancelClick;
				}
			}
		}
		#endregion

		#region private void ToolStripMenuItemInstallToAnAircraftClick(object sender, EventArgs e)

		private void ToolStripMenuItemInstallToAnAircraftClick(object sender, EventArgs e)
		{
			MoveToCommand();
		}

		#endregion

		#region private void TransferedDetailFormClosed(object sender, EventArgs e)
		private void TransferedComponentFormClosed(object sender, EventArgs e)
		{
			_transferedComponentForm = null;
		}
		#endregion

		#region private void TransferedDetailFormButtonDeleteClick(object sender, EventArgs e)
		private void TransferedComponentFormButtonDeleteClick(object sender, EventArgs e)
		{
			_transferedComponentForm.Close();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void TransferedDetailFormButtonAddClick(object sender, EventArgs e)
		private void TransferedComponentFormButtonAddClick(object sender, EventArgs e)
		{
			_transferedComponentForm.Close();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void TransferedDetailFormButtonCancelClick(object sender, EventArgs e)
		private void TransferedComponentFormButtonCancelClick(object sender, EventArgs e)
		{
			_transferedComponentForm.Close();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_additionalfilter, _preResultDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

			var component = new List<Component>();

			if (_resultDirectiveArray.All(c => c is ComponentDirective))
			{
				foreach (ComponentDirective cd in _resultDirectiveArray)
				{
					component.Add(cd.ParentComponent);
				}
			}

			_resultDirectiveArray.AddRange(component.ToArray());

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion


		#region private void AdditionalFilterItems(IEnumerable<BaseEntityObject> initialCollection, ICommonCollection<BaseEntityObject> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void AdditionalFilterItems(IEnumerable<BaseEntityObject> initialCollection, ICommonCollection<BaseEntityObject> resultCollection)
		{
			if (_additionalfilter == null || _additionalfilter.Count == 0)
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (BaseEntityObject pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
				//}
				if (_additionalfilter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _additionalfilter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _additionalfilter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

	}
}
