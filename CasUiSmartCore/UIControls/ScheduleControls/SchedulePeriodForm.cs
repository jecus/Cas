using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.ScheduleControls
{
	public partial class SchedulePeriodForm : Form
	{
		#region Fields

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private List<SchedulePeriods> _schedulePeriods = new List<SchedulePeriods>();

		#endregion

		#region Constructor

		public SchedulePeriodForm()
		{
			InitializeComponent();

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateInformation();
		}

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_animatedThreadWorker.ReportProgress(0, "Loading");

			_schedulePeriods.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SchedulePeriodDTO,SchedulePeriods>());

			_animatedThreadWorker.ReportProgress(100, "Loading complete");
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			if (_schedulePeriods.Count <= 0) return;

			foreach (var period in _schedulePeriods)
			{
				if (period.Schedule == Schedule.Summer)
				{
					dateTimePickerSummerFrom.Value = period.From;
					dateTimePickerSummerTo.Value = period.To;
				}
				else
				{
					dateTimePickerWinterFrom.Value = period.From;
					dateTimePickerWinterTo.Value = period.To;
				}
			}
		}

		#endregion

		#region private void SchedulePeriodForm_Load(object sender, EventArgs e)

		private void SchedulePeriodForm_Load(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			if (_schedulePeriods.Count > 0)
			{
				var winterPeriod = _schedulePeriods.FirstOrDefault(p => p.Schedule == Schedule.Winter);
				var summerPeriod = _schedulePeriods.FirstOrDefault(p => p.Schedule == Schedule.Summer);

				summerPeriod.From = dateTimePickerSummerFrom.Value;
				summerPeriod.To = dateTimePickerSummerTo.Value;
				winterPeriod.From = dateTimePickerWinterFrom.Value;
				winterPeriod.To = dateTimePickerWinterTo.Value;
			}
			else
			{
				var winterPeriod = new SchedulePeriods
				{
					Schedule = Schedule.Winter,
					From = dateTimePickerWinterFrom.Value,
					To =  dateTimePickerWinterTo.Value
				};
				var summerPeriod = new SchedulePeriods
				{
					Schedule = Schedule.Summer,
					From = dateTimePickerSummerFrom.Value,
					To = dateTimePickerSummerTo.Value
				};

				_schedulePeriods.Add(winterPeriod);
				_schedulePeriods.Add(summerPeriod);
			}
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();

				foreach (var period in _schedulePeriods)
					GlobalObjects.CasEnvironment.NewKeeper.Save(period);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion
	}
}
