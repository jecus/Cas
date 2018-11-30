using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Controls.AvButton;
using LTR.Core;
using LTR.Core.Management;
using LTR.UI.Appearance;
using LTR.UI.DispatcheredUIControls;
using LTR.UI.Interfaces;
using System.Windows.Forms;
using LTR.UI.Management;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls.Comparers;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using LTR.UI.UIControls;

namespace LTR.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Отображает список эксплуатантов
    /// </summary>
    [ToolboxItem(true)]
    internal partial class UIOperatorCollection : UILoggableTypeCollection
    {

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображеия списка эксплуатантов
        /// </summary>
        public UIOperatorCollection()
        {
            titleControl = new UITitleControl("Operators");
            copyrightControl = new UICopyrightControl();
            buttonMenu = new ReferenceButton();
            buttonReload = new AvButton();
            buttonAddOperator = new ReferenceButton();
            buttonViewLog = new ReferenceButton();
            buttonHelp = new HelpRequestingButton("Some page");//todo
            buttonClose = new ReferenceButton();
            displayerControl = new UIDisplayerControl((buttonMenu.Width + BUTTONS_MARGIN*2)*2,
                                                      buttonMenu.Height*6 + BUTTONS_INTERVAL*5 + 2 * BUTTONS_MARGIN);
            icons = new Icons();
            buttons = new List<ReferenceOperatorListItem>();

            Width = displayerControl.Width;
            Height = titleControl.Height + displayerControl.Height + copyrightControl.Height;
            titleControl.Dock = DockStyle.Top;
            copyrightControl.Dock = DockStyle.Bottom;
            displayerControl.DisplayerPanel.Padding = new Padding(BUTTONS_MARGIN - BUTTONS_INTERVAL);
            //
            // displayerControl
            //
            displayerControl.Top = titleControl.Height;
            displayerControl.Left = Left;
            displayerControl.Height = Height - titleControl.Height - copyrightControl.Height;
            displayerControl.Width = Width;
            //
            // buttonMenu
            //
            buttonMenu.Location = new Point(Width - buttonMenu.Width - BUTTONS_MARGIN, BUTTONS_MARGIN);
            buttonMenu.Image = icons.Menu;
            buttonMenu.Text = "Menu";
            buttonMenu.DisplayerText = "StartPage";//todo
            buttonMenu.DisplayerRequested += buttonMenu_DisplayerRequested;
            buttonMenu.ReflectionType = ReflectionTypes.DisplayInNew;
            //
            // buttonReload
            //
            buttonReload.Location = new Point(Width - buttonReload.Width - BUTTONS_MARGIN,
                                              BUTTONS_MARGIN + BUTTONS_INTERVAL + buttonReload.Height);
            buttonReload.Image = icons.Reload;
            buttonReload.Text = "Reload";
            buttonReload.Click += buttonReload_Click;
            //
            // buttonAddOperator
            //
            buttonAddOperator.Location = new Point(Width - buttonAddOperator.Width - BUTTONS_MARGIN,
                                                   BUTTONS_MARGIN + 2 * (BUTTONS_INTERVAL + buttonAddOperator.Height));
            buttonAddOperator.Image = icons.Add;
            buttonAddOperator.Text = "Add Operator";
            buttonAddOperator.DisplayerText = "Add Operator";
            buttonAddOperator.DisplayerRequested += buttonAddOperator_DisplayerRequested;
            buttonAddOperator.ReflectionType = ReflectionTypes.DisplayInNew;
            //
            // buttonViewLog
            //
            buttonViewLog.Location = new Point(Width - buttonViewLog.Width - BUTTONS_MARGIN,
                                               BUTTONS_MARGIN + 3 * (BUTTONS_INTERVAL + buttonViewLog.Height));
            buttonViewLog.Image = icons.ViewLog;
            buttonViewLog.Text = "View Log";
            buttonViewLog.DisplayerText = "View Log";
            buttonViewLog.DisplayerRequested += buttonViewLog_DisplayerRequested;
            buttonViewLog.ReflectionType = ReflectionTypes.DisplayInNew;
            //
            // buttonHelp
            //
            buttonHelp.Location = new Point(Width - buttonHelp.Width - BUTTONS_MARGIN,
                                            BUTTONS_MARGIN + 4 * (BUTTONS_INTERVAL + buttonHelp.Height));
            buttonHelp.Image = icons.Help;
            buttonHelp.Text = "Help";
            //
            // buttonClose
            //
            buttonClose.Location = new Point(Width - buttonClose.Width - BUTTONS_MARGIN,
                                             BUTTONS_MARGIN + 5 * (BUTTONS_INTERVAL + buttonClose.Height));
            buttonClose.Image = icons.Close;
            buttonClose.Text = "Close";
            buttonClose.ReflectionType = ReflectionTypes.CloseSelected;
            
            Initialize();

            Controls.Add(titleControl);
            Controls.Add(copyrightControl);
            Controls.Add(displayerControl);
            
            displayerControl.Controls.Add(buttonMenu);
            displayerControl.Controls.Add(buttonReload);
            displayerControl.Controls.Add(buttonAddOperator);
            displayerControl.Controls.Add(buttonViewLog);
            displayerControl.Controls.Add(buttonHelp);
            displayerControl.Controls.Add(buttonClose);
            
            //WaitingControlReload.Start();
            //WaitingControlReload.Left = Width / 2 - WaitingControlReload.Width / 2;
            //WaitingControlReload.Height = Height / 2 - WaitingControlReload.Height / 2;
            //WaitingControlReload.Visible = false;//todo
            
            if (!(Users.CurrentUser.Role == UserRole.Administrator) && !(Users.CurrentUser.Role == UserRole.Technician))
            {
                buttonAddOperator.Enabled = false;
            }

            //MessageBox.Show("Ы-ы-ы!");
            
        }

        #endregion

        #region Fields
        
        private int oldWidth = 0;
        private int oldHeight = 0;
        private const int BUTTONS_MARGIN = 20;
        private const int BUTTONS_INTERVAL = 10;
        private readonly UITitleControl titleControl;
        private readonly UICopyrightControl copyrightControl;
        private readonly UIDisplayerControl displayerControl;
        private readonly ReferenceButton buttonMenu;
        private readonly AvButton buttonReload;
        private readonly ReferenceButton buttonAddOperator;
        private readonly ReferenceButton buttonViewLog;
        private readonly HelpRequestingButton buttonHelp;
        private readonly ReferenceButton buttonClose;
        //private readonly List<ReferenceButton> buttons;
        private readonly List<ReferenceOperatorListItem> buttons;
        private readonly Icons icons;
        

        #endregion

        #region Properties

        #region private ControlCollection OperatorsControls

        /// <summary>
        /// Возвращает коллекцию элементов управления, куда следует добавлять кнопки для отображения эксплуатантов
        /// </summary>
        private ControlCollection OperatorsControls
        {
            get
            {
                return displayerControl.DisplayerPanel.Controls;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region protected override void Initialize()

        /// <summary>
        /// Производит инициализацию элемента управления для дальнейшей работы с пользователем
        /// </summary>
        protected override void Initialize()
        {
            Collection = OperatorCollection.Instance;
            Collection.Changed += Collection_Changed;
            
            FillUIElementsFromCollection();
            if (!Collection.HasPermission(Users.CurrentUser, DataEvent.Update))
                MakeUIElementsReadonly();
        }

        #endregion
        
        #region public override void FillUIElementsFromCollection()

        /// <summary>
        /// Осуществляет заполнение пользовательских элементов управления на основе данных бизнес коллекции
        /// </summary>
        public override void FillUIElementsFromCollection()
        {
            if (!(Collection is OperatorCollection)) return;
            
            OperatorCollection operatorCollection = Collection as OperatorCollection;

            if (operatorCollection == null) return;

            buttons.Clear();
            OperatorsControls.Clear();

            for (int i = 0; i < operatorCollection.Count; i++)
            {
                //ReferenceButton tempButton = new ReferenceButton();
                ReferenceOperatorListItem tempButton = new ReferenceOperatorListItem();
                tempButton.Text = operatorCollection[i].Name;
                tempButton.Icon = operatorCollection[i].LogoType;
                tempButton.SecondText = operatorCollection[i].Address;
                //tempButton.Margin = new Padding(BUTTONS_INTERVAL);
                tempButton.Margin = new Padding(0);
                Css.AvalonButtonMStyle.Adjust(tempButton);
                buttons.Add(tempButton);
                buttons[i].DisplayerText = operatorCollection[i].Name;
                buttons[i].Tag = operatorCollection[i].ID;
                //buttons[i].Entity = new SampleStartPage();
                buttons[i].DisplayerRequested += UIOperators_DisplayerRequested;
                buttons[i].ReflectionType = ReflectionTypes.DisplayInNew;
            }
            buttons.Sort(new OperatorListItemComparer());
            
            OperatorsControls.AddRange(buttons.ToArray());
        }

        private void UIOperators_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (!(sender is ReferenceOperatorListItem)) return;
            ReferenceOperatorListItem tempButton = sender as ReferenceOperatorListItem;
            e.RequestedEntity = new DispatcheredOperatorScreen(Collection.GetByID((int)tempButton.Tag) as Operator);
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, необходимый для корректного отображения данного элемента управления, при изменении его размеров
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((titleControl == null) || (displayerControl == null) || (copyrightControl == null)) //todo почему кнопки без этого пашут??
                return;

            if (Width < (buttonMenu.Width + BUTTONS_MARGIN * 2) * 2)
            {
                Width = (buttonMenu.Width + BUTTONS_MARGIN * 2) * 2;
                oldWidth = Width;
            }
            if (Width != oldWidth)
            {
                displayerControl.Width = Width;

                buttonMenu.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                buttonReload.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                buttonAddOperator.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                buttonViewLog.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                buttonHelp.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                buttonClose.Left = Width - buttonMenu.Width - BUTTONS_MARGIN;
                
                WaitingControlReload.Left = Width / 2 - WaitingControlReload.Width / 2;
                oldWidth = Width;
            }
            if (Height < buttonMenu.Height * 6 + BUTTONS_INTERVAL * 5 + 2 * BUTTONS_MARGIN + titleControl.Height + copyrightControl.Height)
            {
                Height = buttonMenu.Height * 6 + BUTTONS_INTERVAL * 5 + 2 * BUTTONS_MARGIN + titleControl.Height + copyrightControl.Height;
                oldHeight = Height;
            }
            if (Height != oldHeight)
            {
                displayerControl.Height = Height - titleControl.Height - copyrightControl.Height;
                WaitingControlReload.Height = Height / 2 - WaitingControlReload.Height / 2;
                oldHeight = Height;
            }
            
        }

        #endregion

        #region private void buttonReload_Click(object sender, EventArgs e)

        private void buttonReload_Click(object sender, EventArgs e)
        {
            ReloadInAnotherThread(); 
        }

        #endregion

        #region private void buttonViewLog_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonViewLog_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIViewLog();
        }

        #endregion

        #region private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIOperatorAdd();
        }

        #endregion

        #region private void buttonMenu_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonMenu_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIStartPage();//todo убрать если не надо
        }

        #endregion
        
        #region private void Collection_Changed(object sender, EventArgs e)

        private void Collection_Changed(object sender, EventArgs e)
        {
            ReloadInAnotherThread(); 
        }

        #endregion

        #endregion
                
    }
}