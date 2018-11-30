using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    public partial class TemplateDetailsAddToDataBase : Form
    {
        #region Fields
        private List<Operator> listOperators;
        private List<Aircraft> listAircrafts;
        private List<BaseDetail> listBaseDetails;
        private Operator selectedOperator;
        private Aircraft selectedAircraft;
        private BaseDetail selectedBaseDetail;
        #endregion

        #region Constructors

        #region public TemplateDetailsAddToDataBase()
        public TemplateDetailsAddToDataBase()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region Properties

        #region public BaseDetail SelectedBaseDetail
        /// <summary>
        /// Выбранный базовый агрегат 
        /// </summary>
        public BaseDetail SelectedBaseDetail
        {
            get { return selectedBaseDetail; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void TemplateDetailsAddToDataBase_Load(object sender, EventArgs e)
        private void TemplateDetailsAddToDataBase_Load(object sender, EventArgs e)
        {
            listOperators = new List<Operator>();
            listAircrafts = new List<Aircraft>();
            listBaseDetails = new List<BaseDetail>();

            Css.OrdinaryText.Adjust(label1);
            Css.OrdinaryText.Adjust(label2);
            Css.OrdinaryText.Adjust(label3);
            Css.OrdinaryText.Adjust(comboBoxOperators);
            Css.OrdinaryText.Adjust(comboBoxAircrafts);
            Css.OrdinaryText.Adjust(comboBoxBaseDetails);
            Css.OrdinaryText.Adjust(buttonAdd);
            Css.OrdinaryText.Adjust(buttonCancel);
            Css.HeaderText.Adjust(label4);

            label1.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            label2.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            label3.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            label4.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            comboBoxOperators.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            comboBoxAircrafts.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            comboBoxBaseDetails.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonCancel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonAdd.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonAdd.Click += buttonAdd_Click;
            buttonCancel.Click += buttonCancel_Click;

            for (int  i = 0; i < OperatorCollection.Instance.Count; i++)
            {
                listOperators.Add(OperatorCollection.Instance[i]);
            }
            comboBoxOperators.Items.AddRange(listOperators.ToArray());
            comboBoxOperators.SelectedIndexChanged += comboBoxOperators_SelectedIndexChanged;
            comboBoxAircrafts.SelectedIndexChanged += comboBoxAircrafts_SelectedIndexChanged;
            comboBoxBaseDetails.SelectedIndexChanged += comboBoxBaseDetails_SelectedIndexChanged;
            
            


        }


        #endregion

        #region void buttonAdd_Click(object sender, EventArgs e)
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (selectedBaseDetail == null)
            {
                MessageBox.Show("You mast select base component");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region void buttonCancel_Click(object sender, EventArgs e)
        void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion


        #region void comboBoxBaseDetails_SelectedIndexChanged(object sender, EventArgs e)
        void comboBoxBaseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBaseDetail = (BaseDetail)comboBoxBaseDetails.SelectedItem;
        }
        #endregion

        #region void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)
        void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaseDetails.Items.Clear();
            listBaseDetails.Clear();
            selectedAircraft = (Aircraft)comboBoxAircrafts.SelectedItem;

            listBaseDetails.AddRange(selectedAircraft.BaseDetails);

            comboBoxBaseDetails.Items.AddRange(listBaseDetails.ToArray());

        }
        #endregion

        #region void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)
        void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAircrafts.Items.Clear();
            listAircrafts.Clear();
            selectedOperator = (Operator) comboBoxOperators.SelectedItem;
            listAircrafts.AddRange(selectedOperator.AircraftCollection);
            comboBoxAircrafts.Items.AddRange(listAircrafts.ToArray());

        }
        #endregion

        #endregion
    }
}