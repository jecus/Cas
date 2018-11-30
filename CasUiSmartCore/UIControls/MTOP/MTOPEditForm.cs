using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPEditForm : Form
	{
		#region Fields

		private MTOPCheck _currentCheck;

		#endregion

		#region Constructor

		public MTOPEditForm()
		{
			InitializeComponent();
		}

		public MTOPEditForm(MTOPCheck check) : this()
		{
			_currentCheck = check;

			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			_textBoxName.Text = _currentCheck.Name;

			_lifelengthViewerRepeat.Lifelength = _currentCheck.Repeat;
			_lifelengthViewerTresh.Lifelength = _currentCheck.Thresh;
			_lifelengthViewerNotify.Lifelength = _currentCheck.Notify;

			checkBox1.Checked = _currentCheck.IsZeroPhase;

			_comboBoxCheckType.Type = typeof(MaintenanceCheckType);
			_comboBoxCheckType.SelectedItem = _currentCheck.CheckType;
			Program.MainDispatcher.ProcessControl(_comboBoxCheckType);
		}

		#endregion

		#region private bool ValidateData(out string message)

		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		private bool ValidateData(out string message)
		{
			message = "";
			if (_comboBoxCheckType.SelectedItem == null)
			{
				message = "Select check type";
				return false;
			}

			if (_lifelengthViewerTresh.Lifelength.IsNullOrZero())
			{
				message = "Please input Thresh";
				return false;
			}

			return true;
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_currentCheck.Name = _textBoxName.Text;
			_currentCheck.CheckType = _comboBoxCheckType.SelectedItem as MaintenanceCheckType ?? MaintenanceCheckType.Unknown;

			_currentCheck.IsZeroPhase = checkBox1.Checked;

			_currentCheck.Repeat = _lifelengthViewerRepeat.Lifelength;
			_currentCheck.Thresh = _lifelengthViewerTresh.Lifelength;
			_currentCheck.Notify = _lifelengthViewerNotify.Lifelength;
		}

		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string) new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				ApplyChanges();

				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentCheck);
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

	}
}
