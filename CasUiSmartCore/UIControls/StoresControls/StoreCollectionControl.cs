using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    ///  Контрол для представления коллекции ВС и кнопок для манипуляции с ней
    ///</summary>
    public partial class StoreCollectionControl : UserControl
    {
        #region Fields

        private WaitForm waitForm;
        private AnimatedThreadWorker animatedThreadWorker;
        private CommonCollection<Store> _itemsollection;
        private List<ReferenceStatusImageLinkLabel> _controlItems;
        //private const int HEIGHT = 520;

        #endregion

        public bool Extended
        {
            get { return extendableRichContainer.Extended; }
            set { extendableRichContainer.Extended = value; }
        }

        #region Constructors
        ///<summary>
        /// Простой конструктор по умолчанию
        ///</summary>
        public StoreCollectionControl()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Cоздается графический элемент на основе данной коллекции
        ///</summary>
        ///<param name="storesCollection">Данная бизнес коллекция</param>
        public StoreCollectionControl(CommonCollection<Store> storesCollection)
        {

            waitForm = StaticWaitFormProvider.WaitForm;
            extendableRichContainer.Caption = storesCollection.Count + " Stores";
            _itemsollection = storesCollection;
            FillUiElementsFromCollection();
        }
        #endregion

        #region Properties

        #region public CommonCollection<Store> ItemsCollection
        /// <summary>
        /// Возвращает или задает коллекцию элементов, отображаемых в контроле
        /// </summary>
        public CommonCollection<Store> ItemsCollection
        {
            get { return _itemsollection; }
            set
            {
                _itemsollection = value;
                FillUiElementsFromCollection();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void FillUiElementsFromCollection()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        private void FillUiElementsFromCollection()
        {
            if (_itemsollection == null) return;
            int count = _itemsollection.Count;
            _controlItems = new List<ReferenceStatusImageLinkLabel>();
            flowLayoutPanelAircrafts.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                ReferenceStatusImageLinkLabel tempItem = new ReferenceStatusImageLinkLabel();
                tempItem.ActiveLinkColor = Color.FromArgb(62, 155, 246);
                tempItem.AutoSize = true;
                tempItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tempItem.HoveredLinkColor = Color.FromArgb(62, 155, 246);
                tempItem.LinkColor = Color.FromArgb(62, 155, 246);
                tempItem.MaximumSize = new Size(250, 20);
                tempItem.Size = new Size(250, 20);
                tempItem.TextAlign = ContentAlignment.MiddleLeft;
                tempItem.TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204);
                tempItem.Enabled = true;
                tempItem.Status = Statuses.Satisfactory;                                              
                tempItem.Tag = _itemsollection[i];
                tempItem.Text = _itemsollection[i].Name;
                tempItem.DisplayerText = _itemsollection[i].Operator.Name + ". " + _itemsollection[i].Name;
                tempItem.DisplayerRequested += TempButtonDisplayerRequested;
                                                                  //Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                                                                
                //Css.ImageLink.Adjust(tempItem);

                _controlItems.Add(tempItem);
                //storeCollection[i].Saved -= StoreCollectionControl_Saved;
                //storeCollection[i].Saved += StoreCollectionControl_Saved;
            }
            extendableRichContainer.Caption = _itemsollection.Count + " Stores";
            _controlItems.Sort(new Comparison<ReferenceStatusImageLinkLabel>((x, y) => string.Compare(x.Text, y.Text)));
            flowLayoutPanelAircrafts.Controls.AddRange(_controlItems.ToArray());
            flowLayoutPanelAircrafts.Controls.Add(linkInventoryControl);
            flowLayoutPanelAircrafts.Controls.Add(linkShoundBeOnStock);
            flowLayoutPanelAircrafts.Controls.Add(panelButtons);
        }

        #endregion

        #region private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)

        private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            Store s = ((ReferenceStatusImageLinkLabel)sender).Tag as Store;

            Keyboard k = new Keyboard();
            if (k.ShiftKeyDown && e.TypeOfReflection == ReflectionTypes.DisplayInCurrent) e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new StoreScreen(s);
        }

		#endregion

		private void LinkInventoryControl_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			var k = new Keyboard();
			if (k.ShiftKeyDown && e.TypeOfReflection == ReflectionTypes.DisplayInCurrent)
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "All Stores";
			e.RequestedEntity = new StoreAllScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#region private void SetEnabledToAircraftButtons(bool isEnabled)

		/// <summary>
		/// Изменить свойство Enabled у кнопок
		/// </summary>
		/// <param name="isEnabled"></param>
		public void SetEnabledToAircraftButtons(bool isEnabled)
        {
            foreach (ReferenceStatusImageLinkLabel t in _controlItems)
            {
                t.Enabled = isEnabled;
            }
        }

        #endregion

        #region private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //StoreForm form = new StoreForm(GlobalObjects.CasEnvironment.Operators[0]);
            CommonEditorForm form = new CommonEditorForm(new Store
            {
                Operator = GlobalObjects.CasEnvironment.Operators[0],
                OperatorId = GlobalObjects.CasEnvironment.Operators[0].ItemId
            });
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.CurrentObject as Store == null)
                {
                    e.Cancel = true;
                    return;
                }
                Store s = form.CurrentObject as Store;

                //_itemsollection.Add(s);
                FillUiElementsFromCollection();

                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = s.Name;
                e.RequestedEntity = new StoreScreen(s);
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            CommonCollection<Store> stores = new CommonCollection<Store>();
            foreach (ReferenceStatusImageLinkLabel item in _controlItems)
            {
                stores.Add((Store)item.Tag);
            }
            CommonDeletingForm cdf = new CommonDeletingForm(typeof(Store), stores);
            if (cdf.ShowDialog() == DialogResult.OK)
            {
                if (cdf.DeletedObjects.Count == 0)
                {
                    return;
                }

                foreach (BaseEntityObject o in cdf.DeletedObjects)
                {
                    Store s = o as Store;
                    if (s != null) _itemsollection.Remove(s);
                }
                FillUiElementsFromCollection();
            }
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            flowLayoutPanelAircrafts.Visible = extendableRichContainer.Extended;
        }
        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие оповещающее о начале работы в другом потоке
        /// </summary>
        public event EventHandler TaskStart;

        /// <summary>
        /// Событие оповещающее о конце работы в другом потоке
        /// </summary>
        public event EventHandler TaskEnd;

        #endregion
    }
}
