using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using AvControls;
using AvControls.StatusImageLink;
using CAS.UI.Helpers;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    /// <summary>
    /// Ёлемент управлени€ дл€ отображени€ статуса агрегата и ссылок на отчеты
    /// </summary>
    public class BaseComponentHeaderControl : Control
    {

        #region Fields

        private readonly Component _currentComponent;
        private readonly StatusImageLinkLabel statusLinkLabel;
        private readonly CheckBox checkBoxServiceable;
        private readonly BaseComponentLinksFlowLayoutPanel _contentPanel;

        private const int MARGIN = 5;
        private const int HeightInterval = 5;
        private const int LabelHeight = 25;
        private const int LabelWidth = 150;

        #endregion

        #region public Statuses ComponentsStatus
        ///<summary>
        /// ¬озвращает или задает состо€ние компонентов переданного базового агрегата
        ///</summary>
        public Statuses ComponentsStatus
        {
            get { return _contentPanel.LinkComponentStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => _contentPanel.LinkComponentStatus = value), value);
                else _contentPanel.LinkComponentStatus = value;
            }
        }
        #endregion

        #region public Statuses ComponentsLLPStatus
        ///<summary>
        /// ¬озвращает или задает состо€ние вращающихс€ компонентов переданного базового агрегата
        ///</summary>
        public Statuses ComponentsLLPStatus
        {
            get { return _contentPanel.LinkLLPDiscSheetStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => _contentPanel.LinkLLPDiscSheetStatus = value), value);
                else _contentPanel.LinkLLPDiscSheetStatus = value;
            }
        }
        #endregion

        #region  public Statuses ADStatus
        ///<summary>
        /// ¬озвращает или задает состо€ние директив летной годности переданного базового агрегата
        ///</summary>
        public Statuses ADStatus
        {
            get { return _contentPanel.LinkADStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => _contentPanel.LinkADStatus = value), value);
                else _contentPanel.LinkADStatus = value;
            }
        }
        #endregion

        #region public Statuses EOStatus
        ///<summary>
        /// ¬озвращает или задает состо€ние инженерных ордеров переданного базового агрегата
        ///</summary>
        public Statuses EOStatus
        {
            get { return _contentPanel.LinkEOStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => _contentPanel.LinkEOStatus = value), value);
                else _contentPanel.LinkEOStatus = value;
            }
        }
        #endregion

        #region public Statuses SBStatus
        ///<summary>
        /// ¬озвращает или задает состо€ние сервисных бюллетеней переданного базового агрегата
        ///</summary>
        public Statuses SBStatus
        {
            get { return _contentPanel.LinkSBStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => _contentPanel.LinkSBStatus = value), value);
                else _contentPanel.LinkSBStatus = value;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// —оздает элемент управлени€ дл€ отображени€ статуса агрегата и ссылок на отчеты
        /// </summary>
        public BaseComponentHeaderControl(Component component)
        {
            _currentComponent = component;
            statusLinkLabel = new StatusImageLinkLabel();
            checkBoxServiceable = new CheckBox();
            if (component is BaseComponent)
                _contentPanel = new BaseComponentLinksFlowLayoutPanel((BaseComponent)component);
            else 
                _contentPanel = new BaseComponentLinksFlowLayoutPanel(null);
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
            checkBoxServiceable.Location = new Point(MARGIN, statusLinkLabel.Bottom + HeightInterval);
            checkBoxServiceable.Size = new Size(LabelWidth, LabelHeight);
            checkBoxServiceable.Text = "Serviceable";
            //
            // flowLayoutPanelLinks
            //
            _contentPanel.Location = new Point(statusLinkLabel.Right, 0);
            _contentPanel.Size = new Size(500, 100);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            //Controls.Add(statusLinkLabel);
            //Controls.Add(checkBoxServiceable);
            if (component is BaseComponent)
            {
                Size = new Size(1250, 100);
                Controls.Add(_contentPanel);
            }
            else
                Size = new Size(1250, 50);
        }

        #endregion

        #region Methods

        #region public void UpdateInformation()

        /// <summary>
        /// ќбновл€ет информацию об агрегате
        /// </summary>
        public void UpdateInformation()
        {
            /*if (currentDetail is BaseDetail)
                statusLinkLabel.Status = (Statuses)((BaseDetail)currentDetail).c;
            else
                statusLinkLabel.Status = (Statuses)currentDetail.ConditionState;*/
            statusLinkLabel.Text = "Status: " + EnumHelper.EnumToString(statusLinkLabel.Status);
            checkBoxServiceable.Checked = _currentComponent.Serviceable;
            checkBoxServiceable.Enabled = true; //currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);
            if (_currentComponent is BaseComponent)
                _contentPanel.UpdateInformation();
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// —охрана€ет данные текущего агрегата
        /// </summary>
        public void SaveData()
        {
            if (checkBoxServiceable.Checked != _currentComponent.Serviceable)
                _currentComponent.Serviceable = checkBoxServiceable.Checked;
        }

        #endregion

        #endregion

    }
}
