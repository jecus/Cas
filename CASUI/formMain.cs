using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;

namespace CAS.UI
{
    internal partial class formMain : Form
    {
        #region Fields

        private bool isActive;
        //private Size currentFormSize;

        #endregion
        
        #region Constructors

        #region public formMain()

        public formMain()
        {
            InitializeComponent();
            StaticWaitFormProvider.StatusChaged += StaticWaitFormProvider_StatusChaged;
            loginPage.Entity = dispatcheredUILoginPage1;
            dispatcheredMultitabControl.InactiveBottomColor = Css.CommonAppearance.Colors.BackColor;
            dispatcheredMultitabControl.BackColor = Css.CommonAppearance.Colors.BackColor;
            Text = new TermsProvider()["SystemName"].ToString(); //+ ". Licensed to " + LicenseManager.LicensedTo + ". Expiry Date " + LicenseManager.ExpiryDate.ToString(new TermsProvider()["DateFormat"].ToString());
/*
            else
                Text = (string)new TermsProvider()["SystemName"].ToString(); //+ ". Licensed is expired on " + LicenseManager.ExpiryDate.ToString(new TermsProvider()["DateFormat"].ToString());
*/


            Icon = Resources.LTR;
            LicenseDispatcher.Form = this;
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void OnLoad(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Form.Load"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LicenseDispatcher.CheckLicenseInformation();
            //currentFormSize = Size;
        }

        #endregion

        #region void StaticWaitFormProvider_StatusChaged(object sender, EventArgs e)

        void StaticWaitFormProvider_StatusChaged(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
            {
                Activate();
            }
            if (isActive == false && !StaticWaitFormProvider.IsActive)
            {
                FlashWindow(Handle, true);
                SystemSounds.Beep.Play();
            }
        }

        #endregion


        #region private void formMain_Deactivate(object sender, EventArgs e)

        private void formMain_Deactivate(object sender, EventArgs e)
        {
            isActive = false;
            StaticWaitFormProvider.WaitForm.Visible = false;
        }

        #endregion

        #region private void formMain_Activated(object sender, EventArgs e)

        private void formMain_Activated(object sender, EventArgs e)
        {
            isActive = true;
            if (StaticWaitFormProvider.IsActive) StaticWaitFormProvider.WaitForm.Visible = true;
        }

        #endregion

        #region public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        #endregion

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void formMain_SizeChanged(object sender, EventArgs e)
        {
            //if (Width != currentFormSize.Width || Height != currentFormSize.Height)
                //Size = currentFormSize;
        }
        
    }
}