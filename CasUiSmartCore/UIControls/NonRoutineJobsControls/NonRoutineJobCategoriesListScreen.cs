using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.NonRoutineJobsControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class NonRoutineJobCategoriesListScreen : CommonListScreen
	{
	   #region Fields

		#endregion
		
		#region Constructors

		#region public NonRoutineJobCategoriesListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public NonRoutineJobCategoriesListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public NonRoutineJobCategoriesListScreen(Aircraft currentAircraft) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список нерутинных работ
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат события</param>
		///<param name="beginGroup">Описывает своиство класса Event, по которому нужно сделать первичную группировку</param>
		public NonRoutineJobCategoriesListScreen(Aircraft currentAircraft, PropertyInfo beginGroup = null) 
			: base(typeof(NonRoutineJob), beginGroup)
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = "Non-routine jobs";
		}

		#endregion

		#endregion

		#region Methods

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			base.AnimatedThreadWorkerDoWork(sender, e);

			var openWPRecords = new List<WorkPackageRecord>();
			foreach (var openWorkPackage in _openPubWorkPackages.OrderBy(w => w.OpeningDate))
				openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

			foreach (NonRoutineJob nrj in InitialDirectiveArray)
			{
			   var wpr = openWPRecords.FirstOrDefault(r => r.DirectiveId == nrj.ItemId && r.WorkPackageItemType == nrj.SmartCoreObjectType.ItemId);

				if (wpr != null)
					nrj.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
			}
		}

		#region protected override void InitListView(PropertyInfo beginGroup = null)

		protected override void InitListView(PropertyInfo beginGroup = null)
		{
			DirectivesViewer = new NonRoutineJobCategoriesListView();
			DirectivesViewer.TabIndex = 2;
			DirectivesViewer.Location = new Point(panel1.Left, panel1.Top);
			DirectivesViewer.Dock = DockStyle.Fill;
			DirectivesViewer.ViewedType = typeof(NonRoutineJob);
			DirectivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemShowTaskCard,
				_toolStripSeparatorOpenOperation,
				_toolStripMenuItemHighlight,
				_toolStripSeparatorHighlightOperation,
				_toolStripMenuItemComposeWorkPackage,
				_toolStripMenuItemsWorkPackages);

			DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			panel1.Controls.Add(DirectivesViewer);
		}

		#endregion

		#region protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			NonRoutineJobForm form = new NonRoutineJobForm(new NonRoutineJob());

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}
		#endregion

		#region protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region protected override void Open()

		protected override void OpenItem()
		{
			var selected = new CommonCollection<NonRoutineJob>();
			foreach (NonRoutineJob o in DirectivesViewer.SelectedItems)
				selected.CompareAndAdd(o);
			
			foreach (NonRoutineJob t in selected)
			{
				var dp = ScreenAndFormManager.GetEditScreenOrForm(t);
				dp.Form.Show();
			}

			selected.Clear();
		}

		#endregion

		#region protected override void ShowTaskCard()
		protected override void ShowTaskCard()
		{
			if (DirectivesViewer.SelectedItems == null ||
				DirectivesViewer.SelectedItems.Count == 0) return;
			var nrj = (NonRoutineJob)DirectivesViewer.SelectedItems[0];
			if (nrj != null && nrj.AttachedFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				return;
			}

			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(nrj.AttachedFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", nrj, nrj.ItemId, nrj.AttachedFile.ItemId);
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region protected override void CreateWorkPakage()

		protected override void CreateWorkPakage()
		{
			var selectedItems = new CommonCollection<NonRoutineJob>();
			foreach (NonRoutineJob o in DirectivesViewer.SelectedItems)
				selectedItems.CompareAndAdd(o);

			try
			{
				string message;
				var wp = GlobalObjects.WorkPackageCore.AddWorkPakage(selectedItems, CurrentAircraft, out message);
				if (wp == null)
				{
					MessageBox.Show(message, (string) new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				base.AddWorkPackageToContextMenu(wp);

				var refArgs = new ReferenceEventArgs
				{
					TypeOfReflection = ReflectionTypes.DisplayInNew,
					DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title,
					RequestedEntity = new WorkPackageScreen(wp)
				};
				InvokeDisplayerRequested(refArgs);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("error while create Work Package", ex);
			}
		}

		#endregion

		#region  protected override void AddToWorkPackage(WorkPackage wp)

		protected override void AddToWorkPackage(WorkPackage wp)
		{
			var selected = new CommonCollection<NonRoutineJob>();
			foreach (NonRoutineJob o in DirectivesViewer.SelectedItems)
				selected.CompareAndAdd(o);

			if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					string message;

					if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(selected, wp.ItemId, CurrentAircraft, out message))
					{
						MessageBox.Show(message, (string) new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					if (MessageBox.Show("Items added successfully. Open work package?",
						(string) new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
						== DialogResult.Yes)
					{
						ReferenceEventArgs refArgs = new ReferenceEventArgs();
						refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
						refArgs.DisplayerText = CurrentAircraft != null
							? CurrentAircraft.RegistrationNumber + "." + wp.Title
							: wp.Title;
						refArgs.RequestedEntity = new WorkPackageScreen(wp);
						InvokeDisplayerRequested(refArgs);
					}
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Work Package", ex);
				}
			}
		}

		#endregion

		#endregion
	}
}
