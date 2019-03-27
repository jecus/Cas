using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Entities;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    ///<summary>
    /// Форма для отображение процесса загрузки
    ///</summary>
    public partial class LoadForm : MetroForm
    {
        #region Fields

        private LoadingState _loadingState;

        #endregion

        #region Properties

        #region public LoadingState LoadingState
        /// <summary>
        /// Возвращает или задает состояние выполнения загрузки
        /// </summary>
        public LoadingState LoadingState
        {
            get { return _loadingState; }
            set 
            { 
                _loadingState = value;
                
                if (InvokeRequired)
                    BeginInvoke(new Action(UpdateInformation));
                else UpdateInformation();
            }
        }

        #endregion

        #region public bool ShowStagePanel
        /// <summary>
        /// Возвращает или задает видимость панели стадий
        /// </summary>
        public bool ShowStagePanel
        {
            get { return panelStage.Visible; }
            set { panelStage.Visible = value; }
        }

        #endregion

        #region public bool ShowButtonsPanel
        /// <summary>
        /// Возвращает или задает видимость панели кнопок
        /// </summary>
        public bool ShowButtonsPanel
        {
            get { return panelButtons.Visible; }
            set { panelButtons.Visible = value; }
        }

        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LoadForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (_loadingState == null)return;

            if(panelStage.Visible)
            {
                progressBarStage.Maximum = _loadingState.Stages;
                
                if (_loadingState.CurrentStage <= _loadingState.Stages)
                {
                    labelStage.Text = 
                        string.Format("Stage: {0}/{1} :{2}", _loadingState.CurrentStage, 
                                                             _loadingState.Stages, 
                                                             _loadingState.CurrentStageDescription);
                    progressBarStage.Value = _loadingState.CurrentStage;
                }
            }

            if (progressBarPersentage.Maximum != (int)_loadingState.MaxPersentage)
            {
                progressBarPersentage.Value = 0;
                progressBarPersentage.Maximum = (int)_loadingState.MaxPersentage;
            }

            string persentageText = "Persent";

            if (_loadingState.MaxPersentage > 0)
            {
                persentageText += string.Format(": {0}/{1}", _loadingState.CurrentPersentage, 
                                                             _loadingState.MaxPersentage);
            }
            if (_loadingState.CurrentPersentageDescription != "")
            {
                persentageText +=
                    string.Format(" :{0}", _loadingState.CurrentPersentageDescription);
            }
            if (_loadingState.CurrentPersentage <= _loadingState.MaxPersentage)
            {
                labelPersentage.Text = persentageText;
                progressBarPersentage.Maximum = (int)_loadingState.MaxPersentage;
                progressBarPersentage.Value = (int)_loadingState.CurrentPersentage;
            }
        }

        #endregion

        #region

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region

        private void LoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #endregion
    }
}
