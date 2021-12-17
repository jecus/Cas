using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// ������ ������ ��������� ��� ����������� ���������� �� �����
    /// </summary>
    public partial class PowerUnitAccelerationListControl : Interfaces.EditObjectControl
    {

        #region public DetailType DetailType

        private BaseComponentType _componentType;
        ///<summary>
        /// ������ ��� ������� ��� ������� ����� ������������ ������ � ������
        ///</summary>
        public BaseComponentType ComponentType
        {
            set { _componentType = value; }
        }
        #endregion

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

        #region public PowerUnitAccelerationListControl()
        /// <summary>
        /// ������ ������ ��������� ��� ����������� ���������� �� �����
        /// </summary>
        public PowerUnitAccelerationListControl()
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
            // ��������� ��������� ��������� ��������
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitAccelerationControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitAccelerationControlItem;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.EngineAccelerationTimeCollection != null && !ConditionExists(c.Condition))
                    Flight.EngineAccelerationTimeCollection.Add(c.Condition);
            }


            /*
             * ��� ��������� ��������� � ��������� 
             * 
             * ����� ���������� ��������� ��������� ������ 
             * ��������� �������� StringConvertibleCollection � �� ����� ��������� ������� � ���� ������, 
             * � �������� � �������� ���� ������� AircraftFlights
             */

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
            BuildControls();
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

            // ��������� ��������� ������
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitAccelerationControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitAccelerationControlItem;
                if (c != null)
                    if (!c.CheckData()) return false;
            }

            // ��� ������ ������� ���������
            return true;
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
            flowLayoutPanelMain.Controls.Add(label);
            if (Flight != null && Flight.EngineAccelerationTimeCollection != null)
            {
	            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

                List<EngineAccelerationTime> runUps =
                    Flight.EngineAccelerationTimeCollection.ToArray().Where(r => r.BaseComponent.BaseComponentType.ItemId == _componentType.ItemId).
                        ToList();
                //����������� �������� �� �� ������ � ����������� ������� ������� � ������ ������
                for (int i = 0; i < runUps.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� ��������
                    PowerUnitAccelerationControlItem c = new PowerUnitAccelerationControlItem(aircraft, runUps[i]) { DetailLabelText = _componentType.ToString() };
                    if (i > 0) c.ShowHeaders = false;
                    
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private bool ConditionExists(EngineAccelerationTime con)
        /// <summary>
        /// ���������� �� ���������� �� ������ ����� ��� ��������� ��������
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(EngineAccelerationTime con)
        {
            //
            if (Flight == null || Flight.EngineAccelerationTimeCollection == null) return false;

            //
            return Flight.EngineAccelerationTimeCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			PowerUnitAccelerationControlItem performance =
                new PowerUnitAccelerationControlItem(aircraft, new EngineAccelerationTime());
            performance.Deleted += OilConditionControlDeleted;
            if (flowLayoutPanelMain.Controls.Count > 2) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            PowerUnitAccelerationControlItem control = (PowerUnitAccelerationControlItem)sender;
            EngineAccelerationTime cond = control.Condition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Time in regime record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.Deleted -= OilConditionControlDeleted;
                control.Dispose();
            }
            else if(cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion
    }
}

