using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controls.AvButton;
using LTR.Core.Management;
using LTR.UI.Interfaces;
using LTR.UI.Management;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls;
using LTR.UI.UIControls.Auxiliary;

namespace LTR.UI.UIControls.DictionaryTypesControls
{
    /// <summary>
    /// Базовый класс для отображения коллекции справочных элементов
    /// </summary>
    [ToolboxItem(true)]
    internal partial class UIDictionaryTypeCollection : UICoreTypeCollection 
    {
        #region Constructors

        public UIDictionaryTypeCollection()
        {
            Width = MIN_CONTROL_WIDTH;
            Height = MIN_CONTROL_HEIGHT;

            titleControl = new UITitleControl("Dictionaries");
            copyrightControl = new UICopyrightControl();
            listViewControl = new ListView();
            buttonAdd = new ReferenceButton();
            buttonReload = new AvButton();
            buttonDelete = new AvButton();
            buttonEdit = new ReferenceButton();
            buttonHelp = new HelpRequestingButton("Some page");//todo
            buttonClose = new ReferenceButton();
            columnHeaderID = new ListViewHeader(COLUMN_ID_TEXT, COLUMN_ID_WIDTH);
            columnHeaderSmallName = new ListViewHeader(COLUMN_SMALL_NAME_TEXT, COLUMN_SMALL_NAME_WIDTH);
            columnHeaderFullName = new ListViewHeader(COLUMN_FULL_NAME_TEXT, COLUMN_FULL_NAME_WIDTH);
            icons = new Icons();

            titleControl.Dock = DockStyle.Top;
            copyrightControl.Dock = DockStyle.Bottom;
            //
            // buttonAdd
            //
            buttonAdd.Location = new Point(Width - buttonAdd.Width - BUTTONS_MARGIN, titleControl.Height + BUTTONS_MARGIN);
            buttonAdd.Image = icons.Add;
            buttonAdd.Text = "Add";
            buttonAdd.DisplayerText = "Add";//todo
            buttonAdd.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAdd.DisplayerRequested += buttonAdd_DisplayerRequested;
            //
            // buttonReload
            //
            buttonReload.Location = new Point(Width - buttonReload.Width - BUTTONS_MARGIN,
                                              titleControl.Height + BUTTONS_MARGIN + BUTTONS_INTERVAL + buttonDelete.Height);
            buttonReload.Image = icons.Reload;
            buttonReload.Text = "Reload";
            buttonReload.Click += buttonReload_Click;
            //
            // buttonDelete
            //
            buttonDelete.Location = new Point(Width - buttonDelete.Width - BUTTONS_MARGIN,
                                              titleControl.Height + BUTTONS_MARGIN + 2 * (BUTTONS_INTERVAL + buttonReload.Height));
            buttonDelete.Enabled = false;
            buttonDelete.Image = icons.Delete;
            buttonDelete.Text = "Delete";
            buttonDelete.Click += buttonDelete_Click;
            //
            // buttonEdit
            //
            buttonEdit.Location = new Point(Width - buttonEdit.Width - BUTTONS_MARGIN,
                                            titleControl.Height + BUTTONS_MARGIN + 3 * (BUTTONS_INTERVAL + buttonEdit.Height));
            buttonEdit.Enabled = false;
            buttonEdit.Image = icons.Edit;
            buttonEdit.Text = "Edit";
            buttonEdit.DisplayerText = "Edit";
            buttonEdit.ReflectionType = ReflectionTypes.DisplayInCurrent;
            buttonEdit.DisplayerRequested += buttonEdit_DisplayerRequested;
            //
            // buttonHelp
            //
            buttonHelp.Location = new Point(Width - buttonHelp.Width - BUTTONS_MARGIN,
                                            titleControl.Height + BUTTONS_MARGIN + 4 * (BUTTONS_INTERVAL + buttonHelp.Height));
            buttonHelp.Image = icons.Help;
            buttonHelp.Text = "Help";
            //
            // buttonClose
            //
            buttonClose.Location = new Point(Width - buttonClose.Width - BUTTONS_MARGIN,
                                             titleControl.Height + BUTTONS_MARGIN + 5 * (BUTTONS_INTERVAL + buttonClose.Height));
            buttonClose.Image = icons.Close;
            buttonClose.Text = "Close";
            buttonClose.ReflectionType = ReflectionTypes.CloseSelected;
            //
            // listViewControl
            //
            listViewControl.Location = new Point(BUTTONS_MARGIN, titleControl.Height + BUTTONS_MARGIN);
            listViewControl.Size = new Size(Width-buttonAdd.Width-3*BUTTONS_MARGIN,Height-titleControl.Height-copyrightControl.Height - 2*BUTTONS_MARGIN);
            listViewControl.View = View.Details;
            listViewControl.SizeChanged += listViewControl_SizeChanged;
            listViewControl.FullRowSelect = true;
            listViewControl.ItemSelectionChanged += listViewControl_ItemSelectionChanged;
            
            listViewHeaders.CollectionChanged += listViewHeaders_CollectionChanged;

            Controls.Add(titleControl);
            Controls.Add(copyrightControl);
            Controls.Add(listViewControl);
            Controls.Add(buttonAdd);
            Controls.Add(buttonReload);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonHelp);
            Controls.Add(buttonClose);

