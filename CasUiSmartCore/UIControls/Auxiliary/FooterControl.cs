using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using SmartCore.AuditMongo.Repository;
using SmartCore.Management;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс для нижней панели
    /// </summary>
    public partial class FooterControl : UserControl, IApplicationControlRequester
    {
        #region Fields
        /// <summary>
        /// Содержит имя текущего пользователя
        /// </summary>
        private readonly string _userName = "Not connected";

        private readonly Icons _icons = new Icons();

        #endregion

        #region public FooterControl()
        /// <summary>
        /// Создает новый объект нижней панели 
        /// </summary>
        public FooterControl()
        {
            InitializeComponent();
            pictureSeparatorLine.BackgroundImage = _icons.SeparatorLine;
            pictureSeparatorLine.Image = _icons.SeparatorLine;
            pictureSeparatorEnd.BackgroundImage = _icons.SeparatorLine;

            Dock = DockStyle.Bottom;
            try
            {
                var currentUser = GlobalObjects.CasEnvironment.CurrentUser;
                if (currentUser != null)
                {
                    _userName = currentUser.ToString();
                }
                else
                {
                    _userName = "Not connected";
                }
            }
            catch
            {
                //Program.Provider.Logger.Log("Error define user", ex);
            }

            labelUsername.Text = _userName;
        }
        #endregion

        #region public event EventHandler<ApplicationControlRequestArgs> ControlRequest
        /// <summary>
        /// Запрошено дейтсвие управления
        /// </summary>
        public event EventHandler<ApplicationControlRequestArgs> ControlRequest;
        #endregion

        #region private void AvButtonExitClick(object sender, EventArgs e)
        private void AvButtonExitClick(object sender, EventArgs e)
        {
            avButtonExit.ParentForm.Close();
            //if (ControlRequest != null)
            //  ControlRequest(this, new ApplicationControlRequestArgs(ControlType.Exit));
        }
        #endregion

        #region private void AvButtonLogoutClick(object sender, EventArgs e)
        private void AvButtonLogoutClick(object sender, EventArgs e)
        {
            if (ControlRequest != null)
                ControlRequest(this, new ApplicationControlRequestArgs(ControlType.LogOut));

            GlobalObjects.AuditRepository.WriteAsync(new SmartCore.Entities.User(GlobalObjects.CasEnvironment.CurrentUser), AuditOperation.SignOut, GlobalObjects.CasEnvironment.CurrentUser);
		}
        #endregion

        #region private void AvButtonLogoutLocationChanged(object sender, EventArgs e)
        private void AvButtonLogoutLocationChanged(object sender, EventArgs e)
        {
            int freeWidth = avButtonLogout.Left - labelUsername.Left;
            labelUsername.Text = TruncateUserName(freeWidth); 
        }
        #endregion

        #region string TruncateUserName(int freeWidth)
        string TruncateUserName(int freeWidth)
        {
            using (Graphics gfx = CreateGraphics())
            {
                if (gfx.MeasureString(_userName, labelUsername.Font, 1280).Width > freeWidth)
                {
                    for (int length = _userName.Length; length > 0; length--)
                    {
                        string currentVariant = _userName.Substring(0, length) + "…";
                        SizeF stringSize = gfx.MeasureString(currentVariant, labelUsername.Font, 1280);

                        if (stringSize.Width <= freeWidth) return currentVariant;
                    }
                }
                else
                {
                    return _userName;
                }
            }
            return "";
        }
        #endregion

        #region private void splitContainer1_SizeChanged(object sender, EventArgs e)
        /// <summary>
        /// Occurs when size of splitContainer1 been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            panelLogoutButtons.Location = new Point(labelUsername.Right + 10, panelLogoutButtons.Top);
            splitContainer1.SplitterDistance = panelLogoutButtons.Right - 3;
        }

        #endregion

    }
}
