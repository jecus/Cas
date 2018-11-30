using System;
using AvControls.AvalonButtonM;
using CAS.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls
{
    /// <summary>
    /// Элемент управления AvalonButtonM для перехода к другим вкладкам
    /// </summary>
    public class ReferenceAvalonButtonM : AvalonButtonM, IReference
    {
        /// <summary>
        /// Создает элемент управления AvalonButtonM для перехода к другим вкладкам
        /// </summary>
        public ReferenceAvalonButtonM()
        {
            Click += ReferenceAvalonButtonMClick;
        }

        private void ReferenceAvalonButtonMClick(object sender, EventArgs e)
        {
            if (DisplayerRequested != null)
            {
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && ReflectionType == ReflectionTypes.DisplayInCurrent) ReflectionType = ReflectionTypes.DisplayInNew;
                DisplayerRequested(this,
                                   null != Displayer
                                       ? new ReferenceEventArgs(Entity, ReflectionType, Displayer, DisplayerText)
                                       : new ReferenceEventArgs(Entity, ReflectionType, DisplayerText));
            }
        }

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
    }
}
