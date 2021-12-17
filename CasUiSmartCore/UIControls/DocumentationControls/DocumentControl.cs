using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.DocumentationControls
{
	public partial class DocumentControl : UserControl
	{
		#region Fields

		private Document _currentDocument;

		#endregion

		#region Properties

		public Document CurrentDocument
		{
			get { return _currentDocument; }
			set
			{
				_currentDocument = value;
				UpdateDocument();
			}
		}

		#endregion

		#region Constructor

		public DocumentControl()
		{
			InitializeComponent();
		}

		#endregion

		#region private void UpdateDocument()

		private void UpdateDocument()
		{
			if (_currentDocument == null)
			{
				linkLabelAddDocument.Visible = true;
				linkLabelEditDocument.Visible = false;
				linkLabelRemoveDocument.Visible = false;
				labelDocument.Visible = false;
			}
			else
			{
				linkLabelAddDocument.Visible = false;
				linkLabelEditDocument.Visible = true;
				linkLabelRemoveDocument.Visible = true;
				labelDocument.Visible = true;
				labelDocument.Text = _currentDocument.ToString();
			}
		}

		#endregion

		#region private void linkLabelAddDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Added != null)
				Added(this, EventArgs.Empty);
		}

		#endregion

		#region private void linkLabelEditDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelEditDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new DocumentForm(_currentDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
				UpdateDocument();
		}

		#endregion

		#region private void linkLabelRemoveDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelRemoveDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var confirmResult =
				MessageBox.Show(
					_currentDocument != null
						? "Do you really want to delete Document " + _currentDocument.Description + "?"
						: "Do you really want to delete selected Documents? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				try
				{
					GlobalObjects.NewKeeper.Delete(_currentDocument);
					_currentDocument = null;
					UpdateDocument();
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}
			}
		}

		#endregion

		#region Event

		public event EventHandler Added;

		#endregion
	}
}
