using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Описывается интерфейс сущности, которая будет запрашивать управление приложением
    /// </summary>
    public interface IApplicationControlRequester
    {
        /// <summary>
        /// Запрошено дейтсвие управления
        /// </summary>
        event EventHandler<ApplicationControlRequestArgs> ControlRequest;
    }

    ///<summary>
    /// параметры управления приложением
    ///</summary>
    public class ApplicationControlRequestArgs:CancelEventArgs
    {
        /// <summary>
        /// Создается объект параметры
        /// </summary>
        /// <param name="controlType">Тип действия</param>
        public ApplicationControlRequestArgs(ControlType controlType)
        {
            this.controlType = controlType;
        }

        /// <summary>
        /// Создается объект параметры
        /// </summary>
        /// <param name="cancel">Отменить ли действие</param>
        /// <param name="controlType">Тип действия</param>
        public ApplicationControlRequestArgs(bool cancel, ControlType controlType) : base(cancel)
        {
            this.controlType = controlType;
        }

        private ControlType controlType;
        
        ///<summary>
        /// Тип управления приложением
        ///</summary>
        public ControlType ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }
    }

    /// <summary>
    /// Типы управления приложением
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// Запрашивается выход из системы с последующим входом в нее
        /// </summary>
        LogOut,
        /// <summary>
        /// Выход из системы
        /// </summary>
        Exit,
        /// <summary>
        /// Незначительное управление
        /// </summary>
        Trivial
    }
}
