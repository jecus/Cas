using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using Controls;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения статуса агрегата и ссылок на отчеты
    /// </summary>
    public class BaseDetailHeaderControl : Control
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly StatusImageLinkLabel statusLinkLabel;
        private readonly CheckBox checkBoxServiceable;
        private readonly BaseDetailLinksFlowLayoutPanel flowLayoutPanelLinks;
        private readonly RichReferenceButton buttonDeleteDetail;

        private readonly Icons icons = new Icons();

        private const int MARGIN = 5;
        private const int HEIGHT_INTERVAL = 5;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 150;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения статуса агрегата и ссылок на отчеты
        /// </summary>
        public BaseDetailHeaderControl(AbstractDetail detail)
        {
            currentDetail = detail;
            statusLinkLabel = new StatusImageLinkLabel();
            checkBoxServiceable = new CheckBox();
            if (detail is BaseDetail)
                flowLayoutPanelLinks = new BaseDetailLinksFlowLayoutPanel((BaseDetail)detail);
            else 
                flowLayoutPanelLinks = new BaseDetailLinksFlowLayoutPanel(null);
            buttonDeleteDetail = new RichReferenceButton();
            // 
            // statusLinkLabel
            // 
            statusLinkLabel.ActiveLinkColor = Color.Black;
            statusLinkLabel.Enabled = false;
            statusLinkLabel.HoveredLinkColor = Color.Black;
            statusLinkLabel.ImageBackColor = Color.Transparent;
            statusLinkLabel.ImageLayout = ImageLayout.Center;
            statusLinkLabel.LinkColor = Color.DimGray;
            statusLinkLabel.LinkMouseCapturedColor = Color.Empty;
            statusLinkLabel.Size = new Size(350, 27);
            statusLinkLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLinkLabel.TextFont = Css.OrdinaryText.Fonts.RegularFont;
            // 
            // checkBoxServiceable
            // 
            checkBoxServiceable.Cursor = Cursors.Hand;
            checkBoxServiceable.FlatStyle = FlatStyle.Flat;
            checkBoxServiceable.Font = Css.SimpleLink.Fonts.Font;
            checkBoxServiceable.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxServiceable.Location = new Point(MARGIN, statusLinkLabel.Bottom + HEIGHT_INTERVAL);
            checkBoxServiceable.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxServiceable.Text = "Serviceable";
            //
            // flowLayoutPanelLinks
            //
            flowLayoutPanelLinks.Location = new Point(statusLinkLabel.Right, 0);
            flowLayoutPanelLinks.Size = new Size(500, 100);
            // 
            // buttonDeleteDetail
            // 
            buttonDeleteDetail.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            buttonDeleteDetail.BackColor = Color.Transparent;
            buttonDeleteDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDetail.Icon = icons.Delete;
            buttonDeleteDetail.IconNotEnabled = icons.DeleteGray;
            buttonDeleteDetail.IconLayout = ImageLayout.Center;
            buttonDeleteDetail.Name = "buttonDeleteDetail";
            buttonDeleteDetail.NormalBackgroundImage = null;
            buttonDeleteDetail.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteDetail.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteDetail.Size = new Size(160, 50);
            buttonDeleteDetail.TabIndex = 16;
            buttonDeleteDetail.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteDetail.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteDetail.TextMain = "Delete";
            buttonDeleteDetail.TextSecondary = "component";
            buttonDeleteDetail.DisplayerRequested += buttonDeleteDetail_DisplayerRequested;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(statusLinkLabel);
            Controls.Add(checkBoxServiceable);
            if (detail is BaseDetail)
            {
                Size = new Size(1250, 100);
                Controls.Add(flowLayoutPanelLinks);
            }
            else
                Size = new Size(1250, 50);
           if(!(detail is AircraftFrame)) Controls.Add(buttonDeleteDetail);
        }

        #endregion

        #region Methods

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return checkBoxServiceable.Checked != currentDetail.Serviceable;
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию об агрегате
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail is BaseDetail)
                statusLinkLabel.Status = (Statuses)((BaseDetail)currentDetail).ConditionState;
            else
                statusLinkLabel.Status = (Statuses)currentDetail.ConditionState;
            statusLinkLabel.Text = "Status: " + UsefulMethods.EnumToString(statusLinkLabel.Status);
            checkBoxServiceable.Checked = currentDetail.Serviceable;
            buttonDeleteDetail.Enabled = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Remove);
            checkBoxServiceable.Enabled = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);
            if (currentDetail is BaseDetail)
                flowLayoutPanelLinks.UpdateInformation();
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего агрегата
        /// </summary>
        public void SaveData()
        {
            if (checkBoxServiceable.Checked != currentDetail.Serviceable)
                currentDetail.Serviceable = checkBoxServiceable.Checked;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            checkBoxServiceable.Checked = false;
        }

        #endregion

        #region private void buttonDeleteDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Удаляет текущий агрегат
        /// </summary>
        private void buttonDeleteDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current component?",
                    "Confirm deleting " + currentDetail.SerialNumber, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {

                if (currentDetail is BaseDetail)
                {
                    Aircraft aircraft = (Aircraft) currentDetail.Parent;
                    aircraft.RemoveBaseDetail((BaseDetail) currentDetail);
                }
                else
                {
                    IDetailContainer detailContainer = (IDetailContainer) currentDetail.Parent;
                    detailContainer.Remove(currentDetail);
                }

                MessageBox.Show("Component was deleted successfully", (string)new TermsProvider()["SystemName"],
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    e.Cancel = true;
                }

            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            buttonDeleteDetail.Location = new Point(Width - buttonDeleteDetail.Width, 0);
        }

        #endregion

        #endregion

    }
}
