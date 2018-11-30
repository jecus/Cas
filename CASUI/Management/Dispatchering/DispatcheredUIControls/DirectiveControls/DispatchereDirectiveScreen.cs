using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LTR.Core.Types.Directives;
using LTR.UI.Interfaces;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    public partial class DispatchereDirectiveScreen : UserControl, IDisplayingEntity
    {
        public DispatchereDirectiveScreen(Directive displayedItem):this()
        {
        }

        private DispatchereDirectiveScreen()
        {
            InitializeComponent();
        }

        public object ContainedData
        {
            get { return null; }
            set {  }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            return (obj is DispatchereDirectiveScreen);
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            
        }
    }
}
