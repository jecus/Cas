using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Core.Interfaces;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения параметров агрегата
    /// </summary>
    public class DetailParametersControl : UserControl
    {

     /*   #region Fields

        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 180;
        private const int LABEL_REMARK_WIDTH = 300;
        private const int TEXTBOX_WIDTH = 250;
        private const int WIDTH_INTERVAL = 610;

        

        private AbstractDetail currentDetail;
        private bool showHushKit = true;

        #endregion
        
        #region Constructors

        #region public DetailParametersControl()

        /// <summary>
        /// Создает элемент управления для отображения параметров агрегата
        /// </summary>
        public DetailParametersControl()
        {
            #region InitializeComponent();

            checkBoxLLP = new CheckBox();
            checkBoxAvionicsInventory = new CheckBox();
            radioButtonInventoryOptional = new RadioButton();
            radioButtonInventoryRequired = new RadioButton();
            textBoxALTPN = new TextBox();
            textBoxHushKit = new TextBox();
            labelLLPRemark = new Label();
            labelALTPN = new Label();
            labelHushKit = new Label();
            labelAvionicsInventoryRemark = new Label();

            // 
            // checkBoxAvionicsInventory
            // 
            checkBoxAvionicsInventory.Cursor = Cursors.Hand;
            checkBoxAvionicsInventory.FlatStyle = FlatStyle.Flat;
            checkBoxAvionicsInventory.Font = Css.SimpleLink.Fonts.Font;
            checkBoxAvionicsInventory.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxAvionicsInventory.Location = new Point(WIDTH_INTERVAL, MARGIN);
            checkBoxAvionicsInventory.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            checkBoxAvionicsInventory.Text = "Avionics Inventory";
            checkBoxAvionicsInventory.CheckedChanged += checkBoxAvionicsInventoryMark_CheckedChanged;
            // 
            // labelAvionicsInventoryRemark
            // 
            labelAvionicsInventoryRemark.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAvionicsInventoryRemark.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAvionicsInventoryRemark.Location = new Point(checkBoxAvionicsInventory.Right, MARGIN);
            labelAvionicsInventoryRemark.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelAvionicsInventoryRemark.Text = "This Component Is Avionics Inventory";
            labelAvionicsInventoryRemark.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioButtonInventoryOptional
            // 
            radioButtonInventoryOptional.Cursor = Cursors.Hand;
            radioButtonInventoryOptional.Enabled = false;
            radioButtonInventoryOptional.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryOptional.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInventoryOptional.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryOptional.Location = new Point(labelAvionicsInventoryRemark.Left, checkBoxAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            radioButtonInventoryOptional.Size = new Size(TEXTBOX_WIDTH/2, LABEL_HEIGHT);
            radioButtonInventoryOptional.Text = "Optional";
            // 
            // radioButtonInventoryRequired
            // 
            radioButtonInventoryRequired.Cursor = Cursors.Hand;
            radioButtonInventoryRequired.Enabled = false;
            radioButtonInventoryRequired.FlatStyle = FlatStyle.Flat;
            radioButtonInventoryRequired.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInventoryRequired.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonInventoryRequired.Location = new Point(radioButtonInventoryOptional.Right, checkBoxAvionicsInventory.Bottom + HEIGHT_INTERVAL);
            radioButtonInventoryRequired.Size = new Size(TEXTBOX_WIDTH/2, LABEL_HEIGHT);
            radioButtonInventoryRequired.Text = "Required";
            // 
            // labelALTPN
            // 
            labelALTPN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelALTPN.Location = new Point(WIDTH_INTERVAL, radioButtonInventoryOptional.Bottom + HEIGHT_INTERVAL);
            labelALTPN.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelALTPN.Text = "ALT P/N:";
            // 
            // textBoxALTPN
            // 
            textBoxALTPN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxALTPN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxALTPN.Location = new Point(labelALTPN.Right, radioButtonInventoryOptional.Bottom + HEIGHT_INTERVAL);
            textBoxALTPN.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxALTPN.MaxLength = 200;
            // 
            // labelHushKit
            // 
            labelHushKit.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHushKit.Location = new Point(WIDTH_INTERVAL, labelALTPN.Bottom + HEIGHT_INTERVAL);
            labelHushKit.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHushKit.Text = "Hush Kit Equipped:";
            // 
            // textBoxHushKit
            // 
            textBoxHushKit.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxHushKit.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHushKit.Location = new Point(labelHushKit.Right, textBoxALTPN.Bottom + HEIGHT_INTERVAL);
            textBoxHushKit.Name = "textBoxHushKit";
            textBoxHushKit.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxHushKit.MaxLength = 200;
            // 
            // DetailParametersControl
            // 
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;


            
            Controls.Add(checkBoxAvionicsInventory);
            Controls.Add(labelAvionicsInventoryRemark);
            Controls.Add(radioButtonInventoryOptional);
            Controls.Add(radioButtonInventoryRequired);
            Controls.Add(labelALTPN);
            Controls.Add(textBoxALTPN);
            Controls.Add(labelHushKit);
            Controls.Add(textBoxHushKit);
            

            #endregion
        }

        #endregion
        
        #region public DetailParametersControl(AbstractDetail detail) : this()

        /// <summary>
        /// Создает элемент управления для отображения параметров агрегата
        /// </summary>
        /// <param name="detail">Текущий агрегат</param>
        public DetailParametersControl(AbstractDetail detail) : this()
        {
            currentDetail = detail;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public AbstractDetail Currentdetail

        /// <summary>
        /// Возвращает или устанавливает агрегат, с которым работает данный элемент управления
        /// </summary>
        public AbstractDetail Currentdetail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                UpdateInformation();
            }
        }

        #endregion

        

        #region public bool AvionicsInventoryMark

        /// <summary>
        /// Avionics Inventory
        /// </summary>
        public bool AvionicsInventoryMark
        {
            get { return checkBoxAvionicsInventory.Checked; }
            set
            {
                checkBoxAvionicsInventory.Checked = value;
                radioButtonInventoryRequired.Enabled = value;
                radioButtonInventoryOptional.Enabled = value;
            }
        }

        #endregion

        #region public AvionicsInventoryMarkType AvionicsInventoryMarkType

        /// <summary>
        /// Тип Avionics Inventory
        /// </summary>
        public AvionicsInventoryMarkType AvionicsInventoryMarkType
        {
            get
            {
                if (!AvionicsInventoryMark) return AvionicsInventoryMarkType.None;
                if (radioButtonInventoryOptional.Checked) return AvionicsInventoryMarkType.Optional;
                if (radioButtonInventoryRequired.Checked) return AvionicsInventoryMarkType.Required;
                return AvionicsInventoryMarkType.None;
            }
            set
            {
                AvionicsInventoryMark = value != AvionicsInventoryMarkType.None;
                if (value == AvionicsInventoryMarkType.Required) radioButtonInventoryRequired.Checked = true;
                if (value == AvionicsInventoryMarkType.Optional) radioButtonInventoryOptional.Checked = true;
            }
        }

        #endregion

        #region public bool AvionicsInventoryVisible

        /// <summary>
        /// Возвращает или устанавливает свойство Visible для AvionicsInventoryMark
        /// </summary>
        public bool AvionicsInventoryVisible
        {
            get
            {
                return checkBoxAvionicsInventory.Visible;
            }
            set
            {
                checkBoxAvionicsInventory.Visible = value;
                labelAvionicsInventoryRemark.Visible = value;
                radioButtonInventoryOptional.Visible = value;
                radioButtonInventoryRequired.Visible = value;
                
            }
        }

        #endregion

        #region public bool AvionicsInventoryEnabled

        /// <summary>
        /// Возвращает или устанавливает свойство Enabled для AvionicsInventoryMark
        /// </summary>
        public bool AvionicsInventoryEnabled
        {
            get
            {
                return checkBoxAvionicsInventory.Enabled;
            }
            set
            {
                checkBoxAvionicsInventory.Enabled = value;
                if (value && checkBoxAvionicsInventory.Checked)
                {
                    radioButtonInventoryOptional.Enabled = value;
                    radioButtonInventoryRequired.Enabled = value;
                }
            }
        }

        #endregion


        #region public string ALTPN

        /// <summary>
        /// ALT P/N
        /// </summary>
        public string ALTPN
        {
            get
            {
                return textBoxALTPN.Text;
            }
            set
            {
                textBoxALTPN.Text = value;
            }
        }

        #endregion

        #region public string HusKit

        ///<summary>
        /// Hush Kit
        ///</summary>
        public string HusKit
        {
            get
            {
                return textBoxHushKit.Text;
            }
            set
            {
                textBoxHushKit.Text = value;
            }
        }

        #endregion

        #region public bool ShowHushKit

        /// <summary>
        /// Показывать ли поле HushKit
        /// </summary>
        public bool ShowHushKit
        {
            get
            {
                return showHushKit;
            }
            set
            {
                showHushKit = value;
                labelHushKit.Visible = value;
                textBoxHushKit.Visible = value;
            }

        }

        #endregion
        
        #endregion

        #region Methods

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return GetChangeStatus(currentDetail);
        }

        #endregion

        #region public bool GetChangeStatus(AbstractDetail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus(AbstractDetail detail)
        {
            if (detail is Detail)
            {
                Detail det = (Detail)detail;
                return ((LLPMark != det.IncludedIntoLLP) ||
                        (AvionicsInventoryMarkType != det.AvionicsInventoryMark) ||
                        (ALTPN != det.AltPN));
            }
            return false;
        }

        #endregion


        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail != null)
                UpdateInformation(currentDetail);
        }

        #endregion

        #region public void UpdateInformation(AbstractDetail detail)

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        /// <param name="abstractDetail">Агрегат по которому отображается информация</param>
        public void UpdateInformation(AbstractDetail abstractDetail)
        {
            if (abstractDetail == null) throw new ArgumentNullException("abstractDetail");
            bool permission = abstractDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            if (abstractDetail is Detail)
            {
                checkBoxLLP.Visible = true;
                labelLLPRemark.Visible = true;
                AvionicsInventoryVisible = true;
                textBoxALTPN.Visible = true;
                labelALTPN.Visible = true;
                textBoxHushKit.Visible = false;
                labelHushKit.Visible = false;
                checkBoxLLP.Enabled = permission;
                checkBoxAvionicsInventory.Enabled = permission;
                textBoxALTPN.Enabled = permission;
                
                Detail detail = (Detail) abstractDetail;
                LLPMark = detail.IncludedIntoLLP;
                AvionicsInventoryMarkType = detail.AvionicsInventoryMark;
                AvionicsInventoryEnabled = permission;
                ALTPN = detail.AltPN;
            }
            else 
            {
                checkBoxLLP.Visible = false;
                labelLLPRemark.Visible = false;
                AvionicsInventoryVisible = false;
                labelAvionicsInventoryRemark.Visible = false;
                textBoxALTPN.Visible = false;
                labelALTPN.Visible = false;
                if (abstractDetail is Engine)
                {
                    labelHushKit.Location = new Point(MARGIN,MARGIN);
                    textBoxHushKit.Location = new Point(labelHushKit.Right, MARGIN);
                    textBoxHushKit.Visible = true;
                    textBoxHushKit.Enabled = permission;
                    labelHushKit.Visible = true;
                    HusKit = abstractDetail.HushKit_;
                }
                else
                {
                    textBoxHushKit.Visible = false;
                    labelHushKit.Visible = false;
                }
            }
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохраняются данные текущего агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentDetail != null)
                SaveData(currentDetail);
        }

        #endregion

        #region public void SaveData(AbstractDetail destinationDetail)

        /// <summary>
        /// Сохраняются данные заданного агрегата
        /// </summary>
        /// <param name="abstractDetail">Агрегат у которого сохраняются данные</param>
        public void SaveData(AbstractDetail abstractDetail)
        {
            if (abstractDetail == null) throw new ArgumentNullException("abstractDetail");

            if (abstractDetail is Detail)
            {
                Detail detail = (Detail) abstractDetail;

                detail.IncludedIntoLLP = LLPMark;
                detail.AvionicsInventoryMark = AvionicsInventoryMarkType;
                detail.AltPN = ALTPN;
            }
            if (abstractDetail is Engine)
            {
                abstractDetail.HushKit_ = HusKit;
            }
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearAllFields()
        {
            checkBoxLLP.Checked = false;
            checkBoxAvionicsInventory.Checked = false;
            textBoxALTPN.Text = "";
            textBoxHushKit.Text = "";
        }

        #endregion

        #region private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)

        private void checkBoxAvionicsInventoryMark_CheckedChanged(object sender, EventArgs e)
        {
            AvionicsInventoryMark = checkBoxAvionicsInventory.Checked;
            if (!(radioButtonInventoryOptional.Checked) && !(radioButtonInventoryRequired.Checked) && (checkBoxAvionicsInventory.Checked))
                radioButtonInventoryOptional.Checked = true;
        }

        #endregion

        #endregion
*/

    }
}
