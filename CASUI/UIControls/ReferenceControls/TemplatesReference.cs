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
    /// Элемент управления для отображения краткой информации о шаблонах
    /// </summary>
    public class TemplatesReference : RichReferenceContainer
    {

        #region Fields

        private readonly FlowLayoutPanel mainPanel;
        private readonly Label DescriptionText;
        private readonly ReferenceLinkLabel showAllReference;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения краткой информации о шаблонах
        /// </summary>
        /// <param name="displayerText"></param>
        public TemplatesReference(string displayerText)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Caption = "Templates";
            UpperLeftIcon = new Icons().GrayArrow;
            //
            // lastUpdatedText
            //
            DescriptionText = new Label();
            DescriptionText.Text = "You can view and edit Aircrafts’ Templates";
            DescriptionText.AutoSize = true;
            DescriptionText.Font = new Font("Verdana", 15, GraphicsUnit.Pixel);
            DescriptionText.ForeColor = Color.FromArgb(122, 122, 122);

            //
            // showAllReference
            //
            showAllReference = new ReferenceLinkLabel();
            showAllReference.ActiveLinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.AutoSize = true;
            Css.SimpleLink.Adjust(showAllReference);
            showAllReference.LinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.ReflectionType = ReflectionTypes.DisplayInNew;
            showAllReference.Text = "Show all Templates";
            showAllReference.VisitedLinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.DisplayerText = displayerText;
            showAllReference.ReflectionType = ReflectionTypes.DisplayInNew;
            showAllReference.DisplayerRequested += showAllReference_DisplayerRequested;
            if (!HasPermision(Users.CurrentUser.Role)) showAllReference.Enabled = false;
            //
            // mainPanel
            //
            mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(DescriptionText);
            mainPanel.Controls.Add(showAllReference);
            MainControl = mainPanel;
            
        }

        #endregion

        #region Methods

        #region private void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredTemplateAircraftCollectionScreen();
        }

        #endregion

        #region private bool HasPermision(UserRole role)
        private bool HasPermision(UserRole role)
        {
            if (role == UserRole.Administrator || role == UserRole.Technician) return true;
            return false;
        }
        #endregion

        #endregion

    }
}
