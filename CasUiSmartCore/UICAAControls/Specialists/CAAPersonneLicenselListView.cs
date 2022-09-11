using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Specialists
{
	///<summary>
	/// список для отображения сотрудников
	///</summary>
	public partial class CAAPersonneLicenselListView : BaseGridViewControl<Specialist>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public CAAPersonneLicenselListView()
		///<summary>
		///</summary>
		public CAAPersonneLicenselListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Desc;
			OldColumnIndex = 2;
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
			AddColumn("Occupation", (int)(radGridView1.Width * 0.24f));
			AddColumn("Combination", (int)(radGridView1.Width * 0.24f));
			AddColumn("Personnel", (int)(radGridView1.Width * 0.24f));
			AddColumn("Licence Type", (int)(radGridView1.Width * 0.24f));
			AddColumn("Type Aircraft", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("Validation", (int)(radGridView1.Width * 0.24f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("License №", (int)(radGridView1.Width * 0.24f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("Type Aircraft", (int)(radGridView1.Width * 0.24f));
			AddColumn("Ratings", (int)(radGridView1.Width * 0.24f));
			AddColumn("Instrument Ratings", (int)(radGridView1.Width * 0.24f));
			AddColumn("Special Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Other Details", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("Medical №", (int)(radGridView1.Width * 0.24f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.24f));
			

			AddColumn("Operator", (int)(radGridView1.Width * 0.3f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(Specialization item)

		protected override List<CustomCell> GetListViewSubItems(Specialist item)
		{
			var author = GlobalObjects.CasEnvironment?.GetCorrector(item) ?? GlobalObjects.CaaEnvironment?.GetCorrector(item);
			
			var op = (GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(
				i => i.ItemId == item?.OperatorId) ?? AllOperators.Unknown).ToString();

			if (item.IsCAA)
				op = "CAA";
			
			var licensePers = PersonnelCategory.UNK;
			var licenseType = EmployeeLicenceType.UNK;
			var licenseAir = AircraftModel.Unknown;
			
            var validation = "";
            var validTo = "";
            var remainCaa = Lifelength.Null;
            
            var licenseNo = "";
            var validToOther = "";
            var remainCaaOther = Lifelength.Null;
            
            var medical = "";
            var validToMedical = "";
            var remainMedical = Lifelength.Null;
            
            var aircraftType = AircraftModel.Unknown;
            var ratings = "";
            var instrumentRatings = "";
            var remarks = "";
            var details = "";
            
            licensePers = item.PersonnelCategory;
            if(item.MedicalRecord != null)
            {
	            medical = item.MedicalRecord.ClassNumber.ToString();
	            validToMedical = Convert.GetDateFormat(item.MedicalRecord.IssueDate);
            }
            
            if (item.Licenses.Any())
            {
	            var license = item.Licenses.FirstOrDefault();
	            
	            licenseType = license.EmployeeLicenceType;
	            licenseAir = license.AircraftType;
	            
	            if (license.CaaLicense.Any(c => c.CaaType == CaaType.Other))
	            {
		            var caa = license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Other);
		            validation = $"{caa.CAANumber} {caa.Caa}";
		            validTo = Convert.GetDateFormat(caa.ValidToDate);
	            }
	            
	            if (license.CaaLicense.Any(c => c.CaaType == CaaType.Licence))
	            {
		            var caa = license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Licence);
		            licenseNo = $"{caa.CAANumber} {caa.Caa}";
		            validToOther = Convert.GetDateFormat(caa.ValidToDate);
	            }

	            aircraftType = license.AircraftType;

	            
	            if (license.LicenseRatings.Any())
	            {
		            var rating = license.LicenseRatings.FirstOrDefault();
		            ratings = $"{rating.LicenseFunction} {rating.Rights}";
	            }
	            
	            if (license.SpecialistInstrumentRatings.Any())
	            {
		            var instrument = license.SpecialistInstrumentRatings.FirstOrDefault();
		            instrumentRatings = $"{instrument.Icao}";
	            }
	            
	            if (license.LicenseRemark.Any())
	            {
		            var remark = license.LicenseRemark.FirstOrDefault();
		            remarks = $"{remark.LicenseRestriction} {remark.Rights}";
	            }
	            
	            if (license.LicenseDetails.Any())
	            {
		            var detail = license.LicenseDetails.FirstOrDefault();
		            details = $"{detail.Description}";
	            }
            }

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(item.FirstName, item.FirstName),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.Occupation.ToString(), item.Occupation),
				CreateRow(item.Combination, item.Combination),
				CreateRow(licensePers.ToString(), licensePers),
				CreateRow(licenseType.ToString(), licenseType),
				CreateRow(licenseAir.ToString(), licenseAir),
				
				CreateRow(validation, validation),
				CreateRow(validTo, validTo),
				CreateRow(remainCaa.ToString(), remainCaa),
				
				CreateRow(licenseNo, licenseNo),
				CreateRow(validToOther, validToOther),
				CreateRow(remainCaaOther.ToString(), remainCaaOther),
				
				CreateRow(aircraftType.ToString(), aircraftType),
				CreateRow(ratings, ratings),
				CreateRow(instrumentRatings, instrumentRatings),
				CreateRow(remarks, remarks),
				CreateRow(details, details),
				
				CreateRow(medical, medical),
				CreateRow(validToOther, validToMedical),
				CreateRow(remainMedical.ToString(), remainMedical),
				
				CreateRow(op.ToString(), op),
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
