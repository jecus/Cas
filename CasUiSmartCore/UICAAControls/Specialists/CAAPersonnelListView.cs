using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Specialists
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAAPersonnelListView : BaseGridViewControl<Specialist>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public CAAPersonnelListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Desc;
			OldColumnIndex = 1;
		}

        public int OperatorId { get; set; }

		#endregion

		#endregion

		#region Methods

        #region protected override SetGroupsToItems()
        protected override void GroupingItems()
        {
            Grouping("Operator");
        }
        #endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Status", (int)(radGridView1.Width * 0.20f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Combination", (int)(radGridView1.Width * 0.4f));
			
			AddColumn("Personnel", (int)(radGridView1.Width * 0.4f));
			AddColumn("Licence Type", (int)(radGridView1.Width * 0.4f));
			AddColumn("Type Aircraft", (int)(radGridView1.Width * 0.4f));
			
			
			AddColumn("Department", (int)(radGridView1.Width * 0.3f));
			AddColumn("Qualification", (int)(radGridView1.Width * 0.4f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.3f));

			AddColumn("Date of Birth", (int)(radGridView1.Width * 0.3f));
			AddColumn("Education", (int)(radGridView1.Width * 0.34f));
			AddColumn("Position", (int)(radGridView1.Width * 0.2f));
			AddColumn("Facility", (int)(radGridView1.Width * 0.3f));
			AddColumn("Sex", (int)(radGridView1.Width * 0.1f));
			AddColumn("Key", (int)(radGridView1.Width * 0.1f));
			AddColumn("Nationality", (int)(radGridView1.Width * 0.4f));
			AddColumn("Address", (int)(radGridView1.Width * 0.24f));
			AddColumn("Family Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("PhoneMobile", (int)(radGridView1.Width * 0.24f));
			AddColumn("Phone", (int)(radGridView1.Width * 0.4f));
			AddColumn("Email", (int)(radGridView1.Width * 0.14f));
			AddColumn("Skype", (int)(radGridView1.Width * 0.14f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(Specialist item)
		{
			var department = item.Occupation?.Department ??  Department.Unknown;
			var author = GlobalObjects.CasEnvironment?.GetCorrector(item) ?? GlobalObjects.CaaEnvironment?.GetCorrector(item);
			var phone = string.IsNullOrEmpty(item.Additional) ? item.Phone : $"{item.Phone} | Add.: {item.Additional}";


			var occupation = item.Occupation ?? Occupation.Unknown;
			
            var op = (GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(
                i => i.ItemId == item?.OperatorId) ?? AllOperators.Unknown).ToString();

            if (item.IsCAA)
                op = "CAA";
            
            
            var licensePers = PersonnelCategory.UNK;
            var licenseType = EmployeeLicenceType.UNK;
            var licenseAir = AircraftModel.Unknown;
			
            licensePers = item.PersonnelCategory;
            if (item.Licenses.Any())
            {
	            var license = item.Licenses.FirstOrDefault();
	            licenseType = license.EmployeeLicenceType;
	            licenseAir = license.AircraftType;
            }

			var subItems = new List<CustomCell>()
			{
				
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.FirstName, item.FirstName),
				
				CreateRow(item.Occupation.ToString(), item.Occupation),
				CreateRow(item.Combination, item.Combination),
				
				CreateRow(licensePers.ToString(), licensePers),
				CreateRow(licenseType.ToString(), licenseType),
				CreateRow(licenseAir.ToString(), licenseAir),
				
				
				CreateRow(department.ToString(), department),
				CreateRow(item.Qualification, item.Qualification),
				CreateRow(op, op),

				CreateRow(item.DateOfBirth.ToString("dd-MMMM-yyyy"), item.DateOfBirth),
				CreateRow(item.Education.ToString(), item.Education),
				CreateRow(item.Position.ToString(), item.Position),
				CreateRow(item.Facility.ShortName, item.Facility),
				CreateRow(item.Gender.ToString(), item.Gender),
				CreateRow(occupation.KeyPersonel ? "Yes":"No", occupation.KeyPersonel),
				CreateRow(item.Citizenship.ToString(), item.Citizenship),
				CreateRow(item.Address, item.Address),
				CreateRow(item.FamilyStatus.ToString(), item.FamilyStatus),
				CreateRow(item.PhoneMobile, item.PhoneMobile),
				CreateRow(phone, phone),
				CreateRow(item.Email, item.Email),
				CreateRow(item.Skype, item.Skype),
				CreateRow(author, author)
			};

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				string regNumber = SelectedItem.FirstName + " " + SelectedItem.LastName;
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber;
				e.RequestedEntity = new CAAEmployeeScreen(SelectedItem, OperatorId);
			}
		}
		#endregion

		#endregion
	}
}
