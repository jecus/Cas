using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using Telerik.WinControls.UI;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class 
		PrimeDirectiveListView : BaseGridViewControl<Directive>
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
			ColumnHeaderList.Clear();
			SetHeaders();
			radGridView1.Columns.Clear();
			radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
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
			AddColumn(CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
					  CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus
				? "AD No"
				: CurrentPrimatyDirectiveType == DirectiveType.SB
					? "SB No"
					: CurrentPrimatyDirectiveType ==
					  DirectiveType.EngineeringOrders
						? "EO No"
						: "", (int)(radGridView1.Width * 0.24f));
			AddColumn(CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
					  CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus
				? "SB No"
				: CurrentPrimatyDirectiveType == DirectiveType.SB
					? "EO No"
					: CurrentPrimatyDirectiveType ==
					  DirectiveType.EngineeringOrders
						? "SB No"
						: "", (int)(radGridView1.Width * 0.24f));
			AddColumn(CurrentPrimatyDirectiveType == DirectiveType.AirworthenessDirectives ||
					  CurrentPrimatyDirectiveType == DirectiveType.ModificationStatus
				? "EO No"
				: CurrentPrimatyDirectiveType == DirectiveType.SB
					? "AD No"
					: CurrentPrimatyDirectiveType ==
					  DirectiveType.EngineeringOrders
						? "AD No"
						: "", (int)(radGridView1.Width * 0.24f));
			AddColumn("Applicabilty", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.10f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.20f));
			AddColumn("Remain/Overdue", (int)(radGridView1.Width * 0.24f));
			AddColumn("Status", (int)(radGridView1.Width * 0.14f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Effective date", (int)(radGridView1.Width * 0.16f));
			
			AddColumn("Affect", (int)(radGridView1.Width * 0.10f));
			AddColumn("Zone", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Area", (int)(radGridView1.Width * 0.16f));
			AddColumn("Access", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("STC No", (int)(radGridView1.Width * 0.16f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("ATA Chapter", (int)(radGridView1.Width * 0.10f));
			AddColumn("Base Detail", (int)(radGridView1.Width * 0.10f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.10f));
			AddColumn("NDT", (int)(radGridView1.Width * 0.10f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.10f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.10f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, Directive item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, Directive item)
		{
			Color itemBackColor = UsefulMethods.GetColor(item);
			Color itemForeColor = Color.Black;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.DrawFill = true;
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = UsefulMethods.GetColor(item);

				var listViewForeColor = cell.Style.ForeColor;

				if (listViewForeColor != Color.MediumVioletRed)
					cell.Style.ForeColor = itemForeColor;
				cell.Style.BackColor = itemBackColor;
			}
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

		protected override List<CustomCell> GetListViewSubItems(Directive item)
		{
			var subItems = new List<CustomCell>();

			//////////////////////////////////////////////////////////////////////////////////////
			//         Определение последнего выполнения директивы и KitRequiered               //
			//////////////////////////////////////////////////////////////////////////////////////
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
			var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
			var lastComplianceLifeLength = Lifelength.Zero;
			var nextComplianceLifeLength = Lifelength.Null;
			var nextComplianceRemain = Lifelength.Null;

			string lastPerformanceString, firstPerformanceString = "N/A";

			var adColor = radGridView1.ForeColor;
			var sbColor = radGridView1.ForeColor;
			var eoColor = radGridView1.ForeColor;
			var stcColor = radGridView1.ForeColor;

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
			var kitRequieredString = item.Kits.Count + " EA";
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
			var access = item.DirectiveAccess;
			var zone = item.DirectiveZone;
			var workarea = item.Workarea;
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

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

			subItems.Add(CreateRow(s1, s1, c1));
			subItems.Add(CreateRow(s2, s2, c2));
			subItems.Add(CreateRow(s3, s3, c3));
			subItems.Add(CreateRow(applicabilityString, applicabilityString));
			subItems.Add(CreateRow(descriptionString, descriptionString));
			subItems.Add(CreateRow(nextComplianceString, nextComplianceDate));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate));
			subItems.Add(CreateRow(repeatInterval.ToString(), repeatInterval));
			subItems.Add(CreateRow(nextRemainString, nextRemainString));
			subItems.Add(CreateRow(status.ToString(), status));
			subItems.Add(CreateRow(remarksString, remarksString));
			subItems.Add(CreateRow(effDate > DateTimeExtend.GetCASMinDateTime()
				? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "", effDate));
			
			subItems.Add(CreateRow(item.Affects.ToString(), item.Affects));
			subItems.Add(CreateRow(zone, zone));
			subItems.Add(CreateRow(workarea, workarea));
			subItems.Add(CreateRow(access, access));
			subItems.Add(CreateRow(workType.ToString(), workType));
			subItems.Add(CreateRow(stcno, stcno, stcColor));
			subItems.Add(CreateRow(firstPerformanceString, firstPerformanceString));
			subItems.Add(CreateRow(ata.ToString(), ata));
			subItems.Add(CreateRow(baseDetail, baseDetail));
			subItems.Add(CreateRow(kitRequieredString, kitRequieredString));
			subItems.Add(CreateRow(ndtString, ndtString));
			subItems.Add(CreateRow(manHours == -1 ? "" : manHours.ToString(), manHours));
			subItems.Add(CreateRow(cost == -1 ? "" : cost.ToString(), cost));
			subItems.Add(CreateRow(hiddenRemarksString, hiddenRemarksString));
			subItems.Add(CreateRow(author, author));
			
			return subItems;
		}

		#endregion

		#region Overrides of BaseGridViewControl<Directive>
		protected override void Sorting(string colName = null)
		{

		}

		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;

			var resultList = new List<Directive>();
			var list = radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new DirectiveGridViewDataRowInfoComparer(ColumnIndex, SortMultiplier));

			foreach (var item in list)
				resultList.Add(item.Tag as Directive);

			SetItemsArray(resultList.ToArray());
			OldColumnIndex = ColumnIndex;
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
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title + "  §: " + SelectedItem.Paragraph;
				e.RequestedEntity = new DeferredScreen((DeferredItem)SelectedItem);
			}
			else if (SelectedItem is DamageItem)
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title + "  §: " + SelectedItem.Paragraph; ;
				e.RequestedEntity = new DamageDirectiveScreen((DamageItem)SelectedItem);
			}
			else if (SelectedItem.DirectiveType.Equals(DirectiveType.OutOfPhase))
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title + "  §: " + SelectedItem.Paragraph; ;
				e.RequestedEntity = new OutOfPhaseReferenceScreen(SelectedItem);
			}
			else if (SelectedItem.DirectiveType.Equals(DirectiveType.AirworthenessDirectives))
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title + "  §: " + SelectedItem.Paragraph; ;
				e.RequestedEntity = new DirectiveScreen(SelectedItem);
			}
			else if (SelectedItem.DirectiveType.Equals(DirectiveType.SB))
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.ServiceBulletinNo + "  §: " + SelectedItem.Paragraph; ;
				e.RequestedEntity = new DirectiveScreen(SelectedItem);
			}
			else if (SelectedItem.DirectiveType.Equals(DirectiveType.EngineeringOrders))
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.EngineeringOrders + "  §: " + SelectedItem.Paragraph; ;
				e.RequestedEntity = new DirectiveScreen(SelectedItem);
			}
		}
		#endregion

		#region private ListViewGroup GetGroupBaseDetail(BaseDetail baseDetail)

		private ListViewGroup GetGroupBaseDetail(BaseComponent baseComponent)
		{
			var bd = baseComponent.ToString();
			return new ListViewGroup(bd, bd);
		}

		#endregion

		protected override void SetTotalText()
		{
			var dir = GetItemsArray().Select(i => i);

			var dict = new List<string>();
			foreach (var directive in dir)
			{
				var value = directive.Title;
				if (!dict.Contains(value))
					dict.Add(value);
			}


			this.labelTotal.Text = $"Total: {dict.Count}/{radGridView1.Rows.Count}";
		}


		#endregion
	}
}
