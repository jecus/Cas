using System.Collections.Generic;
using System.ComponentModel;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;
using Telerik.WinControls.Data;

namespace CAS.UI.UICAAControls.Audit.PEL
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class PelItemListView : BaseGridViewControl<CheckLists>
	{
		#region Constructors

		
		public PelItemListView()
		{
			InitializeComponent();
			// ColumnIndexes = new List<string>()
			// {
			// 	"Section №", "Part №","SubPart №","Item №"
			// };
			// SortDirection = SortDirection.Desc;
			// EnableCustomSorting = true;
			//
			// this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
		}
		
		#endregion

		#region Methods
		

		protected override void GroupingItems()
		{
			this.radGridView1.GroupDescriptors.Clear();
			var descriptor = new GroupDescriptor();
			foreach (var colName in new List<string>{ "Section №" , "Section Name" , "Part №" , "Part Name", "SubPart №","SubPart Name" })
				descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
			this.radGridView1.GroupDescriptors.Add(descriptor);

            
		}
		
		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Section №", (int)(radGridView1.Width * 0.20f));
			AddColumn("Section Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Part №", (int)(radGridView1.Width * 0.24f));
			AddColumn("Part Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("SubPart №", (int)(radGridView1.Width * 0.24f));
			AddColumn("SubPart Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Item №", (int)(radGridView1.Width * 0.3f));
			AddColumn("Item Name", (int)(radGridView1.Width * 0.5f));
			AddColumn("Requirement", (int)(radGridView1.Width * 0.3f));
			AddColumn("Source", (int)(radGridView1.Width * 0.3f));
			AddColumn("Personnel", (int)(radGridView1.Width * 0.3f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion
		
		protected override List<CustomCell> GetListViewSubItems(CheckLists item)
		{
			var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Settings.SectionNumber, item.Settings.SectionNumber),
				CreateRow(item.Settings.SectionName, item.Settings.SectionName),
				CreateRow(item.Settings.PartNumber, item.Settings.PartNumber),
				CreateRow(item.Settings.PartName, item.Settings.PartName),
				CreateRow(item.Settings.SubPartNumber, item.Settings.SubPartNumber),
				CreateRow(item.Settings.SubPartName, item.Settings.SubPartName),
				CreateRow(item.Settings.ItemNumber, item.Settings.ItemNumber),
				CreateRow(item.Settings.ItemtName, item.Settings.ItemtName),
				CreateRow(item.Settings.Requirement, item.Settings.Requirement),
				CreateRow(item.Source, item.Source),
				CreateRow("",""),

				CreateRow(author, author)
			};

			return subItems;
		}
		
		#endregion
	}
	
	public  class PelItemSafaListView : PelItemListView
	{
		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public PelItemSafaListView() : base()
		{
			
		}
		
		#endregion

		#endregion

		#region Methods
		
		protected override void GroupingItems()
		{
			
		}
		

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Source", (int)(radGridView1.Width * 0.24f));
			AddColumn("Inspection Item", (int)(radGridView1.Width * 0.24f));
			AddColumn("Inspection Title", (int)(radGridView1.Width * 0.24f));
			AddColumn("Standard", (int)(radGridView1.Width * 0.24f));
			AddColumn("Standard Ref", (int)(radGridView1.Width * 0.24f));
			AddColumn("PDF Code", (int)(radGridView1.Width * 0.24f));

			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion
		
		
		protected override List<CustomCell> GetListViewSubItems(CheckLists item)
		{
			var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Source, item.Source),
				CreateRow(item.SettingsSafa.Item, item.SettingsSafa.Item),
				CreateRow(item.SettingsSafa.Title, item.SettingsSafa.Title),
				CreateRow(item.SettingsSafa.Standard, item.SettingsSafa.Standard),
				CreateRow(item.SettingsSafa.StandardRef, item.SettingsSafa.StandardRef),
				CreateRow(item.SettingsSafa.PdfCode, item.SettingsSafa.PdfCode),

				CreateRow(author, author)
			};

			return subItems;
		}
		

		#endregion
	}
	
	
	
	
}
