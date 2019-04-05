using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class PrimeDirectiveListView : BaseListViewControl<Directive>
    {
        #region Fields

        protected DirectiveType CurrentPrimatyDirectiveType;
        #endregion

        #region Constructors

        #region protected PrimeDirectiveListView()
        ///<summary>
        ///</summary>
        protected PrimeDirectiveListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public PrimeDirectiveListView(PrimaryDirectiveType primaryDirectiveType) : this()
        ///<summary>
        ///</summary>
        public PrimeDirectiveListView(DirectiveType primaryDirectiveType) : this()
        {
            CurrentPrimatyDirectiveType = primaryDirectiveType;
        }
        #endregion

        #endregion

        #region Methods

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader
                                            {
                                                Width = (int) (itemsListView.Width*0.12f),
                                                Text =
                                                    CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
                                                    CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus 
                                                        ? "AD No"
                                                        : CurrentPrimatyDirectiveType == DirectiveType.SB
                                                              ? "SB No"
                                                              : CurrentPrimatyDirectiveType ==
                                                                DirectiveType.EngineeringOrders
                                                                    ? "EO No"
                                                                    : ""
                                            };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader
                               {
                                   Width = (int) (itemsListView.Width*0.12f),
                                   Text =
                                       CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
                                       CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus 
                                           ? "SB No"
                                           : CurrentPrimatyDirectiveType == DirectiveType.SB
                                                 ? "EO No"
                                                 : CurrentPrimatyDirectiveType ==
                                                   DirectiveType.EngineeringOrders
                                                       ? "SB No"
                                                       : ""
                               };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader
                               {
                                   Width = (int) (itemsListView.Width*0.12f),
                                   Text =
                                       CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
                                       CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus 
                                           ? "EO No"
                                           : CurrentPrimatyDirectiveType == DirectiveType.SB
                                                 ? "AD No"
                                                 : CurrentPrimatyDirectiveType ==
                                                   DirectiveType.EngineeringOrders
                                                       ? "AD No"
                                                       : ""
                               };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Applicabilty" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Rpt. Intv." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remarks" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Effective date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "STC No" };
	        ColumnHeaderList.Add(columnHeader);
			
            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "1st. Perf."};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "ATA Chapter"};
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Base Detail" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "Kit"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "NDT"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.08f), Text = "M.H."};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Cost"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Hidden remarks"};
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
		{
			GroupToItems(columnIndex, ListViewItemList);
		}
        #endregion

        #region protected override void SetGroupsToItems(List<ListViewItem> listViewItems))
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected override void SetGroupsToItems(List<ListViewItem> listViewItems, int columnIndex)
        {
           GroupToItems(columnIndex, listViewItems);
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, Directive item)
        protected override void SetItemColor(ListViewItem listViewItem, Directive item)
        {
            Color itemBackColor = UsefulMethods.GetColor(item);
            Color itemForeColor = Color.Black;
            
            listViewItem.BackColor = UsefulMethods.GetColor(item);

            //Color white = Color.White;
            //Color itemBackColor = UsefulMethods.GetColor(item);
            Color listViewForeColor = ItemListView.ForeColor;

            if (listViewItem.SubItems.OfType<ListViewItem.ListViewSubItem>().Count(lvsi => lvsi.ForeColor.ToArgb() != listViewForeColor.ToArgb()) == 0)
            {
                listViewItem.ForeColor = itemForeColor;
                listViewItem.BackColor = itemBackColor;
            }
            else
            {
                listViewItem.UseItemStyleForSubItems = false;
                foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
                {
                    if (subItem.ForeColor.ToArgb() == listViewForeColor.ToArgb())
                        subItem.ForeColor = itemForeColor;

                    subItem.BackColor = itemBackColor;
                }
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)
        {
			var subItems = new List<ListViewItem.ListViewSubItem>();

			//////////////////////////////////////////////////////////////////////////////////////
			//         Определение последнего выполнения директивы и KitRequiered               //
			//////////////////////////////////////////////////////////////////////////////////////
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var lastComplianceLifeLength = Lifelength.Zero;
            var nextComplianceLifeLength = Lifelength.Null;
            var nextComplianceRemain = Lifelength.Null;

            string lastPerformanceString, firstPerformanceString = "N/A";

            var adColor = itemsListView.ForeColor;
            var sbColor = itemsListView.ForeColor;
            var eoColor = itemsListView.ForeColor;
            var stcColor = itemsListView.ForeColor;

            var effDate = DateTimeExtend.GetCASMinDateTime();

            var ata = item.ATAChapter;
            //////////////////////////////////////////////////////////////////////////////////////
            //         Определение последнего выполнения директивы и KitRequiered               //
            //////////////////////////////////////////////////////////////////////////////////////

            //Последнее выполнение
            if (item.LastPerformance != null &&
                item.LastPerformance.RecordDate > lastComplianceDate)
            {
                lastComplianceDate = item.LastPerformance.RecordDate;
				lastComplianceLifeLength = item.LastPerformance.OnLifelength;
			}

            //Следующее выполнение
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(directive);
            if (item.Threshold.FirstPerformanceSinceNew != null && !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                firstPerformanceString = "s/n: " + item.Threshold.FirstPerformanceSinceNew;
            }
            if (item.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !item.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
                else firstPerformanceString = "";
                firstPerformanceString += "s/e.d: " + item.Threshold.FirstPerformanceSinceEffectiveDate;
            }
            var repeatInterval = item.Threshold.RepeatInterval;

            if (nextComplianceLifeLength == null || nextComplianceLifeLength.IsNullOrZero())
                nextComplianceLifeLength = item.NextPerformanceSource;
            if (item.NextPerformanceSource != null && !item.NextPerformanceSource.IsNullOrZero() &&
                item.NextPerformanceSource.IsLessOrEqualByAnyParameter(nextComplianceLifeLength))
            {
                nextComplianceLifeLength = item.NextPerformanceSource;
                if (item.NextPerformanceDate != null) nextComplianceDate = (DateTime)item.NextPerformanceDate;
                if (item.Remains != null) nextComplianceRemain = item.Remains;
            }
            if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                lastPerformanceString = "N/A";
            else
                lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                        lastComplianceLifeLength;

            var nextComplianceString = ((nextComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                                               ? ""
                                               : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate)) + " " +
                                          nextComplianceLifeLength;
            var nextRemainString = nextComplianceRemain != null && !nextComplianceRemain.IsNullOrZero()
                                          ? nextComplianceRemain.ToString()
                                          : "N/A";
            effDate = item.Threshold.EffectiveDate;
            var descriptionString = item.Description;
	        var applicabilityString = item.IsApplicability ? $"APL  {item.Applicability}" : $"N/A  {item.Applicability}";
            var kitRequieredString = item.Kits.Count + " kits";
            var ndtString = item.NDTType.ShortName;
            var manHours = item.ManHours;
            var cost = item.Cost;
            var remarksString = item.Remarks;
            var hiddenRemarksString = item.HiddenRemarks;
            var adno = item.Title + "  §: " + item.Paragraph;
            var sbno = item.ServiceBulletinNo != "" ? item.ServiceBulletinNo : "N/A";
            var eono = item.EngineeringOrders != "" ? item.EngineeringOrders : "N/A";
            var stcno = item.StcNo != "" ? item.StcNo : "N/A";
	        var baseDetail = item.ParentBaseComponent.ToString();
            var status = item.Status;
            var workType = item.WorkType;

            if (item.ADNoFile == null)
                adColor = Color.MediumVioletRed;
            if (item.ServiceBulletinFile == null)
                sbColor = Color.MediumVioletRed;
            if (item.EngineeringOrderFile == null)
                eoColor = Color.MediumVioletRed;
	        if (item.STCFile == null)
		        stcColor = Color.MediumVioletRed;

            string s1 = "";
            string s2 = "";
            string s3 = "";
            Color c1 = Color.White, c2 = Color.White, c3 = Color.White;

            if(CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
               CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus)
            {
                s1 = adno; s2 = sbno; s3 = eono;
                c1 = adColor; c2 = sbColor; c3 = eoColor;
            }
            else if (CurrentPrimatyDirectiveType == DirectiveType.SB)
            {
                s1 = sbno; s2 = eono; s3 = adno;
                c1 = sbColor; c2 = eoColor;  c3 = adColor;     
            }
            else if (CurrentPrimatyDirectiveType == DirectiveType.EngineeringOrders)
            {
                s1 = eono; s2 = sbno; s3 = adno;
                c1 = eoColor; c2 = sbColor; c3 = adColor;      
            }

			subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = c1, Text = s1, Tag = s1 });
			subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = c2, Text = s2, Tag = s2 });
			subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = c3, Text = s3, Tag = s3 });
			subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = stcColor, Text = stcno, Tag = stcno });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = descriptionString, Tag = descriptionString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = applicabilityString, Tag = applicabilityString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = workType.ToString(), Tag = workType });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status });
			subItems.Add(new ListViewItem.ListViewSubItem 
            { 
                Text = effDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "", 
                Tag = effDate 
            });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = baseDetail, Tag = baseDetail });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours == -1? "" : manHours.ToString(), Tag = manHours });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = cost == -1 ? "" : cost.ToString(), Tag = cost });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString });

            return subItems.ToArray();
        }

        #endregion

        #region protected override void SortItems(int columnIndex)

        protected override void SortItems(int columnIndex)
        {
            if (OldColumnIndex != columnIndex)
                SortMultiplier = -1;
            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;
            itemsListView.Items.Clear();

            List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex <= 4 || columnIndex == 7 || columnIndex >= 18)
            {
                SetGroupsToItems(columnIndex);
                ListViewItemList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Directive)
                    {
                        resultList.Add(item);
                    }
                }
            }
            else if (columnIndex == 10)
            {
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Directive)
                    {
                        resultList.Add(item);
                    }
                }

                resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

                itemsListView.Groups.Clear();
                foreach (var item in resultList)
                {
					var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
					itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }

            }
            else
            {
                SetGroupsToItems(columnIndex);
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Directive)
                    {
                        resultList.Add(item);
                    }
                }
                resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.ToArray());
            OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem == null) 
                return;
            string regNumber = "";
	        var parentStore = GlobalObjects.StoreCore.GetStoreById(SelectedItem.ParentBaseComponent.ParentStoreId);

            if (SelectedItem.ParentBaseComponent.BaseComponentType == BaseComponentType.Frame)
                regNumber = SelectedItem.ParentBaseComponent.ToString();
            else
            {
				if (SelectedItem.ParentBaseComponent.ParentAircraftId > 0)
                    regNumber = SelectedItem.ParentBaseComponent.GetParentAircraftRegNumber() + ". " + SelectedItem.ParentBaseComponent;
				else if (parentStore != null)
                    regNumber = $"{parentStore.Name}. {SelectedItem.ParentBaseComponent}"; //TODO:(Evgenii Babak) заменить на использование StoreCore
			}

            if (SelectedItem is DeferredItem)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new DeferredScreen((DeferredItem)SelectedItem);
            }
            else if (SelectedItem is DamageItem)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new DamageDirectiveScreen((DamageItem)SelectedItem);
            }
            else if (SelectedItem.DirectiveType.Equals(DirectiveType.OutOfPhase))
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new OutOfPhaseReferenceScreen(SelectedItem);
            }
            else if (SelectedItem.DirectiveType.Equals(DirectiveType.AirworthenessDirectives))
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new DirectiveScreen(SelectedItem);
            }
            else if (SelectedItem.DirectiveType.Equals(DirectiveType.SB))
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.ServiceBulletinNo;
                e.RequestedEntity = new DirectiveScreen(SelectedItem);
            }
            else if (SelectedItem.DirectiveType.Equals(DirectiveType.EngineeringOrders))
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.EngineeringOrders;
                e.RequestedEntity = new DirectiveScreen(SelectedItem);
            }
        }
		#endregion

		#region private ListViewGroup GetGroupAd(Directive directive)

		private ListViewGroup GetGroupAd(Directive directive)
		{
			switch (directive.ADType)
			{
				case ADType.Airframe:
					return itemsListView.Groups["AF"];
				case ADType.Apliance:
					return itemsListView.Groups["AP"];
				case ADType.Engine:
					return itemsListView.Groups["Engine"];
				case ADType.APU:
					return itemsListView.Groups["APU"];
				case ADType.LandingGear:
					return itemsListView.Groups["LG"];
			}
			return itemsListView.Groups["None"];
		}

		#endregion

		#region private ListViewGroup GetGroupBaseDetail(BaseDetail baseDetail)

		private ListViewGroup GetGroupBaseDetail(BaseComponent baseComponent)
	    {
		    var bd = baseComponent.ToString();
		    return new ListViewGroup(bd, bd);
	    }

		#endregion


		#region private void GroupToItems(int columnIndex, List<ListViewItem> listViewItems = null)

		private void GroupToItems(int columnIndex, List<ListViewItem> listViewItems)
		{
		    itemsListView.Groups.Clear();
		    if (CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives)
		    {
				//TODO:(Evgenii Babak) Вынести в listViewGroupHelper
			    itemsListView.Groups.AddRange(new[]
			    {
				    new ListViewGroup("AF", "AF"),
				    new ListViewGroup("AP", "AP"),
				    new ListViewGroup("Engine", "Engine"),
				    new ListViewGroup("APU", "APU"),
				    new ListViewGroup("LG", "LG"),
				    new ListViewGroup("None", "None")
			    });
			    foreach (var t in listViewItems)
			    {
				    Directive directive = null;
				    if (t.Tag is Directive)
					    directive = ((Directive) t.Tag);

				    if (directive == null) continue;

				    if (columnIndex == 14)
				    {
					    var g = GetGroupBaseDetail(directive.ParentBaseComponent);
					    itemsListView.Groups.Add(g);
					    t.Group = itemsListView.Groups[g.Header];
				    }
				    else
				    {
						var temp = ListViewGroupHelper.GetDirectiveGroupString(directive);

						itemsListView.Groups.Add(temp, temp);
						t.Group = itemsListView.Groups[temp];
					}
			    }
		    }
		    else
		    {
			    foreach (var t in listViewItems)
			    {
				    if (!(t.Tag is Directive))
					    continue;

					var temp = ListViewGroupHelper.GetDirectiveGroupString((Directive)t.Tag);

					itemsListView.Groups.Add(temp, temp);
					t.Group = itemsListView.Groups[temp];
				}
		    }

	    }

	    #endregion



	    /*
         *  Копировать - Вставить - Вырезать
         */

			#region protected override void CopyToClipboard()
		protected override void CopyToClipboard()
        {
            // регистрация формата данных либо получаем его, если он уже зарегистрирован
            DataFormats.Format format = DataFormats.GetFormat(typeof(Directive[]).FullName);

            if(SelectedItems == null || SelectedItems.Count == 0)
                return;

            List<Directive> pds = SelectedItems;
            // копирование в буфер обмена
            IDataObject dataObj = new DataObject();
            dataObj.SetData(format.Name, false, pds.ToArray());
            Clipboard.SetDataObject(dataObj, false);

            pds.Clear();
        }
        #endregion

        #endregion
    }
}
