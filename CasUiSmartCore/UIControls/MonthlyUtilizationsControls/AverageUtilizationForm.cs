using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    ///<summary>
    /// форма для задания средней утилизации по всем основным агрегатам самолета
    ///</summary>
    public partial class AverageUtilizationForm : Form
    {
        private readonly Aircraft _currentAircraft;
        private List<AverageUtilizationItemControl> _averageControlItems = new List<AverageUtilizationItemControl>();
        #region Constructors

        #region public AverageUtilizationForm()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public AverageUtilizationForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public AverageUtilizationForm(Aircraft aircraft) : this()
        ///<summary>
        /// Конструктор, создающий форму для указанного самолета
        ///</summary>
        public AverageUtilizationForm(Aircraft aircraft) : this()
        {
            if(aircraft == null)return;
            _currentAircraft = aircraft;
            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            var aircraftBaseDetails =
                new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId));

            flowLayoutPanelMain.Controls.Clear();
            _averageControlItems.Clear();

            List<IGrouping<int,BaseComponent>> groupedBaseDetails =
                aircraftBaseDetails.GroupBy(bd => bd.BaseComponentType.ItemId).ToList();

            //Планер и шасси имеют одно значение срелней утилизации
            bool frameAndLG = false;
            foreach (IGrouping<int, BaseComponent> baseDetailGroup in groupedBaseDetails)
            {
                if(baseDetailGroup.Key == BaseComponentType.Frame.ItemId || 
                   baseDetailGroup.Key == BaseComponentType.LandingGear.ItemId)
                {
                    if(!frameAndLG)
                    {
                        BaseComponent frame =
                        baseDetailGroup.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.Frame.ItemId).FirstOrDefault();
                    
                        if(frame != null)
                        {    
                            frameAndLG = true;

                            //Создание отдельной панели для новой группы
                            FlowLayoutPanel baseGroupPanel = new FlowLayoutPanel
                                                                       {
                                                                           AutoScroll = true,
                                                                           AutoSize = true,
                                                                           AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                                                           FlowDirection = FlowDirection.LeftToRight,
                                                                           MaximumSize = new Size(300, 500),
                                                                           MinimumSize = new Size(300, 120),
                                                                       };
                            flowLayoutPanelMain.Controls.Add(baseGroupPanel);
                        
                            //добавление нового ЭУ в новую панель группы
                            AverageUtilizationItemControl item = new AverageUtilizationItemControl(frame)
                                                                     {DetailNameText = "Frame and LG"};
                            baseGroupPanel.Controls.Add(item);
                            _averageControlItems.Add(item);
                        }
                    }

                    continue;
                }

                //Создание отдельной панели для новой группы
                FlowLayoutPanel baseDetailGroupPanel = new FlowLayoutPanel
                {
                    AutoScroll = true,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    FlowDirection = FlowDirection.LeftToRight,
                    MaximumSize = new Size(300, 500),
                    MinimumSize = new Size(300, 120),
                };
                flowLayoutPanelMain.Controls.Add(baseDetailGroupPanel);
                foreach (BaseComponent baseDetail in baseDetailGroup)
                {
                    //добавление нового ЭУ в новую панель группы
                    AverageUtilizationItemControl item = new AverageUtilizationItemControl(baseDetail);

                    if (baseDetail.BaseComponentType == BaseComponentType.Apu)
	                    item.Enabled = false;

					baseDetailGroupPanel.Controls.Add(item);
                    _averageControlItems.Add(item);
                } 
            }
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            foreach (AverageUtilizationItemControl control in _averageControlItems)
            {
                if(control.CurrentBaseComponent.BaseComponentType.ItemId == BaseComponentType.Frame.ItemId)
                {
                    var aircraftLG =  new List<BaseComponent>(
                        GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, BaseComponentType.LandingGear.ItemId));
                    foreach (var lg in aircraftLG)
                    {
                        var au = control.GetAverageUtilization();
                        if(au == null) return false;

                        lg.AverageUtilization = au;
                        try
                        {
                            GlobalObjects.ComponentCore.Save(lg);
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error while loading data", ex);
                            return false;
                        }
                    }
                }
                if (!control.SaveData()) return false;
            }
            return true;
        }

        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
        }

        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion
    }
}
