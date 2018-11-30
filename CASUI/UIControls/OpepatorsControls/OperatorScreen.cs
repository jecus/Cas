using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Элемент управления для отображения информации заданного эксплуатанта
    /// </summary>
    public class OperatorScreen : UserControl
    {

        #region Fields

        /// <summary>
        /// Текущий эксплуатант
        /// </summary>
        protected Operator currentOperator;
        /// <summary>
        /// Элемент управления, отображающий информацию об эксплуатанте
        /// </summary>
        protected OperatorControl operatorControl;
        private Panel mainPanel;
        private HeaderControl headerControl;
        private OperatorHeaderControl operatorHeaderControl;
        private FooterControl footerControl;
        private RichReferenceButton buttonDeleteOperator;
        protected OperatorScreenView view;
        private readonly Icons icons = new Icons();

        #endregion
        
        #region Constructors

        #region public OperatorScreen()

        /// <summary>
        /// Создает экземпляр элемента управления для добавления новго эксплуатанта
        /// </summary>
        public OperatorScreen()
        {
            currentOperator = new Operator();
            view = OperatorScreenView.Add;
            operatorHeaderControl = new OperatorHeaderControl("New operator", icons.NewOperator);
            operatorControl = new OperatorControl(currentOperator, OperatorScreenView.Add);
            InitializeComponent();
            headerControl.ActionControl.ButtonReload.Enabled = false;
            buttonDeleteOperator.Visible = false;
        }

        #endregion

        #region public OperatorScreen(Operator currentOperator)

        /// <summary>
        /// Создает экземпляр элемента управления для отображения информации заданного эксплуатанта
        /// </summary>
        /// <param name="currentOperator">Текущий эксплуатант</param>
        public OperatorScreen(Operator currentOperator)
        {
            this.currentOperator = currentOperator;
            view = OperatorScreenView.Edit;
            operatorHeaderControl = new OperatorHeaderControl(currentOperator);
            operatorControl = new OperatorControl(currentOperator, OperatorScreenView.Edit);
            InitializeComponent();
            CheckPermission();
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            headerControl = new HeaderControl();
            footerControl = new FooterControl();
            buttonDeleteOperator = new RichReferenceButton();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            //
            // headerControl
            // 
            headerControl.Controls.Add(operatorHeaderControl);
            headerControl.ActionControl.ButtonEdit.TextMain = "Save";
            headerControl.ActionControl.ButtonEdit.Icon = icons.Save;
            headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.EditReflectionType = ReflectionTypes.DisplayInCurrent;
            headerControl.EditDisplayerRequested += headerControl_SaveClicked;
            headerControl.ReloadRised += headerControl_ReloadRised;
            //headerControl.ContextActionControl.ButtonHelp.TopicID = "aircrafts.html";
            // 
            // footerControl
            // 
            footerControl.AutoSize = true;
            footerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl.Dock = DockStyle.Bottom;
            // 
            // buttonDeleteOperator
            // 
            buttonDeleteOperator.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            buttonDeleteOperator.BackColor = Color.Transparent;
            buttonDeleteOperator.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteOperator.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteOperator.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteOperator.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteOperator.Location = new Point(mainPanel.Right - 160, 0);
            buttonDeleteOperator.Icon = icons.Delete;
            buttonDeleteOperator.IconNotEnabled = icons.DeleteGray;
            buttonDeleteOperator.IconLayout = ImageLayout.Center;
            buttonDeleteOperator.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteOperator.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteOperator.Size = new Size(160, 50);
            buttonDeleteOperator.TabIndex = 16;
            buttonDeleteOperator.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteOperator.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteOperator.TextMain = "Delete";
            buttonDeleteOperator.TextSecondary = "operator";
            buttonDeleteOperator.DisplayerRequested += buttonDeleteOperator_DisplayerRequested;
            //
            // OperatorScreen
            //
            mainPanel.Controls.Add(buttonDeleteOperator);
            mainPanel.Controls.Add(operatorControl);
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion

        #region private void CheckPermission()

        private void CheckPermission()
        {
            headerControl.ActionControl.ButtonEdit.Enabled = currentOperator.HasPermission(Users.CurrentUser, DataEvent.Update);
            buttonDeleteOperator.Visible = currentOperator.HasPermission(Users.CurrentUser, DataEvent.Remove);
            operatorControl.CheckPermission();
        }

        #endregion

        #region protected bool Save()

        protected bool Save()
        {
            if (view == OperatorScreenView.Add && operatorControl.OperatorName == "")
            {
                MessageBox.Show("Please fill operator name", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (operatorControl.GetChangeStatus())
            {
                operatorControl.SaveData();

                try
                {
                    if (view == OperatorScreenView.Edit)
                            currentOperator.Save();
                        else
                            OperatorCollection.Instance.Add(currentOperator);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex); 
                    return false;
                }


            }
            return true;
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (operatorControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?", (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    operatorControl.UpdateInformation();
                }
            }
            else
            {
                operatorControl.UpdateInformation();
            }
        }

        #endregion

        #region private void headerControl_SaveClicked(object sender, ReferenceEventArgs e)

        private void headerControl_SaveClicked(object sender, ReferenceEventArgs e)
        {
            if (view == OperatorScreenView.Add)
            {
                if (Save())
                    e.RequestedEntity = new DispatcheredOperatorScreen(currentOperator);
                else
                    e.Cancel = true;
            }
            else
            {
                 Save();
                operatorHeaderControl.Operator = currentOperator;
                 e.Cancel = true;
            }
        }

        #endregion

        #region private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current operator?", "Confirm deleting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    OperatorCollection.Instance.Remove(currentOperator);
                        MessageBox.Show("Operator was deleted successfully", "Operator deleted",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion


        #endregion


    }

    #region public enum OperatorScreenView

    /// <summary>
    /// Вид отображения вкладки эксплуатанта
    /// </summary>
    public enum OperatorScreenView
    {
        /// <summary>
        /// Добавление нового эксплуатанта
        /// </summary>
        Add,
        /// <summary>
        /// Редактирование эксплуатанта
        /// </summary>
        Edit
    }

    #endregion

}
