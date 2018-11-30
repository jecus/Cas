using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LTR.UI.Interfaces;
using LTR.UI.UIControls;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls
{
    public partial class DispatcheredUIBiWeeklyReports : UIBiWeeklyReports, IDisplayingEntity
    {
        public DispatcheredUIBiWeeklyReports()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredUIBiWeeklyReports)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
