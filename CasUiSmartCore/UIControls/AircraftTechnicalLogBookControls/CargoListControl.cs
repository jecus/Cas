using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// ������� ��������� ������ ���������� �� ������� ������
    /// </summary>
    public partial class CargoListControl : Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// �����, � ������� ������ �������
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * �����������
         */

        #region public CargoListControl()
        /// <summary>
        /// ������ �����������
        /// </summary>
        public CargoListControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * ������������� ������
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// ��������� � ������� ��������� ��������� �� ��������. 
        /// ���� �� ��� ������ ������������� ������� ����� (�������� ��� ����� �����), �������� ������� �� ����������, ������������ false
        /// ����� base.ApplyChanges() ����������
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (Flight != null)
            {
                Flight.FlightCargoRecords.Clear();
                List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

                foreach (CargoRecordControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Flight.FlightCargoRecords.Add(fc.FlightCargoRecord);
                }
            }
            //
            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// ��������� �������� �����
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            BuildControls();
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// ��������� ��������� ������.
        /// ���� �����-���� ���� �� �������� �� �������, ������� ����� ������ MessageBox, ������� ������ � ����������� ���� � ���������� false � �������� ���������� ������
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            // � ���� �������� ������ ��������� ������
            List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

            foreach (CargoRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not set cargo category", "Error");
                return false;
            }

            foreach (CargoRecordControl fc in fcs)
            {
                if (fcs.Where(f => f.CargoCategory.ItemId ==
                                   fc.CargoCategory.ItemId).Count() > 1)
                {
                    MessageBox.Show(fc, "Can't have one cargo category more that once", "Error");
                    return false;
                }
            }
            return true;
            //
        }
        #endregion

        /*
         * ����������
         */

        #region private void BuildControls()
        /// <summary>
        /// ������ ������ ��������
        /// </summary>
        private void BuildControls()
        {
            // ����������� ������ ��������
            flowLayoutPanelMain.Controls.Clear();

            if (Flight != null && Flight.FlightCargoRecords != null)
            {
                for (int i = 0; i < Flight.FlightCargoRecords.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    CargoRecordControl c = new CargoRecordControl(Flight.FlightCargoRecords[i]);
                    c.Deleted += ConditionControlDeleted;
                    c.WeightChanged += ControlWeightChanged;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
           
            GetTotal();
        }
        #endregion

        #region private void GetTotal()
        private void GetTotal()
        {
            List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

            double t = fcs.Sum(cr => Measure.Convert(cr.Weigth, cr.Measure, Measure.Kilograms));

            textWeightTotal.Text = t.ToString("F") + " " + Measure.Kilograms; 
   
            InvokeCargoWeightChanget(t);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CargoRecordControl performance =
                new CargoRecordControl(new FlightCargoRecord { FlightId = Flight.ItemId });
            performance.Deleted += ConditionControlDeleted;
            performance.WeightChanged += ControlWeightChanged;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            CargoRecordControl control = (CargoRecordControl)sender;
            FlightCargoRecord cond = control.FlightCargoRecord;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete flight cargo record?", 
                                                   "Deleting confirmation", MessageBoxButtons.YesNoCancel, 
                                                   MessageBoxIcon.Exclamation, 
                                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //���� ���������� � ��������� ��������� � �� 
                //� ������� ������������� ����� �� �� ��������
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.WeightChanged -= ControlWeightChanged;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.WeightChanged -= ControlWeightChanged;
                control.Dispose();
            }
        }

        #endregion

        #region private void ControlWeightChanged(object sender, EventArgs e)
        private void ControlWeightChanged(object sender, EventArgs e)
        {
            GetTotal();
        }
        #endregion

        #region Events

        ///<summary>
        /// ��������� ��� ��������� ���� �����
        ///</summary>
        [Category("Cargo data")]
        [Description("��������� ��� ��������� ������� �� �����")]
        public event ValueChangedEventHandler OnCargoWeightChanget;

        ///<summary>
        /// ������������� �� ��������� ��������� ���� �����
        ///</summary>
        ///<param name="value"></param>
        private void InvokeCargoWeightChanget(double value)
        {
            ValueChangedEventHandler handler = OnCargoWeightChanget;
            if (handler != null) handler(new ValueChangedEventArgs(value));
        }

        #endregion
    }
}

