using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.General;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CAAEducation
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class EducationComplianceListView : BaseGridViewControl<LastComplianceView>
	{

		#region Constructors

		#region public EducationComplianceListView()

        public EducationComplianceListView()
        {
            InitializeComponent();
            SortDirection = SortDirection.Asc;
            OldColumnIndex = 2;
		}
        
        
        #endregion

		#endregion

		#region Methods
		
		
		protected override void GroupingItems()
		{
			this.radGridView1.GroupDescriptors.Clear();
			var descriptor = new GroupDescriptor();
			foreach (var colName in new List<string>{  "Group" })
				descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
			this.radGridView1.GroupDescriptors.Add(descriptor);
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Group", (int)(radGridView1.Width * 0.40f));
            AddColumn("Courses", (int)(radGridView1.Width * 0.40f));
            AddColumn("Date", (int)(radGridView1.Width * 0.20f));
            AddColumn("Remark", (int)(radGridView1.Width * 0.60f));
		}
		#endregion
		
		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(LastComplianceView item)
        {
	        return  new List<CustomCell>()
	        {
		        CreateRow(item.Group, item.Group),
		        CreateRow(item.Course,item.Course),
		        CreateRow(item.LastDate, item.LastDate),
		        CreateRow(item.Remark, item.Remark),
	        };
        }

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.Cancel = true;
		}
		#endregion

		#endregion
	}
}
