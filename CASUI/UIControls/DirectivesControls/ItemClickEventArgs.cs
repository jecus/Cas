using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTR.UI.UIControls.DirectivesControls
{
    public class ItemClickEventArgs : EventArgs
    {
        #region Fields
        private readonly DetailRecord detailRecord;
        #endregion

        #region Constructors

        #region public ItemClickEventArgs(DetailRecord detailRecord)
        public ItemClickEventArgs(DetailRecord detailRecord)
        {
            this.detailRecord = detailRecord;
        }
        #endregion

        #endregion

        #region Properties

        #region public DetailRecord DetailRecord
        /// <summary>
        /// Технические записи выделеного элемента
        /// </summary>
        public DetailRecord DetailRecord
        {
            get { return detailRecord; }
        }
        #endregion

        #endregion

    }
}
