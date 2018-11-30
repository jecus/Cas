using System;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для добавления нового шаблонного ВС в коллекцию шаблонов
    /// </summary>
    public partial class TemplateAddAircraftForm : Form
    {

        #region Fields

        private AircraftType aircraftType = AircraftType.West;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает форму для добавления нового шаблонного ВС в коллекцию шаблонов
        /// </summary>
        public TemplateAddAircraftForm()
        {
            InitializeComponent();
            Css.HeaderText.Adjust(labelHeader);
            Css.OrdinaryText.Adjust(textBoxModel);
            Css.OrdinaryText.Adjust(radioButtonSovietAircraft);
            Css.OrdinaryText.Adjust(radioButtonWestAircraft);
            Css.OrdinaryText.Adjust(buttonOK);
            Css.OrdinaryText.Adjust(buttonCancel);
            Css.OrdinaryText.Adjust(labelModel);
            radioButtonSovietAircraft.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            radioButtonWestAircraft.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonOK.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonCancel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelModel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

        }

        #endregion
        
        #region Properties

        #region public AircraftType AircraftType

        /// <summary>
        /// Возвращает или устанавливает тип ВС
        /// </summary>
        public AircraftType AircraftType
        {
            get { return aircraftType; }
            set { aircraftType = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxModel.Text == "")
            {
                SimpleBalloon.Show(textBoxModel, ToolTipIcon.Warning, "Value expected", "Please enter aircraft model");
                return;
            }
            DialogResult = DialogResult.OK;
            TemplateAircraft aircraft = new TemplateAircraft();
            aircraft.Model = textBoxModel.Text;
            aircraft.Type = AircraftType;
            try
            {
                TemplateAircraftCollection.Instance.Add(aircraft);
                aircraft.AddAircraftFrame("",MaintenanceTypeCollection.Instance.UnknownType,"","","");
            }
            catch(Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); 
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        #endregion

        #region private void radioButtonSovietAircraft_CheckedChanged(object sender, EventArgs e)

        private void radioButtonSovietAircraft_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSovietAircraft.Checked)
                AircraftType = AircraftType.Soviet;
            else
                AircraftType = AircraftType.West;
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