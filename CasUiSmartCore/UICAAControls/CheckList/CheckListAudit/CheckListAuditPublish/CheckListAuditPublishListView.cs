using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList.CheckListAudit;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.Audit
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CheckListAuditPublishListView : BaseGridViewControl<AuditPublish>
	{
		private readonly CAAAudit _audit;
		private readonly int _operatorId;
		private readonly CheckListAuditType _type;

		#region Constructors

		#region public PersonnelListView()



        public CheckListAuditPublishListView(CAAAudit audit, int operatorId, CheckListAuditType type)
        {
	        _audit = audit;
	        _operatorId = operatorId;
	        _type = type;
	        SortDirection = SortDirection.Desc;
	        OldColumnIndex = 0;
	        EnableCustomSorting = true;
	        InitializeComponent();
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
			AddColumn("WorkflowStage", (int)(radGridView1.Width * 0.40f));
			AddColumn("All Task", (int)(radGridView1.Width * 0.20f));
			AddColumn("My Task", (int)(radGridView1.Width * 0.20f));
		}
		#endregion
		
		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(AuditPublish item)
		{
			if (_type == CheckListAuditType.Admin)
			{
				radGridView1.Columns[2].IsVisible = false;
			}
			
			var subItems = new List<CustomCell>();

			var stage = WorkFlowStage.GetItemById(item.WorkFlowStageId);
            
			subItems.AddRange(new List<CustomCell>()
            {
	            CreateRow($"{stage.Order}.{stage}",stage),
	            CreateRow($"{item.AllTask}",item.AllTask),
	            CreateRow($"{item.MyTask}",item.MyTask),
            });

            return subItems;
		}

		#endregion
		

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
            if (SelectedItem != null)
            {
	            e.RequestedEntity = new CheckListAuditScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _operatorId ,  _audit.ItemId, _type);
	            e.DisplayerText = $"Audit: {_audit.AuditNumber}";
	            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
		}
		#endregion

		#endregion
	}
}
