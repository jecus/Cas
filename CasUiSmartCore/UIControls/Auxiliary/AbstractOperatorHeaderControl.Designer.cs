namespace CAS.UI.UIControls.Auxiliary
{
    partial class AbstractOperatorHeaderControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if(disposing)
            {
                if (_currentDisplayer != null)
                    _currentDisplayer.ScreenChanged -= CurrentDisplayerScreenChanget;
                if (_currentOperator != null)
                    _currentOperator.PropertyChanged -= CurrentOperatorPropertyChanged;
                if (_childButton != null)
                    _childButton.DisplayerRequested -= ChildDisplayerRequested;
                if (this.logotypeButton != null)
                {
                    this.logotypeButton.MouseMove -= LogotypeButtonMouseMove;
                    this.logotypeButton.MouseLeave -= LogotypeButtonMouseLeave;
                    this.logotypeButton.DisplayerRequested -= LogotypeButtonDisplayerRequested;
                }
                if(this.titleButton != null)
                {
                    this.titleButton.MouseMove -= LogotypeButtonMouseMove;
                    this.titleButton.MouseLeave -= LogotypeButtonMouseLeave;
                    this.titleButton.DisplayerRequested -= LogotypeButtonDisplayerRequested;
                }
                if(this.previousButton != null)
                    this.previousButton.DisplayerRequested -= PreviousButtonDisplayerRequested;
                if(this.nextButton != null)
                    this.nextButton.DisplayerRequested -= NextButtonDisplayerRequested;
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.splitViewer1 = new AvControls.SplitViewer.SplitViewer();
            this.logotypeButton = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.titleButton = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.previousButton = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.nextButton = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.SuspendLayout();
            // 
            // splitViewer1
            // 
            this.splitViewer1.AutoSize = true;
            this.splitViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitViewer1.BackColor = System.Drawing.Color.Transparent;
            this.splitViewer1.ControlsAmount = 4;
            this.splitViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViewer1.Location = new System.Drawing.Point(0, 0);
            this.splitViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitViewer1.MinimumSize = new System.Drawing.Size(10, 10);
            this.splitViewer1.Name = "splitViewer1";
            this.splitViewer1.Size = new System.Drawing.Size(500, 47);
            this.splitViewer1.SplitterImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.splitViewer1.TabIndex = 0;
            //
            // logotypeButton
            //
            this.logotypeButton.Width = 50;
            this.logotypeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logotypeButton.TextMain = "";
            this.logotypeButton.IconLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logotypeButton.MouseMove += LogotypeButtonMouseMove;
            this.logotypeButton.MouseLeave += LogotypeButtonMouseLeave;
            this.logotypeButton.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.logotypeButton.DisplayerRequested += LogotypeButtonDisplayerRequested;
            //
            // titleButton
            //
            this.titleButton.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.titleButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleButton.FontMain = new System.Drawing.Font("Verdana", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleButton.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.titleButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleButton.MouseMove += LogotypeButtonMouseMove;
            this.titleButton.MouseLeave += LogotypeButtonMouseLeave;
            this.titleButton.DisplayerRequested += LogotypeButtonDisplayerRequested;
            //
            // previousButton
            //
            this.previousButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.previousButton.FontMain = new System.Drawing.Font("Verdana", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.previousButton.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.previousButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.previousButton.Icon = global::CAS.UI.Properties.Resources.BlueBack;
            this.previousButton.IconNotEnabled = global::CAS.UI.Properties.Resources.BlueBackGrey;
            this.previousButton.Width = 50;
            this.previousButton.TextMain = "";
            this.previousButton.DisplayerRequested += PreviousButtonDisplayerRequested;
            //
            // nextButton
            //
            this.nextButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.nextButton.FontMain = new System.Drawing.Font("Verdana", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextButton.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.nextButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.nextButton.Icon = global::CAS.UI.Properties.Resources.BlueArrow;
            this.nextButton.IconNotEnabled = global::CAS.UI.Properties.Resources.GrayArrow;
            this.nextButton.Width = 50;
            this.nextButton.TextMain = "";
            this.nextButton.DisplayerRequested += NextButtonDisplayerRequested;


            this.splitViewer1[0] = logotypeButton;
            this.splitViewer1[1] = titleButton;
            this.splitViewer1[2] = previousButton;
            this.splitViewer1[3] = nextButton;
            // 
            // AbstractOperatorHeaderControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitViewer1);
            this.Name = "AbstractOperatorHeaderControl";
            this.Size = new System.Drawing.Size(500, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /// <summary>
        /// Элемент управления отображения кнопок с разделителями
        /// </summary>
        protected AvControls.SplitViewer.SplitViewer splitViewer1;
        private CAS.UI.Management.Dispatchering.RichReferenceButton logotypeButton;
        private CAS.UI.Management.Dispatchering.RichReferenceButton titleButton;
        private CAS.UI.Management.Dispatchering.RichReferenceButton previousButton;
        private CAS.UI.Management.Dispatchering.RichReferenceButton nextButton;
    }
}