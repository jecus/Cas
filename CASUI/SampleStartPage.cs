using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LTR.UI.Interfaces;

namespace LTR.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SampleStartPage : UserControl, IDisplayingEntity
    {
        ///<summary>
        ///</summary>
        public SampleStartPage()
        {
            InitializeComponent();
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set {  }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is SampleStartPage)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}