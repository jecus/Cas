using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using CAS.Core.Management;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;

namespace CAS.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Элемент управления для отображения информации о пользователях
    /// </summary>
    public class UsersReference : RichReferenceContainer
    {

        #region Fields

        private readonly FlowLayoutPanel mainPanel;
        private readonly ReferenceLinkLabel showAllReference;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения краткой информации о пользователях
        /// </summary>
        public UsersReference()
        {
            if (Users.CurrentUser.Role == UserRole.Administrator)
                Caption = "Users";
            else
                Caption = "Current User";
            UpperLeftIcon = new Icons().GrayArrow;

            //
            // showAllReference
            //
            showAllReference = new ReferenceLinkLabel();
            showAllReference.ActiveLinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.AutoSize = true;
            Css.SimpleLink.Adjust(showAllReference);
            showAllReference.LinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.ReflectionType = ReflectionTypes.DisplayInNew;
            if (Users.CurrentUser.Role == UserRole.Administrator)
                showAllReference.Text = "Show all Users";
            else
                showAllReference.Text = "Show current User details";
            showAllReference.VisitedLinkColor = Color.FromArgb(62, 155, 246);
            if (Users.CurrentUser.Role == UserRole.Administrator)
                showAllReference.DisplayerText = "Users";
            else
                showAllReference.DisplayerText = "User deatils";
            showAllReference.ReflectionType = ReflectionTypes.DisplayInNew;
            showAllReference.DisplayerRequested += showAllReference_DisplayerRequested;
            //
            // mainPanel
            //
            mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(showAllReference);
            MainControl = mainPanel;
            
        }

        #endregion

        #region Methods

        #region private void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            //e.RequestedEntity = new DispatcheredTemplateAircraftCollectionScreen();
        }

        #endregion

     

        #endregion


    }
}
