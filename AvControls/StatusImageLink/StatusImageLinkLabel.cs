#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls.ImageLink;
using AvControls.Properties;

#endregion

namespace AvControls.StatusImageLink
{
    [Designer(typeof (StatusImageLinkLabelDesigner))]
    public class StatusImageLinkLabel : ImageLinkLabel
    {
        #region Fields

        private readonly Image[] _imageArray;
        private IContainer components;
        private Statuses _statusImage;
        #endregion

        #region Properties
        [DefaultValue(4), Description("Cтатус элемента управления"), Category("Appearance")]
        public Statuses Status
        {
            get { return _statusImage; }
            set
            {
                _statusImage = value;
                OnStatusChange(_statusImage);
            }
        }
        #endregion

        #region Constructors
        public StatusImageLinkLabel()
        {
            InitializeComponent();
            _imageArray = new Image[]
                             {
                                 Resources.SatisfactoryStatus, Resources.NotifyStatus, Resources.NotSatisfactoryStatus,
                                 Resources.PendingStatus, Resources.NotActiveStatus
                             };
            Image = _imageArray[4];
            Status = Statuses.NotActive;
        }
        #endregion

        #region Methods

        #region protected override void Dispose(bool disposing)
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region private void InitializeComponent()
        private void InitializeComponent()
        {
            components = new Container();
            AutoScaleDimensions = new SizeF(6F,13F);
            AutoScaleMode = AutoScaleMode.Font;
        }
        #endregion

        #region private void OnStatusChange(Statuses status)
        private void OnStatusChange(Statuses status)
        {
            Image = _imageArray[status.GetHashCode()];
            if (StatusChanged != null)
            {
                StatusChanged(this, new StatusEventArgs(status));
            }
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            switch (Status)
            {
                case Statuses.Satisfactory:
                    return "Satisfactory";

                case Statuses.Notify:
                    return "Notify";

                case Statuses.NotSatisfactory:
                    return "Not Satisfactory";

                case Statuses.Pending:
                    return "Warning: Performance conditions are not defined";

                case Statuses.NotActive:
                    return "Not Active";
            }
            return "Not Active";
        }
        #endregion
       
        #endregion

        #region Delegates

        public delegate void StatusEventHandler(object sender, StatusEventArgs e);

        #endregion

        #region public event StatusEventHandler StatusChanged;
        [Description("Событие вызываемое при изменении статуса"), Category("Property Changed")]
        public event StatusEventHandler StatusChanged;
        #endregion
    }
}