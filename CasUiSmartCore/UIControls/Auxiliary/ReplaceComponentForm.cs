using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class ReplaceComponentForm : Form
    {
        #region Fields

        private ComponentCollection _replacedComponents;
        private ComponentCollection _replacedByComponents;
        private ReplaceComponentFormItem[] _replaceItems;
	    private readonly SmartCoreType _parentType;

	    #endregion

        #region Constructors

        #region public ReplaceDetailForm()
        ///<summary>
        ///</summary>
        public ReplaceComponentForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public ReplaceDetailForm(DetailCollection replacedDetails, DetailCollection replacedByDetails, ReplaceDetailFormItem[] replacedItems)
        ///<summary>
        ///</summary>
        public ReplaceComponentForm(ComponentCollection replacedComponents, ComponentCollection replacedByComponents, ReplaceComponentFormItem[] replacedItems, SmartCoreType parentType)
        {
            _replacedComponents = replacedComponents;
            _replacedByComponents = replacedByComponents;
            _replaceItems = replacedItems;
	        _parentType = parentType;

	        InitializeComponent();
            UpdateInformation();
        }

        #endregion
        
        #endregion

        #region Properties
        #endregion

        #region Methods

        #region public ReplaceDetailFormItem[] GetReplacedItems()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public ReplaceComponentFormItem[] GetReplacedItems()
        {
            return _replaceItems;
        }
        #endregion

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        public void UpdateInformation()
        {
            if(_replaceItems == null || _replaceItems.Length == 0) return;
                
            flowLayoutPanelMain.Controls.AddRange(_replaceItems.ToArray());

            if(_replacedByComponents == null || _replacedByComponents.Count == 0) return;
                
            ComponentCollection resultReplacedBy = new ComponentCollection(_replacedByComponents.ToArray());

            foreach (ReplaceComponentFormItem item in _replaceItems)
            {
	            if (item.ParentComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts) ||
	                item.ParentComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
	            {
		            item.comboBoxReplaceByDetail.Enabled = true;
	            }
	            else
	            {
					item.comboBoxReplaceByDetail.Enabled = false;
				}

                if(item.ReplacedByComponent != null)
                    resultReplacedBy.Remove(item.ReplacedByComponent);
            }

            foreach (ReplaceComponentFormItem item in _replaceItems)
            {
                item.ReplaceByDetailChanged += ReplaceItemsReplaceByDetailChanged;

				if(item.ParentComponent is BaseComponent)
					item.comboBoxReplaceByDetail.Items.AddRange(resultReplacedBy.Where(i => i is BaseComponent).ToArray());
				else item.comboBoxReplaceByDetail.Items.AddRange(resultReplacedBy.Where(i => i is Component).ToArray());
			}
        }
        #endregion

        #region void ReplaceItemsReplaceByDetailChanged(object sender, EventArgs e)

        void ReplaceItemsReplaceByDetailChanged(object sender, EventArgs e)
        {
            if (_replacedByComponents == null || _replacedByComponents.Count == 0) return;

            ComponentCollection resultReplacedBy = new ComponentCollection(_replacedByComponents.ToArray());

            foreach (ReplaceComponentFormItem item in _replaceItems)
            {
                if (item.ReplacedByComponent != null)
                    resultReplacedBy.Remove(item.ReplacedByComponent);
            }

            foreach (ReplaceComponentFormItem item in _replaceItems)
            {
                item.comboBoxReplaceByDetail.Items.Clear();

                item.comboBoxReplaceByDetail.SelectedIndexChanged -= item.ComboBoxReplaceByDetailSelectedIndexChanged;
                item.comboBoxReplaceByDetail.Items.Add("No detail for replace");
                if (item.ReplacedByComponent != null)
                {
                    item.comboBoxReplaceByDetail.Items.Add(item.ReplacedByComponent);
                    item.comboBoxReplaceByDetail.SelectedItem = item.ReplacedByComponent;
                }
                else item.comboBoxReplaceByDetail.SelectedIndex = 0;
                item.comboBoxReplaceByDetail.Items.AddRange(resultReplacedBy.ToArray());
                item.comboBoxReplaceByDetail.SelectedIndexChanged += item.ComboBoxReplaceByDetailSelectedIndexChanged;
            }
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
	        if (_parentType == SmartCoreType.Aircraft || _parentType == SmartCoreType.Aircraft)
	        {
				var sb  = new StringBuilder();
		        var i = 1;

		        foreach (var item in _replaceItems)
		        {
			        if (item.comboBoxReplaceByDetail.SelectedItem == "No detail for replace" &&
			            (item.ParentComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts) ||
			             item.ParentComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment)))
			        {
				        sb.AppendLine($"{i++}) {item.ParentComponent}");
				        item.ConfirmTransfer = false;
			        }
			        else
			        {
				        if (item.ReplacedByComponent != null && item.ParentComponent.ATAChapter.ItemId != item.ReplacedByComponent.ATAChapter.ItemId &&
				            item.ParentComponent.GoodsClass.ItemId != item.ReplacedByComponent.GoodsClass.ItemId)
				        {
							MessageBox.Show($"Transfer can not possible because the ATA or GoodClass of the install Component differs from replaced Component.", (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							item.ConfirmTransfer = false;
						}
						else item.ConfirmTransfer = true;
			        }
		        }

		        if (!string.IsNullOrEmpty(sb.ToString()))
		        {
					MessageBox.Show($"Please select detail for replace for next component : \n{sb}", (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

				if(_replaceItems.All(x => !x.ConfirmTransfer))
					return;
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

		#region public void UpdateLabels(bool installed)

		public void UpdateLabels(bool installed)
		{
			if (_parentType == SmartCoreType.Store || _parentType == SmartCoreType.Supplier || _parentType == SmartCoreType.Employee)
			{
				labelReplaceByDetail.Visible = labelReplaceByDate.Visible = false;
				this.Width = 680;
			}
			
			if (installed)
		    {
			    labelConfirmDate.Text = "install. date";
			    labelReplacedDetail.Text = "Install. detail";
			    labelReplaceByDetail.Text = "Removed detail";
			    labelReplaceByDate.Text = "Removed date";
		    }
		    else
		    {
			    labelConfirmDate.Text = "Remove date";
			    labelReplacedDetail.Text = "Removed. detail";
			    labelReplaceByDetail.Text = "Installed. detail";
			    labelReplaceByDate.Text = "Install. date";
		    }
	    }

	    #endregion

        #endregion
    }
}
