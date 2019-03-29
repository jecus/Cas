using System;
using System.Windows.Forms;

namespace CAS.UI.Messages
{
    public partial class MessageForm : Form
    {
        private bool isRetryButtonPushed = false;

        public MessageForm()
        {
            InitializeComponent();
        }

        public string MessageText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public bool IsRetryButtonPushed
        {
            get
            {
                return isRetryButtonPushed;
            }
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            isRetryButtonPushed = true;
            Close();
        }
    }
}