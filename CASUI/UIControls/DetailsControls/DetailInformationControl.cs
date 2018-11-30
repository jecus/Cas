using System;
using System.Drawing;

using System.Windows.Forms;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.Directives;

namespace LTR.UI.UIControls.DetailsControls
{

    #region public enum DetailInformationMode

    ///<summary>
    /// Определяет вид формы отображения агрегатов
    ///</summary>
    public enum DetailInformationMode
    {
        ///<summary>
        /// Вид простого отображения
        ///</summary>
        View, 
        ///<summary>
        /// Вид редактирования и добавления
        ///</summary>
        Edit
    }

    #endregion
    
    ///<summary>
    /// Отображает информацию об агрегате
    ///</summary>
    public partial class DetailInformationControl : UserControl
    {

        #region Fields

        private Detail currentDetail;
        private DetailInformationMode mode = DetailInformationMode.View;
        private int fontSize;
        private Font defaultFont;

        #endregion
        
        #region Constructors

        #region public DetailInformationControl()
        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        public DetailInformationControl()
        {
            fontSize = 15;
            defaultFont = new Font("Verdana", fontSize, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            InitializeComponent();
        }

        #endregion

        #region public DetailInformationControl(Detail currentDetail)

        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        /// <param name="currentDetail"></param>
        public DetailInformationControl(Detail currentDetail) : this()
        {
            if (null == currentDetail) throw new ArgumentNullException("currentDetail", "Argument cannot be null");
            if (!(currentDetail.GetType() == typeof(Detail))) throw new ArgumentException("Argument must be explicitly of type Detail", "currentDetail");
            this.currentDetail = currentDetail;
            UpdateDataForDetail();
            UpdateMode();
        }

        #endregion

        #endregion

        #region  Propeties

        #region public DetailInformationMode Mode
        /// <summary>
        /// Задает вид формы отображаемого агрегата
        /// </summary>
        public DetailInformationMode Mode
        {
            get { return mode; }
            set 
            {
                mode = value; 
                UpdateMode();
            }

        }
        #endregion

        #region public Detail CurrentDetail
        /// <summary>
        /// Задает или возвращает отображаемый агрегат
        /// </summary>
        public Detail CurrentDetail
        {
            get { return currentDetail; }
            set
            {
                currentDetail = value;
                if (null != value) UpdateDataForDetail();
            }
        }
        #endregion

        #endregion
        
        #region Methods

        #region private void UpdateMode()
        /// <summary>
        /// Обновление вида формы
        /// </summary>
        private void UpdateMode()
        {
            if (mode == DetailInformationMode.Edit)
            {
                panel1Edit.Visible = true;
                panel2Edit.Visible = true;

                panel1View.Visible = false;
                panel2View.Visible = false;

                UpdateDataForEditDetail();
            }
            else 
                if(mode == DetailInformationMode.View)
                {
                    panel1Edit.Visible = false;
                    panel2Edit.Visible = false;

                    panel1View.Visible = true;
                    panel2View.Visible = true;
                    UpdateDataForDetail();
                }
            
            
        }

        #endregion

        #region private void UpdateDataForEditDetail()
        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        private void UpdateDataForEditDetail()
        {
            textBoxPartNo.Text = currentDetail.PartNumber;
            textBoxSerialNo.Text = currentDetail.SerialNumber;
            if (currentDetail.AtaChapter != null) comboBoxAtaChapter.Text = currentDetail.AtaChapter.FullName;
            textBoxDescription.Text = currentDetail.Description;
            //panelMaintFreqValue               // todo

            textBoxPosition.Text = currentDetail.PositionNumber;
            textBoxModel.Text = currentDetail.Model;
            textBoxManufacturer.Text = currentDetail.Manufacturer;
            //dateTimePickerManufactureDate = currentDetail.ManufactureDate; // todo
            textBoxRemarks.Text = currentDetail.Remarks;
        }
        #endregion


        #region private void UpdateDataForDetail()
        /// <summary>
        /// Получение значений формы
        /// </summary>
        private void UpdateDataForDetail()
        {
            labelPartNoValue.Text = currentDetail.PartNumber;
            labelSerialNoValue.Text = currentDetail.SerialNumber;
            if (currentDetail.AtaChapter != null) labelAtaChapterValue.Text = currentDetail.AtaChapter.FullName;
            labelDescriptionValue.Text = currentDetail.Description;
            labelMaintFreqValue.Text = currentDetail.MaintananceType.FullName;

            labelPositionValue.Text = currentDetail.PositionNumber;
            labelModelValue.Text = currentDetail.Model;
            labelManufacturerValue.Text = currentDetail.Manufacturer;
            labelManufactureDateValue.Text = currentDetail.ManufactureDate.ToLongDateString();
            labelRemarksValue.Text = currentDetail.Remarks;
            
        }
        #endregion

        #region private void AddDataForDetail()
        /// <summary>
        /// Добавляет новую деталь
        /// </summary>
        private void AddDataForDetail()                     // todo
        {
            currentDetail.PartNumber = textBoxPartNo.Text;
            currentDetail.SerialNumber = textBoxSerialNo.Text;
            currentDetail.AtaChapter.FullName = comboBoxAtaChapter.Text;
            currentDetail.Description = textBoxDescription.Text;
            //currentDetail.MaintananceType = panelMaintFreq.

            currentDetail.PositionNumber = textBoxPosition.Text;
            currentDetail.Model = textBoxModel.Text;
            currentDetail.Manufacturer = textBoxManufacturer.Text;
            //currentDetail.ManufactureDate = dateTimePickerManufactureDate; // todo
            currentDetail.Remarks = textBoxRemarks.Text;
        }
        #endregion

        #endregion
        
    }
}