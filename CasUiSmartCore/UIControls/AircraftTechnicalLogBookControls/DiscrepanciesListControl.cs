using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{


    /*
     * ����� ������� - ������������ ������ ������������ ������� 4 ���������� � �� ���������� ������� �� �������� ����������� � ���� ������
     * ���� �� ����� ������������ 4 ���������� �� ��������� ������ ����, ��� ��������, ��� �� ����� ������ ���� ���������� ������ ���� ����������
     */

    /// <summary>
    /// ������ ������ ���������� ���������� �����
    /// </summary>
    public partial class DiscrepanciesListControl : Interfaces.EditObjectControl
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

        private int _discrepanciesCount;

        private string _station;

        private DateTime _rtsDate = DateTime.Today;
        /*
         * 
         */

        #region public DateTime RTSDate
        ///<summary>
        /// ���������� ��� ������ ���� ������� � ������
        ///</summary>
        public DateTime RTSDate
        {
            get
            {
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControl))
                        continue;

                    return ((DiscrepancyControl)c).RTSDate;
                }
                return DateTime.Today;
            }
            set
            {
                _rtsDate = value;
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControl))
                        continue;

                    ((DiscrepancyControl)c).RTSDate = _rtsDate;
                }
            }
        }
        #endregion

        #region public String Station
        ///<summary>
        /// ���������� ��� ������ ������� ������� � ������
        ///</summary>
        public String Station
        {
            get
            {
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControl))
                        continue;

                    return ((DiscrepancyControl)c).Station;
                }
                return "";
            }
            set
            {
                _station = value;
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControl))
                        continue;

                    ((DiscrepancyControl)c).Station = _station;
                }
            }
        }
		#endregion

		#region public List<Discrepancy> Discrepancies { get; set; }

	    public List<Discrepancy> Discrepancies { get; set; }

	    #endregion

		public List<WorkPackage> WorkPackages { get; set; }
	    public List<TransferRecord> TransferRecords { get; set; }
	    public bool ShowDeffects { get; set; }

	    /*
         * �����������
         */

		#region public DiscrepanciesListControl()
		/// <summary>
		/// ������ �����������
		/// </summary>
		public DiscrepanciesListControl()
        {
            InitializeComponent();
            FillControls();
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
            for (int i = 0; i < panelDiscrepancies.Controls.Count; i++)
            {
                DiscrepancyControl d = panelDiscrepancies.Controls[i] as DiscrepancyControl;
                if (d != null && !d.IsNull)
                {
                    d.ApplyChanges();

                    //if(d.Discrepancy == null)
                    //{
                    //    return;
                    //}

                    /*
                     * �������� ��� ��������
                     * 
                     * 1) AircraftFlight ���������� � �� ������ ��������� � ������������ Discrepancy - ����� ������
                     * 2) AircraftFlight �� ���������� � �� ������� ����� Discrepancy - �������
                     * 3) AircraftFlight �� ���������� (�� ������� ����� �������� ������ � ���� �������) � �������������� Discrepancy ���� �����
                     * 
                     * � ������� ������ ��������� �� ������ ������������ � ����� ������� ����� �������� �� 
                     */

                    //if (d.Discrepancy.ItemID <= 0)
                    //{
                    // //   GlobalObjects.CasEnvironment.Manipulator.AddDiscrepancy(d.Discrepancy);
                    // // ������ ������
                    // // d.Discrepancy.Save();
                    //}
                    //else if (Flight.ItemId > 0)
                    //{
                    //    // ������ ������
                    //    Flight.Discrepancies.Add(d.Discrepancy);
                    //}
                    //else
                    //{
                    //    // ������ ������
                    //    // ������ �� ������, ������������, ��� ���� ����� ����� ������ ������ ����� ���������� AircraftFlight
                    //}

                    if (d.Discrepancy == null || d.Discrepancy.ItemId <= 0)
                    {
                        //����� Discrepancy, ��������� ��� � AircraftFlight
                        Flight.Discrepancies.Add(d.Discrepancy);
                    }
                }
            }

            for (int i = 0; i < panelMEL.Controls.Count; i++)
            {
                DiscrepancyControl d = panelMEL.Controls[i] as DiscrepancyControl;
                if (d != null && !d.IsNull)
                {
                    d.ApplyChanges();

                    if (d.Discrepancy == null || d.Discrepancy.ItemId <= 0)
                    {
                        //����� Discrepancy, ��������� ��� � AircraftFlight
                        Flight.Discrepancies.Add(d.Discrepancy);
                    }
                }
            }
            // ������ �� ������ ��������� ��� ������ � ����� �������� ������ ��� ��������� ���������� 


            //
            base.ApplyChanges();

            #region// ������������ ������� �� ���������

            List<DiscrepancyControl> dcs = panelDiscrepancies.Controls.OfType<DiscrepancyControl>().ToList();
            dcs.AddRange(panelMEL.Controls.OfType<DiscrepancyControl>());

            panelDiscrepancies.Controls.Clear();
            panelMEL.Controls.Clear();

            #endregion

            #region ���������� ��������������

            List<DiscrepancyControl> discrepancies = dcs.Where(d => d.Discrepancy != null && d.Discrepancy.DirectiveId <= 0).ToList();
            int count = discrepancies.Count();

            for (int i = 0; i < count; i++)
            {
                // ��������� �����������
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelDiscrepancies.Controls.Add(delimiter);
                }
                discrepancies[i].EnableExtendedControl = count >= 2;
                panelDiscrepancies.Controls.Add(discrepancies[i]);
            }
            panelDiscrepancies.Controls.Add(panelAdd);

            #endregion

            #region ���������� �������������� MEL

            List<DiscrepancyControl> mels = dcs.Where(d => d.Discrepancy != null && d.Discrepancy.DirectiveId > 0).ToList();
            count = mels.Count();

            for (int i = 0; i < count; i++)
            {
                // ��������� �����������
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelMEL.Controls.Add(delimiter);
                }
                mels[i].EnableExtendedControl = count >= 2;
                panelMEL.Controls.Add(mels[i]);
            }

            #endregion
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
            List<DiscrepancyControl> dcs = new List<DiscrepancyControl>();
            dcs.AddRange(panelDiscrepancies.Controls.OfType<DiscrepancyControl>());
            dcs.AddRange(panelMEL.Controls.OfType<DiscrepancyControl>());

            if (dcs.Any(dc => dcs.Count(c => c.Index == dc.Index) > 1))
            {
                MessageBox.Show("Do not create two or more discrepancies with one order num", 
                                (string) new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return false;
            }
            // ��������� ��������� ������
            // ��������� ������ �� ���������� ������� ������� ���� ����� ������������� (!d.IsNull));
            return dcs.Where(dc => dc != null && !dc.IsNull).All(dc => dc.CheckData());
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
            #region// ������������ ������� �� ���������
            
            foreach (Control control in panelDiscrepancies.Controls)
            {
                if (control is DiscrepancyControl)
                {
                    ((DiscrepancyControl) control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
                else if (control != panelAdd)
                {
                    control.Dispose();
                }
            }
            panelDiscrepancies.Controls.Clear();

            foreach (Control control in panelMEL.Controls)
            {
                if (control is DiscrepancyControl)
                {
                    ((DiscrepancyControl)control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
            }
            panelMEL.Controls.Clear();

            foreach (Control control in panelOldMEL.Controls)
            {
                if (control is DiscrepancyControl)
                {
                    ((DiscrepancyControl)control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
            }
            panelOldMEL.Controls.Clear();

            #endregion

            #region ���������� ��������������

            List<Discrepancy> discrepancies = Flight != null && Flight.Discrepancies != null
                                              ? Flight.Discrepancies.Where(d => d.DirectiveId <= 0).ToList()
                                              : new List<Discrepancy>();
            int count = discrepancies.Count();

            for (int i = 0; i < count; i++)
            {
                // ��������� �����������
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                                              {
                                                  Style = DelimiterStyle.Solid,
                                                  Orientation = DelimiterOrientation.Horizontal,
                                                  Margin = new Padding(0, 10, 0, 10),
                                                  Width = 1000
                                              };
                    panelDiscrepancies.Controls.Add(delimiter);
                }

                // ��������� ������� - �������������
                _discrepanciesCount++;
                DiscrepancyControl d = new DiscrepancyControl
                                           {
	                                           ShowDeffects = ShowDeffects,
											   Index = _discrepanciesCount,
                                               EnableExtendedControl = count >= 2,
	                                           _discrepancies = Discrepancies,
											   _workPackages = WorkPackages,
	                                           _transferRecords = TransferRecords
				};
                d.Deleted += ConditionControlDeleted;
				d.EditWp += D_EditWp;
				d.ComponentChangeReportOpen += D_ComponentChangeReportOpen; 
                if (Flight != null && i < discrepancies.Count())
                {
                    d.Discrepancy = discrepancies[i];
                    if (discrepancies[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // �� ����� ��������� Discrepancy, ���� ������ Flight �� ����� - �������� ����������� ��������
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                _discrepanciesCount++;
                panelDiscrepancies.Controls.Add(d);
            }
            panelDiscrepancies.Controls.Add(panelAdd);
           
            #endregion

            #region ���������� �������������� MEL

            List<Discrepancy> mels = Flight != null && Flight.Discrepancies != null
                                              ? Flight.Discrepancies.Where(d => d.DirectiveId > 0).ToList()
                                              : new List<Discrepancy>();
            count = mels.Count();

            for (int i = 0; i < count; i++)
            {
                // ��������� �����������
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelMEL.Controls.Add(delimiter);
                }

                // ��������� ������� - �������������
                _discrepanciesCount++;
                DiscrepancyControl d = new DiscrepancyControl
                                           {
                                               Index = _discrepanciesCount,
                                               EnableExtendedControl = count >= 2
                                           };
                d.Deleted += ConditionControlDeleted;
                if (Flight != null && i < mels.Count())
                {
                    d.Discrepancy = mels[i];
                    if (mels[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // �� ����� ��������� Discrepancy, ���� ������ Flight �� ����� - �������� ����������� ��������
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                _discrepanciesCount++;
                panelMEL.Controls.Add(d);
            }

            #endregion

            #region ���������� �������������� � ������� �������, ���������� �� ���. ����� 

            count = 0;
            if (Flight != null && Flight.UnclosedDiscrepancies != null) count = Flight.UnclosedDiscrepancies.Count;

            for (int i = 0; i < count; i++)
            {
                // ��������� �����������
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelOldMEL.Controls.Add(delimiter);
                }

                // ��������� ������� - �������������
                DiscrepancyControl d = new DiscrepancyControl
                                           {
                                               EditEnabled = false, 
                                               FlightVisible = true,
                                               EnableExtendedControl = count >= 2
                                           };

                d.Deleted += ConditionControlDeleted;
                if (Flight != null && Flight.UnclosedDiscrepancies != null && i < Flight.UnclosedDiscrepancies.Count)
                {
                    d.Discrepancy = Flight.UnclosedDiscrepancies[i];
                    if (Flight.UnclosedDiscrepancies[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // �� ����� ��������� Discrepancy, ���� ������ Flight �� ����� - �������� ����������� ��������
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                panelOldMEL.Controls.Add(d);
            }

            #endregion
        }

		#endregion

		#region private bool DiscrepancyExists(Discrepancy d)
		/// <summary>
		/// ���������� �� ������ ���������� � ������
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		private bool DiscrepancyExists(Discrepancy d)
        {
            //
            if (Flight == null || Flight.Reference == null) return false;

            //
            return Flight.Reference.Any(t => Flight.Reference == d.Description);

            //
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// ��� ��������� ������� �������� ��������� Flow Layout Panel �.�. ���� ��� ����� ������ �� ����� )
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if(panelDiscrepancies != null)panelDiscrepancies.Dock = DockStyle.Fill;
            base.OnSizeChanged(e);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelDiscrepancies.Controls.Remove(panelAdd);
            // ��������� ������� - �������������
            _discrepanciesCount++;
            var d = new DiscrepancyControl(new Discrepancy {ParentFlight = Flight}, Discrepancies, WorkPackages,
	            TransferRecords, ShowDeffects)
            {
	            Index = _discrepanciesCount,
	            Station = _station,
	            RTSDate = _rtsDate,
	            Extended = true,
	            EnableExtendedControl = false
            };
            d.Deleted += ConditionControlDeleted;
            d.EditWp += D_EditWp;
	        d.ComponentChangeReportOpen += D_ComponentChangeReportOpen;

			panelDiscrepancies.Controls.Add(d);
            panelDiscrepancies.Controls.Add(panelAdd);

            if (panelDiscrepancies.Controls.OfType<DiscrepancyControl>().Count() >= 4)
                linkLabelAddNew.Enabled = false;
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            DiscrepancyControl control = (DiscrepancyControl)sender;
            Discrepancy cond = control.Discrepancy;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Discrepancy?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

                if (panelDiscrepancies.Controls.Contains(control))
                    panelDiscrepancies.Controls.Remove(control);
                else if (panelMEL.Controls.Contains(control))
                    panelMEL.Controls.Remove(control);
                else if (panelOldMEL.Controls.Contains(control))
                    panelOldMEL.Controls.Remove(control);

                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                if (panelDiscrepancies.Controls.Contains(control))
                    panelDiscrepancies.Controls.Remove(control);
                else if (panelMEL.Controls.Contains(control))
                    panelMEL.Controls.Remove(control);
                else if (panelOldMEL.Controls.Contains(control))
                    panelOldMEL.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }

            if (panelDiscrepancies.Controls.OfType<DiscrepancyControl>().Count() < 4)
                linkLabelAddNew.Enabled = true;
        }

		#endregion


	    public event EventHandler EditWp;
	    public event EventHandler ComponentChangeReportOpen;

		private void D_EditWp(object sender, EventArgs e)
		{
			if (EditWp != null)
				EditWp(sender, EventArgs.Empty);
		}

	    private void D_ComponentChangeReportOpen(object sender, EventArgs e)
	    {
			if (ComponentChangeReportOpen != null)
				ComponentChangeReportOpen(sender, EventArgs.Empty);
		}

	}
}


