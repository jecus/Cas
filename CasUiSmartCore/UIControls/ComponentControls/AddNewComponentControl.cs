using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// Контрол для определения базовой детали для чего либо
    ///</summary>
    [Designer(typeof(AddNewComponentDesigner))]
    public partial class AddNewComponentControl : UserControl
    {
        #region Fields

        private BaseComponent _parent;
        private RadioButton[] _radioButtonBaseDetail;
        
        #endregion

        #region public AddNewComponentControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public AddNewComponentControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region public BaseDetail BaseDetailAddTo

        /// <summary>
        /// Свойство возвращающее базовый агрегат, в который нужно добавить новый компонент
        /// </summary>
        public BaseComponent BaseComponentAddTo
        {
            get
            {
                foreach (RadioButton t in _radioButtonBaseDetail)
                {
                    if (t.Checked) return t.Tag as BaseComponent;
                }
                return _radioButtonBaseDetail[0].Tag as BaseComponent;
            }
            set
            {
                if (_radioButtonBaseDetail == null) return;
                foreach (RadioButton t in _radioButtonBaseDetail)
                {
                    if (!t.Tag.Equals(value)) continue;
                    t.Checked = true;
                    return;
                }
            }
        }

        #endregion

        #region public BaseDetail CurrentParent
        ///<summary>
        /// Задает тек базовую деталь и родителя базовых деталей
        ///</summary>
        public BaseComponent CurrentParent
        {
            set { _parent = value; UpdateInformation(); }
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            flowLayoutPanel1.Controls.Clear();
			//TODO:(Evgenii Babak) эта проверка должна быть в BL
			if (_parent != null && (_parent.ParentAircraftId > 0 || _parent.ParentStoreId > 0))
            {
                var baseDetails = _parent.ParentAircraftId > 0
					   //TODO:(Evgenii Babak) перенести BaseDetail в отдельный кор
					   ? GlobalObjects.ComponentCore.GetAicraftBaseComponents(_parent.ParentAircraftId)
					   : GlobalObjects.ComponentCore.GetStoreBaseComponents(_parent.ParentStoreId);

				_radioButtonBaseDetail = new RadioButton[baseDetails.Length];
                int length = baseDetails.Length;
                for (int i = 0; i < length; i++)
                {
                    var current = baseDetails[i];
                    _radioButtonBaseDetail[i] = new RadioButton();
                    _radioButtonBaseDetail[i].AutoSize = true;
                    _radioButtonBaseDetail[i].Cursor = Cursors.Hand;
                    _radioButtonBaseDetail[i].FlatStyle = FlatStyle.Flat;
                    _radioButtonBaseDetail[i].Font =
                        new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
                    _radioButtonBaseDetail[i].ForeColor = Css.SimpleLink.Colors.LinkColor;
                    _radioButtonBaseDetail[i].Location = new Point(labelBaseComponent.Location.X + labelBaseComponent.Width + 25, i * 25);
                    _radioButtonBaseDetail[i].Size = new Size(73, 22);
                    _radioButtonBaseDetail[i].TabIndex = i;
                    _radioButtonBaseDetail[i].TabStop = true;
                    _radioButtonBaseDetail[i].Tag = baseDetails[i];
                    _radioButtonBaseDetail[i].Text = current.BaseComponentType.FullName +
                                                    " " +
                                                    current.SerialNumber;
                    _radioButtonBaseDetail[i].UseVisualStyleBackColor = true;
                    _radioButtonBaseDetail[i].CheckedChanged += CheckedChangedByAnyCheckBox;
                    if (_parent.ItemId == current.ItemId) _radioButtonBaseDetail[i].Checked = true;
                    flowLayoutPanel1.Controls.Add(_radioButtonBaseDetail[i]);
                }
            }
        }
        #endregion

        #region private void CheckedChangedByAnyCheckBox(object sender, EventArgs e)

        private void CheckedChangedByAnyCheckBox(object sender, EventArgs e)
        {
            if (sender is RadioButton)
                if (((RadioButton)sender).Checked) OnCheckedChanged(((RadioButton)sender).Tag ,new EventArgs());
        }

        #endregion

        #region protected void OnCheckedChanged(EventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие изменения базового агрегата
        /// </summary>
        /// <param name="e"></param>
        private void OnCheckedChanged(object parent ,EventArgs e)
        {
            if (null != CheckedChanged) CheckedChanged.Invoke(parent, e);
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие изменения базового агрегата
        /// </summary>
        public event EventHandler CheckedChanged;

        #endregion
    }
}
