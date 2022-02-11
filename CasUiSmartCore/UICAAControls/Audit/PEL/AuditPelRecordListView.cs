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
	public partial class AuditPelRecordListView : BaseGridViewControl<AuditPelRecord>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public AuditPelRecordListView()
		{
			InitializeComponent();
			ColumnIndexes = new List<string>()
			{
				"Section №", "Part №","SubPart №","Item №"
			};
			SortDirection = SortDirection.Desc;
			EnableCustomSorting = true;

			this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
		}

        public int OperatorId { get; set; }

		#endregion

		#endregion

		#region Methods
		

		protected override void GroupingItems()
		{
			this.radGridView1.GroupDescriptors.Clear();
			var descriptorGroup = new GroupDescriptor();
			descriptorGroup.GroupNames.Add("Personnel",  ListSortDirection.Ascending);
			this.radGridView1.GroupDescriptors.Add(descriptorGroup);
			
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
		
		
		protected override List<CustomCell> GetListViewSubItems(AuditPelRecord item)
		{
			var author = GlobalObjects.CaaEnvironment?.GetCorrector(item);

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.CheckList.Settings.SectionNumber, item.CheckList.Settings.SectionNumber),
				CreateRow(item.CheckList.Settings.SectionName, item.CheckList.Settings.SectionName),
				CreateRow(item.CheckList.Settings.PartNumber, item.CheckList.Settings.PartNumber),
				CreateRow(item.CheckList.Settings.PartName, item.CheckList.Settings.PartName),
				CreateRow(item.CheckList.Settings.SubPartNumber, item.CheckList.Settings.SubPartNumber),
				CreateRow(item.CheckList.Settings.SubPartName, item.CheckList.Settings.SubPartName),
				CreateRow(item.CheckList.Settings.ItemNumber, item.CheckList.Settings.ItemNumber),
				CreateRow(item.CheckList.Settings.ItemtName, item.CheckList.Settings.ItemtName),
				CreateRow(item.CheckList.Settings.Requirement, item.CheckList.Settings.Requirement),
				CreateRow(item.CheckList.Source, item.CheckList.Source),
				CreateRow($"{item.Specialist.FirstName} {item.Specialist.LastName}", item.Specialist),

				CreateRow(author, author)
			};

			return subItems;
		}
		

		#endregion
	}
}
