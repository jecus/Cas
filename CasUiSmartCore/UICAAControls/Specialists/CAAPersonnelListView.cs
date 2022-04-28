using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PersonnelControls;
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
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 6;
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
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Combination", (int)(radGridView1.Width * 0.4f));
			AddColumn("Department", (int)(radGridView1.Width * 0.3f));
			AddColumn("Qualification", (int)(radGridView1.Width * 0.4f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.3f));
			AddColumn("Privileges", (int)(radGridView1.Width * 0.5f));
			AddColumn("Date of Birth", (int)(radGridView1.Width * 0.3f));
			AddColumn("Education", (int)(radGridView1.Width * 0.34f));
			AddColumn("Position", (int)(radGridView1.Width * 0.2f));
			AddColumn("Facility", (int)(radGridView1.Width * 0.3f));
			AddColumn("Sex", (int)(radGridView1.Width * 0.1f));
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
			var ratingString = "";
			foreach (var license in item.Licenses)
			{
				if (license.LicenseRatings.Count == 0)
					continue;

				if (ratingString != "")
					ratingString += " / ";

				ratingString += license.AircraftType.ShortName;
				ratingString += "-";

				foreach (var rating in license.LicenseRatings.GroupBy(r => r.LicenseFunction))
					ratingString += $"{rating.Key} ({string.Join(",", rating.Select(r => r.Rights.ShortName).ToArray())}) ";
			}

			var department = item.Occupation?.Department ??  Department.Unknown;
			var author = GlobalObjects.CasEnvironment?.GetCorrector(item) ?? GlobalObjects.CaaEnvironment?.GetCorrector(item);
			var phone = string.IsNullOrEmpty(item.Additional) ? item.Phone : $"{item.Phone} | Add.: {item.Additional}";


            var op = (GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(
                i => i.ItemId == item?.OperatorId) ?? AllOperators.Unknown).ToString();

            if (item.IsCAA)
                op = "CAA";

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(item.FirstName, item.FirstName),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.Occupation.ToString(), item.Occupation),
				CreateRow(item.Combination, item.Combination),
				CreateRow(department.ToString(), department),
				CreateRow(item.Qualification, item.Qualification),
				CreateRow(op.ToString(), op),
				CreateRow(ratingString, ratingString),
				CreateRow(item.DateOfBirth.ToString("dd-MMMM-yyyy"), item.DateOfBirth),
				CreateRow(item.Education.ToString(), item.Education),
				CreateRow(item.Position.ToString(), item.Position),
				CreateRow(item.Facility.ShortName, item.Facility),
				CreateRow(item.Gender.ToString(), item.Gender),
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