            listViewHeaders.Add(columnHeaderID);
            listViewHeaders.Add(columnHeaderSmallName);
            listViewHeaders.Add(columnHeaderFullName);


            if (!(Users.CurrentUser.Role == UserRole.Administrator))
            {
                buttonDelete.Enabled = true;
                buttonEdit.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
            }

            
        }

        #endregion

        #region Fields

        private int oldWidth = 0;
        private int oldHeight = 0;
        private int oldListViewWidth = 0;
        private const int BUTTONS_MARGIN = 20;
        private const int BUTTONS_INTERVAL = 10;
        private const int MIN_CONTROL_WIDTH = 1000;
        private const int MIN_CONTROL_HEIGHT = 530;
        private const int COLUMN_ID_WIDTH = 50;
        private const int COLUMN_SMALL_NAME_WIDTH = 150;
        private const int COLUMN_FULL_NAME_WIDTH = 300;
        private const string COLUMN_ID_TEXT = "ID";
        private const string COLUMN_SMALL_NAME_TEXT = "Small Name";
        private const string COLUMN_FULL_NAME_TEXT = "Full Name";

        private readonly ListView listViewControl;
        private readonly ListViewHeader columnHeaderID;
        private readonly ListViewHeader columnHeaderSmallName;
        private readonly ListViewHeader columnHeaderFullName;
        private readonly UITitleControl titleControl;
        private readonly UICopyrightControl copyrightControl;
        private readonly ReferenceButton buttonAdd;
        private readonly AvButton buttonReload;
        private readonly AvButton buttonDelete;
        private readonly ReferenceButton buttonEdit;
        private readonly HelpRequestingButton buttonHelp;
        private readonly ReferenceButton buttonClose;
        private readonly Icons icons;
        private readonly ListViewHeaderCollection listViewHeaders = new ListViewHeaderCollection();
        
        #endregion

        #region Properties

        #region protected string TitleText

        /// <summary>
        /// Возвращает текст заголока данного элемента управления
        /// </summary>
        protected string TitleText
        {
            get { return titleControl.TitleText; }
            set { titleControl.TitleText = value; }
        }

        #endregion

        #region protected ListView ListViewControl

        protected ListView ListViewControl
        {
            get { return listViewControl; }            
        }

        #endregion

        #region protected ListViewHeaderCollection ListViewHeaders

