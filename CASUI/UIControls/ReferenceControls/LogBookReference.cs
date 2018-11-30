using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Appearance;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Класс, описывающий ссылку на Log book
    ///</summary>
    public partial class LogBookReference : RichReferenceContainer
    {
        private FlowLayoutPanel mainPanel;
        private Label description;
        private DateTime lastAddition = DateTime.MinValue;
        private ReferenceLinkLabel reference;

        ///<summary>
        /// Создается новый объект ссылки
        ///</summary>
        public LogBookReference()
        {
            InitializeComponent();
            //
            // description
            //
            description = new Label();
            description.Text = DescriptionText;
            description.AutoSize = true;
            Css.OrdinaryText.Adjust(description);
            //
            // reference
            //
            reference = new ReferenceLinkLabel();
            reference.AutoSize = true;
            reference.Text = "Enter log book";
            reference.DisplayerText = "Log book";
            reference.ReflectionType = ReflectionTypes.DisplayInNew;
            Css.SimpleLink.Adjust(reference);
            //
            // mainPanel
            //
            mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Controls.Add(description);
            mainPanel.Controls.Add(reference);

            MainControl = mainPanel;
        }

        #region public ReferenceLinkLabel Reference
        /// <summary>
        /// Ссылка перехода
        /// </summary>
        public ReferenceLinkLabel Reference
        {
            get { return reference; }
        }
        #endregion

        #region public string DescriptionText
        ///<summary>
        /// Текст описания
        ///</summary>
        public string DescriptionText
        {
            get
            {
                return "There is no information\r\nsince " + lastAddition.ToShortDateString();
            }
        }
        #endregion

        #region public DateTime LastAddition
        /// <summary>
        /// Время последнего внесения записи в Log book
        /// </summary>
        public DateTime LastAddition
        {
            get { return lastAddition; }
            set
            {
                lastAddition = value;
                description.Text = DescriptionText;
            }
        }
        #endregion

    }
}