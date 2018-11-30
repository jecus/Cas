using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CASTerms;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления, необходимый для отображения информации о защите 
    /// авторских прав компании на screen и login формах
    /// </summary>
    public partial class CopyrightControl : UserControl
    {

        #region Constructor
        /// <summary>
        /// Создает элемент управления для отображения информации о защите 
        /// авторских прав компании на screen и login формах
        /// </summary>
        public CopyrightControl()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = BackColor;
            UpdateInnerControlsColors(ForeColor);
        }

        #endregion

        #region Properties

        #region public override Color ForeColor

        ///<summary>
        ///Gets or sets the foreground color of the control.
        ///</summary>
        ///
        ///<returns>
        ///The foreground <see cref="T:System.Drawing.Color"></see> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor"></see> property.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
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
            process.StartInfo.FileName = (string)new GlobalTermsProvider()["ProductWebsite"];
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        #endregion

        #endregion

    }
}
