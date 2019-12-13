using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
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
	public partial class NonRoutineJobsStatusListScreen : CommonListScreen
	{
		#region Fields

		#endregion
		
		#region Constructors

		#region public NonRoutineJobsListScreenNew()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public NonRoutineJobsStatusListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public NonRoutineJobsListScreenNew(Aircraft currentAircraft) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список нерутинных работ
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат события</param>
		///<param name="beginGroup">Описывает своиство класса Event, по которому нужно сделать первичную группировку</param>
		public NonRoutineJobsStatusListScreen(Aircraft currentAircraft, PropertyInfo beginGroup = null) 
			: base(typeof(NonRoutineJob), beginGroup)
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = "Non-routine jobs";

			buttonAddNew.Visible = false;
			buttonDeleteSelected.Visible = false;
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов

			if (InitialDirectiveArray == null) 
				InitialDirectiveArray = new CommonCollection<NonRoutineJob>();
			InitialDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load non-routine jobs");

			try
			{
				InitialDirectiveArray.AddRange(GlobalObjects.NonRoutineJobCore.GetNonRoutineJobsStatus(CurrentAircraft));
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load non-routine jobs", exception);
			}

			AnimatedThreadWorker.ReportProgress(40, "load non-routine jobs");

			#region Фильтрация директив
			
			AnimatedThreadWorker.ReportProgress(70, "filter non-routine jobs");

			FilterItems(InitialDirectiveArray, ResultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");

			#endregion

		}
		#endregion

		#region protected override void InitListView(PropertyInfo beginGroup = null)

		protected override void InitListView(PropertyInfo beginGroup = null)
		{
			DirectivesViewer = new NonRoutineJobStatusListView();
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

		#region protected override void OpenItem()

		protected override void OpenItem()
		{
			var selected = new CommonCollection<NonRoutineJob>();
			foreach (NonRoutineJob o in DirectivesViewer.SelectedItems)
				selected.CompareAndAdd(o);

			foreach (var t in selected)
			{
				var form = ScreenAndFormManager.GetEditForm(t);
				form.Show();
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

		#region protected override void PreInitToolStripMenuItems()

		protected override void PreInitToolStripMenuItems()
		{
			ShowEditOperationContextMenu = false;
			ShowWorkPackageOperationContextMenu = false;
		}

		#endregion

		#endregion
	}
}