        /// <summary>
        /// Возвращает коллекцию заголовков в ListView
        /// </summary>
        protected ListViewHeaderCollection ListViewHeaders
        {
            get
            {
                return listViewHeaders;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region void buttonAdd_DisplayerRequested(object sender, ReferenceEventArgs e)

        void buttonAdd_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIBiWeeklyReportAdd();
        }

        #endregion
        
        #region private void buttonReload_Click(object sender, EventArgs e)

        private void buttonReload_Click(object sender, EventArgs e)
        {
            ReloadInAnotherThread();
        }

        #endregion

        #region private void buttonDelete_Click(object sender, EventArgs e)

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        #endregion

        #region private void buttonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIBiWeeklyReportEdit();
        }

        #endregion


        #region public override List<int> GetIndicesOfSelectedItems()

        public override List<int> GetIndicesOfSelectedItems()
        {
            List<int> indicesList = new List<int>();
            for (int i=0;i<listViewControl.SelectedIndices.Count;i++)
            {
                indicesList.Add(Convert.ToInt32(listViewControl.Items[listViewControl.SelectedIndices[i]]));
            }
            return indicesList;
        }

        #endregion
        
        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, необходимый для корректного отображения данного элемента управления, при изменении его размеров
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((titleControl == null) || (copyrightControl == null))
                return;

            if (Width < MIN_CONTROL_WIDTH)
            {
                Width = MIN_CONTROL_WIDTH;
                oldWidth = Width;
            }
            if (Width != oldWidth)
            {
                buttonAdd.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                buttonReload.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                buttonDelete.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                buttonEdit.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                buttonHelp.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                buttonClose.Left = Width - buttonAdd.Width - BUTTONS_MARGIN;
                listViewControl.Width = Width - buttonAdd.Width - 3*BUTTONS_MARGIN;
                // WaitingControlReload.Left = Width / 2 - WaitingControlReload.Width / 2;
                oldWidth = Width;
            }
            if (Height < MIN_CONTROL_HEIGHT)
            {
                Height = MIN_CONTROL_HEIGHT;
                oldHeight = Height;
            }
            if (Height != oldHeight)
            {
                listViewControl.Height = Height - titleControl.Height - copyrightControl.Height - 2 * BUTTONS_MARGIN;
//                WaitingControlReload.Height = Height / 2 - WaitingControlReload.Height / 2;//todo
                oldHeight = Height;
            }

        }

        #endregion

        #region private void listViewControl_SizeChanged(object sender, EventArgs e)

        private void listViewControl_SizeChanged(object sender, EventArgs e)
        {
            if (listViewControl.Width != oldListViewWidth)
            {
                int tempWidth = 0;
                for (int i = 0; i < listViewHeaders.Count - 1; i++)
                {
                    tempWidth += listViewHeaders[i].Width;
                }
                listViewHeaders[listViewHeaders.Count - 1].Width = listViewControl.Width - tempWidth;
                oldListViewWidth = listViewControl.Width;
            }
        }

        #endregion

        #region private void listViewHeaders_CollectionChanged(ListViewHeaderCollectionChangeAction action, ListViewHeader item)

        private void listViewHeaders_CollectionChanged(ListViewHeaderCollectionChangeAction action, ListViewHeader item)
        {
            if (action == ListViewHeaderCollectionChangeAction.Insert)
            {
                if (listViewHeaders.Count > 1)
                    listViewHeaders[listViewHeaders.Count - 2].Width = listViewHeaders[listViewHeaders.Count - 2].PreferWidth;
                int tempWidth = 0;
                for (int i = 0; i < listViewHeaders.Count-1; i++)
                {
                    tempWidth += listViewHeaders[i].Width;
                }
                item.Width = listViewControl.Width - tempWidth;
                listViewControl.Columns.Add(item);
            }
        }

        #endregion

        #region private void listViewControl_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void listViewControl_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewControl.SelectedItems.Count > 0)
            {
                buttonDelete.Enabled = true;
                if (listViewControl.SelectedItems.Count == 1)
                    buttonEdit.Enabled = true;
                else
                    buttonEdit.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
            }
        }

        #endregion

        #endregion
        
    }
}