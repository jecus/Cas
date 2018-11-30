using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using CAS.Core.Management;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;

namespace CAS.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Элемент управления для отображения краткой информации об эксплуатантов
    /// </summary>
    public class OperatorsReference : RichReferenceContainer
    {

        #region Fields

        private readonly FlowLayoutPanel mainPanel;
        private readonly Label DescriptionText;
        private readonly ReferenceLinkLabel showAllReference;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения краткой информации об эксплуатантов
        /// </summary>
        /// <param name="displayerText"></param>
        public OperatorsReference(string displayerText)
        {
            Caption = "Operators";
            UpperLeftIcon = new Icons().GrayArrow;
            //
            // lastUpdatedText
            //
            DescriptionText = new Label();
            DescriptionText.Text = "You can view and edit Operators";
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
            //if (OperatorCollection.Instance.Count == 1)
                //showAllReference.Text = "Go back to " + OperatorCollection.Instance[0].Name;
            showAllReference.Text = "Go back to operators";
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
            e.RequestedEntity = new DispatcheredOperatorCollectionScreen();
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
