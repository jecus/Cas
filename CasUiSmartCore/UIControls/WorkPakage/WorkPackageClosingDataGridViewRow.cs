using System;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace CAS.UI.UIControls.WorkPakage
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkPackageClosingDataGridViewRow : DataGridViewRow
    {
        #region Fields

        private IDirectivePackage _workPackage;
        private IDirective _currentClosingItem;
        private AbstractPerformanceRecord _record;
        private NextPerformance _nextPerformance;
        private DateTime? _prevPerfDate;
        private DateTime? _nextPerfDate;
        private Lifelength _minPerfSource;
        private Lifelength _maxPerfSource;

        #endregion

        #region Properties

        /// <summary>
        /// Пакет задач, с которым связана строка
        /// </summary>
        public IDirectivePackage WorkPackage
        {
            get { return _workPackage; }
            set { _workPackage = value; }
        }

        public NextPerformance NextPerformance
        {
            get { return _nextPerformance; }
            set { _nextPerformance = value; }
        }

        public IDirective ClosingItem
        {
            get { return _currentClosingItem; }
            set { _currentClosingItem = value; }
        }

        public AbstractPerformanceRecord Record
        {
            get { return _record; }
            set { _record = value; }
        }

        public DateTime? PrevPerfDate
        {
            get { return _prevPerfDate; }
            set { _prevPerfDate = value; }
        }

        public DateTime? NextPerfDate
        {
            get { return _nextPerfDate; }
            set { _nextPerfDate = value; }
        }

        public Lifelength MinPerfSource
        {
            get { return _minPerfSource; }
            set { _minPerfSource = value; }
        }

        public Lifelength MaxPerfSource
        {
            get { return _maxPerfSource; }
            set { _maxPerfSource = value; }
        }

        #endregion

        #region Constructors

        #region public WorkPackageClosingDataGridViewRow()

        ///<summary>
        ///</summary>
        public WorkPackageClosingDataGridViewRow()
        {
        }
        #endregion

        #endregion

        #region Methods

        #endregion
    }
}
