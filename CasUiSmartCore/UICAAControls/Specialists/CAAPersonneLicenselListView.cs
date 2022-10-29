using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.CAA.Operators;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;
using Telerik.WinControls.UI;

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
			AddColumn("License Status", (int)(radGridView1.Width * 0.20f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.24f));
			AddColumn("First Name", (int)(radGridView1.Width * 0.24f));
			
			AddColumn("Occupation", (int)(radGridView1.Width * 0.24f));
			AddColumn("Combination", (int)(radGridView1.Width * 0.24f));
			AddColumn("Personnel", (int)(radGridView1.Width * 0.24f));
			AddColumn("Licence Type", (int)(radGridView1.Width * 0.24f));

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
			
			AddColumn("Medical", (int)(radGridView1.Width * 0.24f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.24f));
			AddColumn("Nationality", (int)(radGridView1.Width * 0.24f));
			

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

			var statLicense = OperatorStatus.GetItemById(item.Settings.StatusId) ?? OperatorStatus.Unknown;
			
			var validationOther = "";
            var validToOther = "";
            var remainOther = Lifelength.Null;
            
            var licenseNo = "";
            var validToLicense = "";
            var remainCaaLisence = Lifelength.Null;
            
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
	            if(item.MedicalRecord.ValidToDate.HasValue)
		            validToMedical = Convert.GetDateFormat(item.MedicalRecord.ValidToDate);
	            remainMedical = item.MedicalRecord.Remain;
            }
            
            if (item.Licenses.Any())
            {
	            var license = item.Licenses.FirstOrDefault();
	            
	            licenseType = license.EmployeeLicenceType;

	            if (license.CaaLicense.Any(c => c.CaaType == CaaType.Other))
	            {
		            var caa = license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Other);
		            validationOther = $"{caa.CAANumber} {caa.Caa}";
		            validToOther = Convert.GetDateFormat(caa.ValidToDate);
		            remainOther = caa.Remain;
	            }
	            
	            if (license.CaaLicense.Any(c => c.CaaType == CaaType.Licence))
	            {
		            var caa = license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Licence);
		            licenseNo = $"{caa.CAANumber} {caa.Caa.ShortName}";
		            validToLicense = Convert.GetDateFormat(license.ValidToDate);
		            remainCaaLisence = caa.Remain;
	            }

	            aircraftType = license.AircraftType;

	            
	            if (license.LicenseRatings.Any())
	            {
		            var rating = license.LicenseRatings.Select(i => $"{i.LicenseFunction} {i.Rights}");
		            ratings = string.Join(", ",rating);
	            }
	            
	            if (license.SpecialistInstrumentRatings.Any())
	            {
		            var instrument = license.SpecialistInstrumentRatings.FirstOrDefault();
		            instrumentRatings = $"{instrument.Icao}";
	            }
	            
	            if (item.LicenseRemark.Any())
	            {
		            var remark = item.LicenseRemark.Select(i => $"{i.LicenseRestriction} {i.Rights}");
		            remarks = string.Join(", ",remark);
	            }
	            
	            if (item.LicenseDetails.Any())
	            {
		            var detail = item.LicenseDetails.Select(i => $"{i.Description}");
		            details = string.Join(", ",detail);
	            }
            }

			var subItems = new List<CustomCell>()
			{
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(statLicense.ToString(), statLicense),
				CreateRow(item.LastName, item.LastName),
				CreateRow(item.FirstName, item.FirstName),
				
				CreateRow(item.Occupation.ToString(), item.Occupation),
				CreateRow(item.Combination, item.Combination),
				CreateRow(licensePers.ToString(), licensePers),
				CreateRow(licenseType.ToString(), licenseType),

				CreateRow(validationOther, validationOther),
				CreateRow(validToOther, validToOther),
				CreateRow(remainOther.ToString(), remainOther),
				
				CreateRow(licenseNo, licenseNo),
				CreateRow(validToLicense, validToLicense),
				CreateRow(remainCaaLisence.ToString(), remainCaaLisence),
				
				CreateRow(aircraftType.ToString(), aircraftType),
				CreateRow(ratings, ratings),
				CreateRow(instrumentRatings, instrumentRatings),
				CreateRow(remarks, remarks),
				CreateRow(details, details),
				
				CreateRow(medical, medical),
				CreateRow(validToMedical, validToMedical),
				CreateRow(remainMedical.ToString(), remainMedical),
				
				CreateRow(item.Citizenship.ToString(), item.Citizenship),
				
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
				var regNumber =  $"{SelectedItem.FirstName} {SelectedItem.LastName} License";
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber;
				e.RequestedEntity = new CAAEmployeeScreen(SelectedItem, OperatorId);
			}
		}
		#endregion
		
		protected override void SetItemColor(GridViewRowInfo listViewItem, Specialist item)
		{
			var itemBackColor = UsefulMethods.GetColor(item);
			var itemForeColor = Color.Gray;

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
	}
}
