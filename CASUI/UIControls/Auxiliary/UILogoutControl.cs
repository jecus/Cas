using System;
using System.Windows.Forms;
using LTR.Core.Management;
using LTR.UI.Management.Dispatchering;

namespace LTR.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления, необходимый для выхода из системы
    /// </summary>
    public partial class UILogoutControl : UserControl, IApplicationControlRequester
    {
        #region Constructor

        /// <summary>
        /// Создает элемент управления для выхода из системы
        /// </summary>
        public UILogoutControl()
        {
            InitializeComponent();
            if (Users.CurrentUser != null)
            {
                labelUsername.Text = Users.CurrentUser.FullName;
            }
            else
            {
                labelUsername.Text = "Not connected";
            }

        }
        #endregion

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            Width = labelUsername.Width + labelUsername.Left + labelUsername.Margin.Left + avButtonLogout.Width + avButtonExit.Width + pictureSeparatorEnd.Width;
            avButtonLogout.Left = labelUsername.Width + labelUsername.Left + labelUsername.Margin.Left;
            pictureSeparatorLine.Left = labelUsername.Width + labelUsername.Left + labelUsername.Margin.Left + avButtonLogout.Width;
            avButtonExit.Left = labelUsername.Width + labelUsername.Left + labelUsername.Margin.Left + avButtonLogout.Width;
            pictureSeparatorEnd.Left = this.Width - pictureSeparatorEnd.Width;
        }

        private void avButtonExit_Click(object sender, System.EventArgs e)
        {
            if (ControlRequest != null)
                ControlRequest(this, new ApplicationControlRequestArgs(ControlType.Exit));
        }

        private void avButtonLogout_Click(object sender, System.EventArgs e)
        {
            if (ControlRequest != null)
                ControlRequest(this, new ApplicationControlRequestArgs(ControlType.LogOut));
        }

        /// <summary>
        /// Запрошено дейтсвие управления
        /// </summary>
        public event EventHandler<ApplicationControlRequestArgs> ControlRequest;
    }
}
