using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.Audit.PEL
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class PelPersonnelListView : BaseGridViewControl<PelSpecialist>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public PelPersonnelListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 6;
		}

        public int OperatorId { get; set; }

		#endregion

		#endregion

		#region Methods
		

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Roles", (int)(radGridView1.Width * 0.24f));
			AddColumn("Responsibilities", (int)(radGridView1.Width * 0.24f));
		}
		#endregion
		

		#endregion
	}
}
