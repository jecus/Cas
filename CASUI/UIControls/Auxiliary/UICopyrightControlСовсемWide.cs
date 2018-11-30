using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LTR.Core.ProjectTerms;

namespace LTR.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления, необходимый для отображения информации о защите 
    /// авторских прав компании на screen и login формах
    /// </summary>
    public partial class UICopyrightControlСовсемWide : UserControl
    {

        #region Constructor
        /// <summary>
        /// Создает элемент управления для отображения информации о защите 
        /// авторских прав компании на screen и login формах
        /// </summary>
        public UICopyrightControlСовсемWide()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = BackColor;
            UpdateInnerControlsColors(ForeColor);
        }

        #endregion

        #region Properties

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                UpdateInnerControlsColors(value);
                base.ForeColor = value;
            }
        }

        #endregion

        #region Methods

        #region private void UpdateInnerControlsColors(Color value)

        private void UpdateInnerControlsColors(Color value)
        {
            labelVersionInfo.ForeColor = value;
            labelCopyrights.ForeColor = value;
            linkLabelSupport.ForeColor = value;
            linkLabelSupport.ActiveLinkColor = value;
            linkLabelSupport.VisitedLinkColor = value;
            linkLabelSupport.LinkColor = value;
        }

        #endregion

        #region private void linkLabelSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = (string)new StaticProjectTermsProvider()["ProductWebsite"];
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        #endregion

        #endregion

    }
}
