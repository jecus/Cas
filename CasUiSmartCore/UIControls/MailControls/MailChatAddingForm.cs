using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.General.Mail;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailChatAddingForm : Form
	{
		#region Fields

		private readonly MailChats _mailChats;
		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private List<Supplier> _suppliers = new List<Supplier>();

		#endregion

		#region Constructor

		public MailChatAddingForm()
		{
			InitializeComponent();
		}

		public MailChatAddingForm(MailChats mailChats) : this()
		{
			_mailChats = mailChats;
			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBoxSupplierFrom.Items.Clear();
			comboBoxSupplierFrom.Items.AddRange(_suppliers.ToArray());
			comboBoxSupplierFrom.Items.Add(Supplier.Unknown);

			comboBoxSupplierTo.Items.Clear();
			comboBoxSupplierTo.Items.AddRange(_suppliers.ToArray());
			comboBoxSupplierTo.Items.Add(Supplier.Unknown);


			if(_mailChats.SupplierFrom != Supplier.Unknown)
				comboBoxSupplierFrom.SelectedItem = _mailChats.SupplierFrom;
			if (_mailChats.SupplierTo != Supplier.Unknown)
				comboBoxSupplierTo.SelectedItem = _mailChats.SupplierTo;

			textBoxDescription.Text = _mailChats.Description;
			dateTimePickerCreateDate.Value = _mailChats.CreateDate;
		}

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_suppliers.Clear();

			_animatedThreadWorker.ReportProgress(0, "Loading");

			_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO,Supplier>());

			_animatedThreadWorker.ReportProgress(100, "Loading complete");
		}

		#endregion

		#region private void MailChatAddingForm_Load(object sender, EventArgs e)

		private void MailChatAddingForm_Load(object sender, EventArgs e)
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
			_mailChats.CreateDate = dateTimePickerCreateDate.Value;
			_mailChats.Description = textBoxDescription.Text;
			_mailChats.SupplierFrom = comboBoxSupplierFrom.SelectedItem as Supplier;
			_mailChats.SupplierTo = comboBoxSupplierTo.SelectedItem as Supplier;
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_mailChats);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void comboBoxSupplierFrom_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxSupplierFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			var from = comboBoxSupplierFrom.SelectedItem as Supplier;
			if (from != null)
			{
				comboBoxSupplierTo.SelectedItem = null;
				comboBoxSupplierTo.Text = GlobalObjects.CasEnvironment.Operators[0].Name;
			}
		}

		#endregion

		#region private void comboBoxSupplierTo_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxSupplierTo_SelectedIndexChanged(object sender, EventArgs e)
		{
			var to = comboBoxSupplierTo.SelectedItem as Supplier;
			if (to != null)
			{
				comboBoxSupplierFrom.SelectedItem = null;
				comboBoxSupplierFrom.Text = GlobalObjects.CasEnvironment.Operators[0].Name;
			}
		}

		#endregion
	}
}
