using System;
using System.ComponentModel;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Описывает базовый объект системы, не сохраняемый в БД
    /// </summary>
    [Serializable]
    public class BaseCoreObject : IBaseCoreObject
    {
        #region public virtual int CompareTo(object y)
        public virtual int CompareTo(object y)
        {
            return 0;
        }
        #endregion

        protected void UnSetEvents()
        {
            PropertyChanged = null;
        }

        #region public override string ToString()
        public override string ToString()
        {
            return "";
        }
        #endregion

        #region protected void OnPropertyChanged(string propertyName)
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        
        #region public event PropertyChangedEventHandler PropertyChanged;
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public BaseCoreObject()
        {
        }
    }
}
