using System.Windows.Forms;

namespace CAS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormSF : Form
    {

        #region Fields

        private bool isActive;

        #endregion
        /// <summary>
        /// 
        /// </summary>
        public FormSF()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBox1.Text = "Hello World";
        }
    }
}