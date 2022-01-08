using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.CAA;
using SmartCore.Entities.Collections;

namespace CAS.UI.UICAAControls.Operators
{
    ///<summary>
    /// Контрол для представления коллекции ВС и кнопок для манипуляции с ней
    ///</summary>
    public partial class AllOperatorsDemoCollectionControl : UserControl
    {
        #region Fields

        private WaitForm waitForm;
        private AnimatedThreadWorker animatedThreadWorker;
        private CommonCollection<AllOperators> _itemsCollection;

        private List<ReferenceStatusImageLinkLabel> _controlItems;

        #endregion

        #region Constructors

        ///<summary>
        /// Простой конструктор по умолчанию
        ///</summary>
        public AllOperatorsDemoCollectionControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region public bool Extended

        public bool Extended
        {
            get { return extendableRichContainer.Extended; }
            set { extendableRichContainer.Extended = value; }
        }

        #endregion

        #region public CommonCollection<Aircraft> OperatorCollection

        /// <summary>
        /// Возвращает или задает коллекцию ВС
        /// </summary>
        public CommonCollection<AllOperators> OperatorCollection
        {
            get { return _itemsCollection; }
            set
            {
                _itemsCollection = value;
                FillUiElementsFromCollection();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void FillUiElementsFromCollection()

        /// <summary>
        /// Заполняет графический элемент из бизнес коллекции
        /// </summary>
        public void FillUiElementsFromCollection()
        {
            if (_itemsCollection == null) return;
            int count = _itemsCollection.Count;
            _controlItems = new List<ReferenceStatusImageLinkLabel>();
            flowLayoutPanelAircrafts.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                var tempLabel = new ReferenceStatusImageLinkLabel
                {
                    ActiveLinkColor = Color.FromArgb(62, 155, 246),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    //Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                    HoveredLinkColor = Color.FromArgb(62, 155, 246),
                    LinkColor = Color.FromArgb(62, 155, 246),
                    MaximumSize = new Size(250, 20),
                    Size = new Size(250, 20),
                    Tag = _itemsCollection[i],
                    Text = _itemsCollection[i].ShortName,
                    TextAlign = ContentAlignment.MiddleLeft,
                    TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),

                    Enabled = true,
                    Status = Statuses.Satisfactory
                };

                _controlItems.Add(tempLabel);
                if (GlobalObjects.CaaEnvironment.Operators.Count == 1)
                    tempLabel.DisplayerText = _itemsCollection[i].FullName;
                else
                    tempLabel.DisplayerText =
                        GlobalObjects.CaaEnvironment.Operators.First(o => o.ItemId == _itemsCollection[i].ItemId)
                            .Name + ". " + _itemsCollection[i].FullName;

                _controlItems.Add(tempLabel);

                tempLabel.DisplayerRequested += TempButtonDisplayerRequested;


            }

            extendableRichContainer.Caption = _itemsCollection.Count + " Operator/Provider";
            _controlItems.Sort((x, y) => string.Compare(x.Text, y.Text));
            flowLayoutPanelAircrafts.Controls.AddRange(_controlItems.ToArray());
            flowLayoutPanelAircrafts.Controls.Add(panelButtons);
        }

        private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion


        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            flowLayoutPanelAircrafts.Visible = extendableRichContainer.Extended;
        }

        #endregion #endregion
    }
}
