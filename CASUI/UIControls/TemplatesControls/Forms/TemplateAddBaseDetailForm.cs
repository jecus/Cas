using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для добавления базового агрегата в шаблонное ВС
    /// </summary>
    public partial class TemplateAddBaseDetailForm : Form
    {

        #region Fields

        private readonly TemplateAircraft currentAircraft;
        private DetailTypesIds detailType = DetailTypesIds.Engine; 

        #endregion

        #region Constructor

        /// <summary>
        /// Создает форму для добавления базового агрегата в шаблонное ВС
        /// </summary>
        public TemplateAddBaseDetailForm(TemplateAircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
            InitializeComponent();
            Initialize();
        }

        #endregion
        
        #region Properties

        #region public DetailTypesIds DetailType

        /// <summary>
        /// Возвращает или устанавливает тип базового агрегата
        /// </summary>
        public DetailTypesIds DetailType
        {
            get { return detailType; }
            set { detailType = value; }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void Initialize()
        private void Initialize()
        {
            Css.HeaderText.Adjust(labelTitle);
            Css.OrdinaryText.Adjust(radioButtonAPU);
            Css.OrdinaryText.Adjust(radioButtonEngine);
            Css.OrdinaryText.Adjust(buttonOK);
            Css.OrdinaryText.Adjust(buttonCancel);

            radioButtonAPU.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            radioButtonEngine.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonOK.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonCancel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
        }
        #endregion


        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            try
            {
                switch (DetailType)
                    {
                        case DetailTypesIds.Engine:
                            currentAircraft.AddEngine("", 
                                                      MaintenanceTypeCollection.Instance.UnknownType, "", "", "");
                            break;
                        case DetailTypesIds.APU:
                            currentAircraft.AddAPU("", 
                                                   MaintenanceTypeCollection.Instance.UnknownType, "", "", "");
                            break;
                    }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        #endregion

        #region private void radioButtonEngine_CheckedChanged(object sender, EventArgs e)

        private void radioButtonEngine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEngine.Checked)
                DetailType = DetailTypesIds.Engine;
        }

        #endregion

        #region private void radioButtonAPU_CheckedChanged(object sender, EventArgs e)

        private void radioButtonAPU_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAPU.Checked)
                DetailType = DetailTypesIds.APU;
        }

        #endregion
        
        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #endregion

    }
}