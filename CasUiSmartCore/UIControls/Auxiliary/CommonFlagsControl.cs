using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonFlagsControl : EditObjectControl
    {
        private List<CheckBox> _checkBoxes = new List<CheckBox>();

        #region public Object AttachedObject
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        private Type _sourceEnum;
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        public Type SourceEnum
        {
            get { return _sourceEnum; }
            set
            {
                if (_sourceEnum != value)
                {
                    //ObjectChanging();
                    _sourceEnum = value;
                    //ObjectChanged();
                    CreateControls();
                }
            }
        }
        #endregion
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonFlagsControl()
        {
            InitializeComponent();
        }

        #region private void CreateControls()
        /// <summary>
        /// Функция создания контролов
        /// </summary>
        private void CreateControls()
        {
            _checkBoxes.Clear();

            if (_sourceEnum == null)return;

            Array items = Enum.GetValues(_sourceEnum);
            
            foreach (object item in items)
            {
                CheckBox cb = new CheckBox
                {
                    Text = item.ToString(),
                    MinimumSize = new Size(20, 17),
                    //AutoSize = true,
                };
                _checkBoxes.Add(cb);   
            }

            for(int i = 0; i<_checkBoxes.Count; i++)
            {
                _checkBoxes[i].Location = i == 0 
                    ? new Point(3, 3) 
                    : new Point(_checkBoxes[i - 1].Right + 5, 3);
            }
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            //comboBoxEngine.Items.Clear();
            //if (Condition.ItemId <= 0)
            //{
            //    aircraftBaseDetails =
            //        GlobalObjects.CasEnvironment.GetBaseDetails(_currentAircraft).
            //            Where(d => d.DetailTypeId == DetailType.Engine.ItemId).ToList();
            //    //новая запись по уровню масла
            //    //тогда в список добавляются все двигатели и ВСУ
            //    if (aircraftBaseDetails.Count > 0)
            //    {
            //        comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
            //        comboBoxEngine.SelectedIndex = 0;
            //    }
            //}
            //else if (Condition.Engine != null)
            //{
            //    if (_currentAircraft != null && _currentAircraft.ItemId == Condition.Engine.ParentAircraft.ItemId)
            //    {
            //        //Деталь для которой создавалась запись находится на этом самолете;
            //        if (aircraftBaseDetails.Count > 0)
            //            comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
            //    }
            //    else comboBoxEngine.Items.Add(Condition.Engine);
            //    comboBoxEngine.SelectedItem = Condition.Engine;
            //}
            //else
            //{
            //    //Базовый компонент для которого сделана запись не найден
            //    comboBoxEngine.Items.Add("Error: Can't Find component");
            //}

            //numericUpDownERP.Value = (decimal)Condition.ERP;
            //numericUpDownN1.Value = (decimal)Condition.N1;
            //numericUpDownEGT.Value = (decimal)Condition.EGT;
            //numericUpDownN2.Value = (decimal)Condition.N2;
            //numericUpDownOilTemp.Value = (decimal)Condition.OilTemperature;
            //numericUpDownOilPress.Value = (decimal)Condition.OilPressure;
            //numericUpDownFuelFlow.Value = (decimal)Condition.FuelFlow;
            //numericUpDownFuelBurn.Value = (decimal)Condition.FuelBurn;

            EndUpdate();
        }
        #endregion
    }
}
