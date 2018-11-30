using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Controls.AvalonButtonM;
using Controls.ExtendableList;

namespace LTR.UI.UIControls.AircraftsControls
{
    public partial class AircraftListItemExtendable : Control,IExtendableItem
    {
        #region Constructors

        public AircraftListItemExtendable()
        {
            InitializeComponent();
        }

        #endregion

        #region Fields
        
        
        private readonly AvalonButtonM buttonAircraft;
        private Label labelDirectives;
        private Label labelLimitation;


        #endregion

        #region Events

        public  event EventHandler Extended;

        #region IScrollLayoutPanelItem Members

        public int BlocksCount
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #endregion

        #region Methods

        public  void SetShortView()
        {
            throw new NotImplementedException();
        }

        public  void SetExtendedView()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
