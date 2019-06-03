using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Management;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.WorkHelper;
using CASTerms;

namespace CAS.UI
{
    internal partial class formMain : Form
    {
        #region Fields

        private bool _isActive;
        //private Size currentFormSize;

        #endregion

        #region Constructors

        #region public formMain()
        FindForm find;
        private WorkHelperMainForm codegen;
        public formMain()
        {
            InitializeComponent();
            StaticWaitFormProvider.StatusChaged += StaticWaitFormProvider_StatusChaged;
            loginPage.Entity = dispatcheredUILoginPage1;
            dispatcheredMultitabControl.InactiveBottomColor = Css.CommonAppearance.Colors.BackColor;
            dispatcheredMultitabControl.BackColor = Css.CommonAppearance.Colors.BackColor;
            Text = new GlobalTermsProvider()["SystemName"].ToString(); //+ ". Licensed to " + LicenseManager.LicensedTo + ". Expiry Date " + LicenseManager.ExpiryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            DoubleBuffered = true;
#if DEBUG
            find = new FindForm(this);
            find.Show();
            codegen = new WorkHelperMainForm();
            codegen.Show();
#endif

            /*
                        else
                            Text = (string)new GlobalTermsProvider()["SystemName"].ToString(); //+ ". Licensed is expired on " + LicenseManager.ExpiryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
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
            if (_isActive == false && !StaticWaitFormProvider.IsActive)
            {
               // FlashWindow(Handle, true);
                SystemSounds.Beep.Play();
            }
        }

        #endregion


        #region private void formMain_Deactivate(object sender, EventArgs e)

        private void formMain_Deactivate(object sender, EventArgs e)
        {
            _isActive = false;
            StaticWaitFormProvider.WaitForm.Visible = false;
        }

        #endregion

        #region private void formMain_Activated(object sender, EventArgs e)

        private void formMain_Activated(object sender, EventArgs e)
        {
            _isActive = true;
            if (StaticWaitFormProvider.IsActive) 
                StaticWaitFormProvider.WaitForm.Visible = true;
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