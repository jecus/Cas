using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class DamageChartFileDialog : Form
    {
        #region Fields
        private DamageItem _currentDirctive;
        private Aircraft _currentAircraft;
        private List<DamageChartFileControlNew> _damageChartsFileControls;
        private List<DamageChartImageControl> _damageImagesFileControls;
        #endregion

        #region Constructors

        #region public DamageChartFileDialog()
        ///<summary>
        ///</summary>
        public DamageChartFileDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChartFileDialog(DamageItem directive)
        ///<summary>
        ///</summary>
        public DamageChartFileDialog(DamageItem directive, Aircraft currentAircarft)
        {
            _currentDirctive = directive;
            _currentAircraft = currentAircarft;
            _damageChartsFileControls = new List<DamageChartFileControlNew>();
            _damageImagesFileControls = new List<DamageChartImageControl>();
            
            InitializeComponent();

            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods

        #region  private void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if(_currentDirctive == null || _currentDirctive.DamageDocs == null 
                || _currentAircraft == null)return;

            if(_currentDirctive.DamageDocs.Count == 0)
            {
                //если у родителя нет ни одного Damage Doc-а, то ему добавляется в коллекцию Damage Doc-ов
                //пустой Damage Doc, ради того, что бы при появлении формы она не была пустой
                //если пользователь не изменит объект пустого Damage Doc-а, то данный Damage Doc при 
                //закрытии формы не сохранится и произоидет удаление всех пустых Damage Doc-ов из
                //коллекции Damage Doc-ов родителя

                DamageDocument damageDoc = new DamageDocument(1, _currentDirctive.ItemId);
                _currentDirctive.DamageDocs.Add(damageDoc);

                DamageDocument imageDoc = new DamageDocument(2, _currentDirctive.ItemId);
                _currentDirctive.DamageDocs.Add(imageDoc);
            }

            int countCharts = 0, countImages = 0;
            foreach (DamageDocument doc in _currentDirctive.DamageDocs)
            {
                
                if(doc.DocumentTypeId == 1)
                {
                    DamageChartFileControlNew docControl = new DamageChartFileControlNew(doc, _currentAircraft);
                    docControl.Extended = countCharts == 0;
                    countCharts++;
                    
                    _damageChartsFileControls.Add(docControl);
                    docControl.Deleted += ChartDeleted;
                    flowLayoutPanelCharts.Controls.Remove(panelButtonsFiles);
                    flowLayoutPanelCharts.Controls.Add(docControl);
                    flowLayoutPanelCharts.Controls.Add(panelButtonsFiles);
                }
                if (doc.DocumentTypeId == 2)
                {
                    DamageChartImageControl docControl = new DamageChartImageControl(doc);
                    if (countImages == 0) docControl.Extended = true;
                    else docControl.Extended = false;
                    countImages++;
                    
                    _damageImagesFileControls.Add(docControl);
                    docControl.Deleted += ImageDeleted;
                    flowLayoutPanelImages.Controls.Remove(panelButtonsImages);
                    flowLayoutPanelImages.Controls.Add(docControl);
                    flowLayoutPanelImages.Controls.Add(panelButtonsImages);
                }
            }
        }
        #endregion

        #region public bool Save()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool Save()
        {
            foreach (DamageChartFileControlNew damageChartsFileControl in _damageChartsFileControls)
                if (damageChartsFileControl.GetChangeStatus())
                    damageChartsFileControl.SaveData();
                else if (damageChartsFileControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                    _currentDirctive.DamageDocs.Remove(damageChartsFileControl.DamageDocument);
            foreach (DamageChartImageControl damageChartsImageControl in _damageImagesFileControls)
                if (damageChartsImageControl.GetChangeStatus())
                    damageChartsImageControl.SaveData();
                else if (damageChartsImageControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                    _currentDirctive.DamageDocs.Remove(damageChartsImageControl.DamageDocument);
            
            foreach (DamageDocument damageDocument in _currentDirctive.DamageDocs)
            {
                GlobalObjects.DirectiveCore.AddDamageDocument(damageDocument);
            }
            return true;
        }
        #endregion

        #region void ChartDeleted(object sender, EventArgs e)
        void ChartDeleted(object sender, EventArgs e)
        {
            DamageChartFileControlNew control = (DamageChartFileControlNew)sender;

            DamageDocument doc = control.DamageDocument;
            GlobalObjects.CasEnvironment.Manipulator.Delete(doc);
            _currentDirctive.DamageDocs.Remove(control.DamageDocument);
            _damageChartsFileControls.Remove(control);
            flowLayoutPanelCharts.Controls.Remove(control);
        }
        #endregion

        #region void ImageDeleted(object sender, EventArgs e)
        void ImageDeleted(object sender, EventArgs e)
        {
            DamageChartImageControl control = (DamageChartImageControl)sender;

            DamageDocument doc = control.DamageDocument;
            GlobalObjects.CasEnvironment.Manipulator.Delete(doc);
            _currentDirctive.DamageDocs.Remove(control.DamageDocument);
            _damageImagesFileControls.Remove(control);
            flowLayoutPanelImages.Controls.Remove(control);
        }
        #endregion

        #region private void ButtonAddChartClick(object sender, EventArgs e)
        private void ButtonAddChartClick(object sender, EventArgs e)
        {
            DamageDocument newDoc = new DamageDocument(1, _currentDirctive.ItemId);
            _currentDirctive.DamageDocs.Add(newDoc);

            DamageChartFileControlNew newChart = new DamageChartFileControlNew(newDoc, _currentAircraft);
            _damageChartsFileControls.Add(newChart);
            newChart.Deleted += ChartDeleted;
            flowLayoutPanelCharts.Controls.Remove(panelButtonsFiles);
            flowLayoutPanelCharts.Controls.Add(newChart);
            flowLayoutPanelCharts.Controls.Add(panelButtonsFiles);
        }
        #endregion

        #region private void ButtonAddImageClick(object sender, EventArgs e)
        private void ButtonAddImageClick(object sender, EventArgs e)
        {
            DamageDocument newDoc = new DamageDocument(2, _currentDirctive.ItemId);
            _currentDirctive.DamageDocs.Add(newDoc);

            DamageChartImageControl newImage = new DamageChartImageControl(newDoc);
            _damageImagesFileControls.Add(newImage);
            newImage.Deleted += ImageDeleted;
            flowLayoutPanelImages.Controls.Remove(panelButtonsImages);
            flowLayoutPanelImages.Controls.Add(newImage);
            flowLayoutPanelImages.Controls.Add(panelButtonsImages);
        }

        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            bool bChanged = false;
            foreach (DamageChartFileControlNew damageChartsFileControl in _damageChartsFileControls)
            {
                if (damageChartsFileControl.GetChangeStatus())
                {
                    bChanged = true;
                    break;
                }
                //if (damageChartsFileControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                //    _currentDirctive.DamageDocs.Remove(damageChartsFileControl.DamageDocument);
            }
            foreach (DamageChartImageControl damageChartsImageControl in _damageImagesFileControls)
            {
                if (damageChartsImageControl.GetChangeStatus())
                {
                    bChanged = true;
                    break;
                }
                //if (damageChartsImageControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                //    _currentDirctive.DamageDocs.Remove(damageChartsImageControl.DamageDocument);
            }

            if (!bChanged)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (MessageBox.Show("Do you really want to save changes?", "Save confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
            {
                if (!Save()) return;
            }
            else
            {
                foreach (DamageChartFileControlNew damageChartsFileControl in _damageChartsFileControls)
                {
                    if (damageChartsFileControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                        _currentDirctive.DamageDocs.Remove(damageChartsFileControl.DamageDocument);
                }
                foreach (DamageChartImageControl damageChartsImageControl in _damageImagesFileControls)
                {
                    if (damageChartsImageControl.DamageDocument.ItemId <= 0)//объект новый и небыл сохранен
                        _currentDirctive.DamageDocs.Remove(damageChartsImageControl.DamageDocument);
                }    
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void ButtonApplyClick(object sender, EventArgs e)
        private void ButtonApplyClick(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #endregion

    }
}
