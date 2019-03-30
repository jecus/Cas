/*
using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Описывается ссылка на отчеты BiWeekly
    ///</summary>
    public class BiWeeklyReportsReference : RichReferenceContainer
    {
        private readonly FlowLayoutPanel mainPanel;
        private readonly Label lastUpdatedText;
        private readonly ReferenceLinkLabel showAllReference;

        ///<summary>
        ///</summary>
        public BiWeeklyReportsReference()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            UpperLeftIcon = new Icons().GrayArrow;
            Caption = "BiWeekly Reports";
            //
            // lastUpdatedText
            //
            lastUpdatedText = new Label();
            lastUpdatedText.Text = LastUpdatedText;
            lastUpdatedText.AutoSize = true;
            lastUpdatedText.Font = new Font("Verdana", 15, GraphicsUnit.Pixel);
            lastUpdatedText.ForeColor = Color.FromArgb(122, 122, 122);
            //
            // showAllReference
            //
            showAllReference = new ReferenceLinkLabel();
            showAllReference.ActiveLinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.AutoSize = true;
            showAllReference.DisplayerText = "BiWeekly Reports";
            Css.SimpleLink.Adjust(showAllReference);
            showAllReference.ReflectionType = ReflectionTypes.DisplayInNew;
            showAllReference.Text = "Show all BiWeeklies";
            showAllReference.VisitedLinkColor = Color.FromArgb(62, 155, 246);
            showAllReference.DisplayerRequested += showAllReference_DisplayerRequested;
            //if (!HasPermision(Users.IdentityUser.Role)) showAllReference.Enabled = false;
            //
            // mainPanel
            //
            mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(lastUpdatedText);
            mainPanel.Controls.Add(showAllReference);
            MainControl = mainPanel;

            
  
        }

        #region Properties

        #region public ReferenceLinkLabel ShowAllReference

        ///<summary>
        /// Ссылка отображения всех отчетов
        ///</summary>
        public ReferenceLinkLabel ShowAllReference
        {
            get
            {
                return showAllReference;
            }
        }

        #endregion

        #region public string LastUpdatedText

        ///<summary>
        /// Дата следующего обновления
        ///</summary>
        public string LastUpdatedText
        {
            get
            {
                //return "Last updated " + BiWeekliesCollection.Instance.LastUpdate.ToString(new TermsProvider()["DateFormat"].ToString());
                return "";
            }
        }

        #endregion
        
        #endregion
        
        #region Methods

        #region private static void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void showAllReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredBiWeekliesCollectionScreen();
        }

        #endregion
        
        #endregion

    }
}
*/
