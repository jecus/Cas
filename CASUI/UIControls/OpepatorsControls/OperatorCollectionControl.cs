using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.UI.Management;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.ReferenceControls;
using CASTerms;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Отображает список эксплуатантов
    /// </summary>
    public partial class OperatorCollectionControl : UserControl, IReference
    {

        #region Fields

        private readonly OperatorCollection operatorCollection;
        private readonly FlowLayoutPanel flowLayoutPanelOperators;
        private readonly Icons icons = new Icons();
        private readonly ObjectsListStatistics operatorsListStatistics;
        private List<ReferenceOperatorListItem> referenceOperatorListItems;

        #region IReference Members

        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
        
        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображеия списка эксплуатантов
        /// </summary>
        public OperatorCollectionControl()
        {
            operatorCollection = OperatorCollection.Instance;
            operatorCollection.Changed += operatorCollection_Changed;
            operatorsListStatistics = new ObjectsListStatistics();
            flowLayoutPanelOperators = new FlowLayoutPanel();
            // 
            // operatorsListStatistics
            // 
            operatorsListStatistics.Amount = 0;
            operatorsListStatistics.ObjectsAmountText = "Operator";
            operatorsListStatistics.AutoSize = true;
            operatorsListStatistics.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            operatorsListStatistics.Caption = "Operators";
            operatorsListStatistics.DescriptionTextColor = Color.DimGray;
            operatorsListStatistics.Location = new Point(0, 60);
            operatorsListStatistics.Name = "operatorsListStatistics";
            operatorsListStatistics.Size = new Size(145, 70);
            operatorsListStatistics.UpperLeftIcon = icons.GrayArrow;
            // 
            // flowLayoutPanelOperators
            // 
            flowLayoutPanelOperators.AutoSize = true;
            flowLayoutPanelOperators.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelOperators.Location = new Point(0, 136);
            flowLayoutPanelOperators.MinimumSize = new Size(100, 100);
            DisplayerRequested += OperatorCollectionControl_DisplayerRequested;
            // 
            // OperatorCollectionControl
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            Controls.Add(flowLayoutPanelOperators);
            Controls.Add(operatorsListStatistics);
            Size = new Size(494, 259);
            UpdateOperators(false);
        }


        #endregion

        #region Properties

        #region IReference Members

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public DisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #endregion

        #endregion

        #region Methods

        #region public void UpdateOperators()

        /// <summary>
        /// Обновляет список эксплуатантов
        /// </summary>
        public void UpdateOperators()
        {
            UpdateOperators(true);
        }

        #endregion

        #region public void UpdateOperators(bool reloadCollection)

        /// <summary>
        /// Обновляет список эксплуатантов
        /// </summary>
        /// <param name="reloadCollection">Синхронизировать ли с базой данных</param>
        public void UpdateOperators(bool reloadCollection)
        {
            if (reloadCollection)
            {
                try
                {
                    operatorCollection.Reload();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while loading data", ex);
                    return;
                }
            }
            int count = operatorCollection.Count;
            flowLayoutPanelOperators.Controls.Clear();

            referenceOperatorListItems = new List<ReferenceOperatorListItem>();
            for (int i = 0; i < count; i++)
            {
                ReferenceOperatorListItem tempButton = new ReferenceOperatorListItem();
                tempButton.Text = operatorCollection[i].Name;
                tempButton.Icon = operatorCollection[i].LogoType;
                tempButton.SecondText = GetAircraftsCountText(operatorCollection[i]);
                tempButton.Margin = new Padding(0);
                tempButton.Visible = true;
                tempButton.CurrentOperator = operatorCollection[i];
                tempButton.ReflectionType = ReflectionTypes.DisplayInNew;
                tempButton.TruncatingNeeded = true;
                tempButton.DisplayerRequested += tempButton_DisplayerRequested;
                Css.AvalonButtonMStyle.Adjust(tempButton);
                Font font = new Font(tempButton.Font, FontStyle.Bold);
                tempButton.Font = new Font(font.FontFamily, font.Size - 0.5f, FontStyle.Bold, font.Unit);
                referenceOperatorListItems.Add(tempButton);
            }
            referenceOperatorListItems.Sort(new OperatorListItemComparer());
            flowLayoutPanelOperators.Controls.AddRange(referenceOperatorListItems.ToArray());
            operatorsListStatistics.Amount = count;
        }

        #endregion

        #region private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (sender is ReferenceOperatorListItem)
            {
                Operator currentOperator = (sender as ReferenceOperatorListItem).CurrentOperator;
                e.DisplayerText = currentOperator.Name;
                e.RequestedEntity = new DispatcheredAircraftCollectionScreen(currentOperator);
            }
        }

        #endregion

        #region void OperatorCollectionControl_DisplayerRequested(object sender, ReferenceEventArgs e)

        void OperatorCollectionControl_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (OperatorCollection.Instance.Count != 1)
                e.Cancel = true;
            else
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = OperatorCollection.Instance[0].Name;
                e.RequestedEntity = new DispatcheredAircraftCollectionScreen(OperatorCollection.Instance[0]);
            }
        }

        #endregion



        #region private string GetAircraftsCountText(Operator currentOperator)

        private string GetAircraftsCountText(Operator currentOperator)
        {
            int count = currentOperator.Aircrafts.Count;
            return count + " Aircraft" + (count == 1 ? "" : "s");
        }

        #endregion

        #region public void SetWidthLimitation(int width, int height)

        /// <summary>
        /// Задается ограничение ширины
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetWidthLimitation(int width, int height)
        {
            MaximumSize = new Size(width, height);
            flowLayoutPanelOperators.MaximumSize = new Size(width, height - operatorsListStatistics.Height);
        }

        #endregion

        #region private void operatorCollection_Changed(object sender, EventArgs e)

        private void operatorCollection_Changed(object sender, EventArgs e)
        {
            UpdateOperators(false);
        }

        #endregion

        #region public void SetEnabaledToOperatorButtons(bool isEnabled)
        /// <summary>
        /// Изменяет свойство Enabled у кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetEnabaledToOperatorButtons(bool isEnabled)
        {
            for (int i = 0; i < referenceOperatorListItems.Count; i++)
            {
                referenceOperatorListItems[i].Enabled = isEnabled;
            }
        }

        #endregion

        #region public void OpenAircraftsScreen()

        /// <summary>
        /// Открывает вкладку со списком ВС
        /// </summary>
        public void OpenAircraftsScreen()
        {
            OnDisplayerRequested();
        }

        #endregion

        #region protected void OnDisplayerRequested() 

        /// <summary>
        /// Метод обработки события DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }

        #endregion

        #endregion

        #region Events
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }
}