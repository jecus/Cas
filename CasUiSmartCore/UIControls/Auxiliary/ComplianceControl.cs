using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
	///<summary>
	///</summary>
	public partial class ComplianceControl : UserControl, IReference
	{
		///<summary>
		///</summary>
		protected ComplianceControl()
		{
			InitializeComponent();
		}

		///<summary>
		///</summary>
		public bool ShowContent
		{
			get
			{
				return panelContainer.Visible;
			}
			set { panelContainer.Visible = value; }
		}

		public bool ShowContainer
		{
			get { return extendableRichContainer1.Visible; }
			set { extendableRichContainer1.Visible = value; }
		}

		#region Implementation of IReference

		public IDisplayer Displayer { get; set; }
		public string DisplayerText { get; set; }
		public IDisplayingEntity Entity { get; set; }
		public ReflectionTypes ReflectionType { get; set; }

		/// <summary>
		/// Occurs when linked invoker requests displaying 
		/// </summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion

		#region protected virtual void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		protected virtual void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			backgroundWorker.ReportProgress(50);
			backgroundWorker.ReportProgress(100);
		}
		#endregion

		#region protected virtual void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)

		protected virtual void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			//progressBarLoad.Value = e.ProgressPercentage;
		}
		#endregion

		#region protected virtual void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected virtual void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}
		#endregion

		#region public void CalcelAsync()
		/// <summary>
		/// Запрашивает отмену асинхронной операции
		/// </summary>
		public void CalcelAsync()
		{
			if (backgroundWorker.IsBusy)
			{
				backgroundWorker.CancelAsync();

				WaitCancelForm wcf = new WaitCancelForm(backgroundWorker)
				{
					StartPosition = FormStartPosition.CenterScreen
				};
				wcf.ShowDialog();

				while (backgroundWorker.IsBusy)
				{
					Thread.Sleep(500);
				}
			}
		}
		#endregion

		#region protected DateTime GetDate(NextPerformance destination)
		/// <summary>
		/// Возвращает дату-время "след. выполнения" задачи
		/// </summary>
		/// <param name="destination"></param>
		/// <returns></returns>
		protected DateTime GetDate(NextPerformance destination)
		{
			if (destination.PerformanceDate.HasValue)
			{
				return destination.PerformanceDate.Value;
			}
			return DateTimeExtend.GetCASMinDateTime();
		}

		#endregion

		#region protected virtual void AddListViewItem(NextPerformance np)
		protected virtual void AddListViewItem(NextPerformance np)
		{
			string[] subs =
				new[]  
				{ 
					np.WorkType,
					np.PerformanceDate != null 
						? SmartCore.Auxiliary.Convert.GetDateFormat(np.PerformanceDate) 
						: "N/A",
					np.PerformanceSource.ToString(),
					np.PerformanceSourceC.ToString(),
					np?.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(np?.NextPerformanceDateNew) : "",
					np.NextLimit.ToString(),
					np.NextLimitC.ToString(),
					"",
				};

			ListViewItem newItem = new ListViewItem(subs)
			{
				BackColor = UsefulMethods.GetColor(np),
				Group = listViewCompliance.Groups[0],
				Tag = np,
			};
			listViewCompliance.Items.Add(newItem);
		}
		#endregion

		#region protected void SetItemColor(int index, Color backColor)
		protected void SetItemColor(int index, Color backColor)
		{
			listViewCompliance.Items[index].BackColor = backColor;
		}
		#endregion

		private void ExtendableRichContainer1Extending(object sender, EventArgs e)
		{
			panelContainer.Visible = !panelContainer.Visible;
		}

		private void ListViewComplainceSelectedIndexChanged(object sender, EventArgs e)
		{
			ButtonDelete.Enabled = false;
			ButtonEdit.Enabled = false;
			if (listViewCompliance.SelectedItems.Count == 0)
			{
				return;
			}
			ButtonDelete.Enabled = true;
			ButtonEdit.Enabled = true;
		}

		#region protected void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
		protected void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
		{
			if(item == null)
				return;
			if(item is NextPerformance)
			{
				NextPerformance np = item as NextPerformance;
				if (np.BlockedByPackage != null)
				{
					listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
					listViewItem.ToolTipText = "This performance is involved on Work Package:" + np.BlockedByPackage.Title;
				}
				else
				{
					if (np.Condition == ConditionState.Overdue)
						listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
					if (np.Condition == ConditionState.Notify)
						listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					if (np.Condition == ConditionState.NotEstimated)
						listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
				}    
			}
			//else if (item is AbstractPerformanceRecord)
			//{
			//    AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
			//    if (apr.WorkPackage != null)
			//    {
			//        //запись о выполнении блокируется найденым пакетом
			//        listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
			//        listViewItem.ToolTipText =
			//            "Perform of the task:" + apr.Parent +
			//            "\nadded by Work Package:" +
			//            "\n" + apr.WorkPackage.Title +
			//            "\nTo remove a performance of task, you need to exclude task from this work package," +
			//            "\nor delete the work package ";
			//    }
			//    else if (apr is DirectiveRecord)
			//    {
			//        DirectiveRecord dr = apr as DirectiveRecord;
			//        if (dr.MaintenanceDirectiveRecordId > 0)
			//        {
			//            DirectiveRecord mdr = GlobalObjects.CasEnvironment.Loader.GetObject<DirectiveRecord>(dr.MaintenanceDirectiveRecordId);
			//            if (mdr != null && mdr.ParentType == SmartCoreType.MaintenanceDirective)
			//            {
			//                MaintenanceDirective md = GlobalObjects.CasEnvironment.Loader.GetMaintenanceDirective(mdr.ParentId);
			//                if (md != null)
			//                {
			//                    listViewItem.ToolTipText =
			//                        "Perform of the task:" + dr.WorkType +
			//                        "\nadded by MPD Item:" +
			//                        "\n" + md.TaskNumberCheck;
			//                }
			//            }
			//        }
			//    }
			//}
		}
		#endregion

		#region public void UpdateItemColor(BaseEntityObject item)
		/// <summary>
		/// Обновляет подсветку для переданного элемента
		/// </summary>
		/// <param name="item">Элемент, для которого требуется обновить подсветку</param>
		public void UpdateItemColor(BaseEntityObject item)
		{
			List<ListViewItem> lvi =
				listViewCompliance.Items.Cast<ListViewItem>()
								   .Where(listViewItem => listViewItem.Tag == item)
								   .ToList();

			foreach (ListViewItem listViewItem in lvi)
			{
				SetItemColor(listViewItem, item);
			}
		}
		#endregion

		#region protected void InvokeDisplayerRequested(ReferenceEventArgs e)
		///<summary>
		/// Запускает событие об создании новой вкладки
		///</summary>
		///<param name="e">экран и параметры новой вкладки</param>
		protected void InvokeDisplayerRequested(ReferenceEventArgs e)
		{
			EventHandler<ReferenceEventArgs> handler = DisplayerRequested;
			if (handler != null) handler(this, e);
		}
		#endregion

		#region Events

		///<summary>
		///</summary>
		public event EventHandler ComplianceAdded;

		///<summary>
		///</summary>
		///<param name="e"></param>
		public void InvokeComplianceAdded(EventArgs e)
		{
			EventHandler handler = ComplianceAdded;
			if (handler != null) handler(this, e);
		}

		#endregion
	}
}
