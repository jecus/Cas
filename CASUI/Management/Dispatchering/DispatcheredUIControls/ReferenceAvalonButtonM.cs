using System;
using Controls.AvalonButtonM;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls
{
    /// <summary>
    /// Элемент управления AvalonButtonM для перехода к другим вкладкам
    /// </summary>
    public class ReferenceAvalonButtonM : AvalonButtonM, IReference
    {
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        /// <summary>
        /// Создает элемент управления AvalonButtonM для перехода к другим вкладкам
        /// </summary>
        public ReferenceAvalonButtonM()
        {
            Click += ReferenceAvalonButtonM_Click;
        }

        private void ReferenceAvalonButtonM_Click(object sender, EventArgs e)
        {
            if (DisplayerRequested != null)
                DisplayerRequested(sender, new ReferenceEventArgs(Entity, ReflectionType, DisplayerText));
        }

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
    }
}
