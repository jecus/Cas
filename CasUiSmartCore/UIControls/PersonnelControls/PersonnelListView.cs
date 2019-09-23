using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class PersonnelListView : BaseGridViewControl<Specialist>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public PersonnelListView()
		///<summary>
		///</summary>
		public PersonnelListView()
		{
			InitializeComponent();
			SortMultiplier = 0;
			OldColumnIndex = 6;
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
			AddColumn("Status", (int)(radGridView1.Width * 0.20f));
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Combination", (int)(radGridView1.Width * 0.4f));
			AddColumn("Department", (int)(radGridView1.Width * 0.3f));
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

			var department = item.Specialization?.Department ??  Department.Unknown;
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var phone = string.IsNullOrEmpty(item.Additional) ? item.Phone : $"{item.Phone} | Add.: {item.Additional}";


			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(item.FirstName, item.FirstName),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.Specialization.ToString(), item.Specialization),
				CreateRow(item.Combination, item.Combination),
				CreateRow(department.ToString(), department),
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
				e.RequestedEntity = new EmployeeScreen(SelectedItem);
			}
		}
		#endregion

		#endregion
	}
}
