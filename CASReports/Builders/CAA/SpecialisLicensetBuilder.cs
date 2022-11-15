using System;
using System.Collections.Generic;
using System.Linq;
using Auxiliary;
using CASReports.Datasets.CAA;
using CASReports.ReportTemplates;
using CASReports.ReportTemplates.CAA;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using ATLBDataSet = CASReports.Datasets.ATLBDataSet;

namespace CASReports.Builders.CAA
{
    /// <summary>
    /// ����������� ������ �� ��������� ������� ��
    /// </summary>
    public class SpecialisLicensetBuilder : AbstractReportBuilder
    {
	    private readonly Specialist _spec;
	    private readonly Specialist _reporter;
	    private readonly List<CAAEducationRecord> _educations;
	    
	    public SpecialisLicensetBuilder(Specialist spec, Specialist reporter, List<CAAEducationRecord> educations)
	    {
		    _spec = spec;
		    _reporter = reporter;
		    _educations = educations;
	    }

        #region Methods

        #region public override object GenerateReport()
        
        public override object GenerateReport()
        {
	        CAASpecLicence report = new CAASpecLicence();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private ATLBDataSet GenerateDataSet()

        private SpecialistDataSet GenerateDataSet()
        {
	        SpecialistDataSet dataSet = new SpecialistDataSet();
	        AddSpecialistInformation(dataSet);
	        AddAdditionalInformation(dataSet);
	        AddMedicalInformation(dataSet);
	        AddTableData(dataSet);
            
            return dataSet;
        }

        private void AddMedicalInformation(SpecialistDataSet dataSet)
        {
	        var cl = "";
	        var expire = "";
	        var remarks = "";

	        if (_spec.MedicalRecord != null)
	        {
		        cl = _spec.MedicalRecord.ClassNumber.ToString();
		        remarks = _spec.MedicalRecord.Remarks;
		        if(_spec.MedicalRecord.ValidToDate.HasValue)
			        expire = $"{_spec.MedicalRecord.ValidToDate:dd.MM.yyyy}";
	        }
	        
	        dataSet.MedicalData.AddMedicalDataRow(cl,expire,remarks);
        }

        #endregion

        private void AddTableData(SpecialistDataSet dataSet)
        {
	        string i1= "", i11= "", i2= "", i22= "", i3= "", i33= "", i4= "", i44 = "";
	        string e1= "", e11= "", e2= "", e22= "", e3= "", e33= "", e4= "", e44 = "";
	        string o1= "", o11= "", o2= "", o22= "", o3= "", o33= "", o4= "", o44 = "";
	        
	        var _license = _spec.Licenses.FirstOrDefault();
	        
	        if (_license != null)
	        {
		        i1 = string.Join(", ",_license.LicenseRatings
			        .Where(i => i.Rights.FullName.ToLower().Contains("instructor"))
			        .Select(i => $"{_license?.AircraftType?.FullName ?? ""} - {i.Rights.ShortName}"));
		        e1 = string.Join(", ",_license.LicenseRatings
			        .Where(i => i.Rights.FullName.ToLower().Contains("examiner"))
			        .Select(i => $"{_license?.AircraftType?.FullName ?? ""} - {i.Rights.ShortName}"));
		        o1 = string.Join(", ",_license.LicenseRatings
			        .Where(i => !i.Rights.FullName.ToLower().Contains("examiner") && !i.Rights.FullName.ToLower().Contains("instructor"))
			        .Select(i => $"{_license?.AircraftType?.FullName ?? ""} - {i.LicenseFunction.FullName}"));
		        
	        }



	        dataSet.TableData.AddTableDataRow(i1, i11, i2, i22, i3, i33, i4, i44,
		        e1, e11, e2, e22, e3, e33, e4, e44,
		        o1, o11, o2, o22, o3, o33, o4, o44 );
        }

        private void AddAdditionalInformation(SpecialistDataSet dataSet)
        {
	        var caa = GlobalObjects.CaaEnvironment.Operators.FirstOrDefault();
	        dataSet.AdditionalInfo.AddAdditionalInfoRow(caa.Name, caa.Settings?.ShortName ?? "",_reporter.FirstName, _reporter.LastName, _reporter.Images.Sign, caa.Stamp);
        }
        
        
        private void AddSpecialistInformation(SpecialistDataSet dataSet)
        {
	        var _license = _spec.Licenses.FirstOrDefault();
	        var licenseCaa = _license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Licence);
	        
	        
	        var licenceNumber = licenseCaa?.CAANumber ?? String.Empty;
	        var titleLicense = _license?.EmployeeLicenceType.ShortName ?? String.Empty;
	        var name = $"{_spec.LastName} {_spec.FirstName}";
	        var dateOfBirth = $"{_spec.DateOfBirth:dd.MM.yyyy}";
	        var placeOfBirth = _spec.Nationality;
	        var adress = _spec.Address;
	        var nationality = _spec.Citizenship.ShortName;
	        var issuing = $"{_license?.IssueDate:dd.MM.yyyy}" ?? String.Empty;
	        var valid =  _license.IsValidTo ?   $"{_license?.ValidToDate:dd.MM.yyyy}" : "unlimited";
	        var countryCode = licenseCaa?.Caa.ShortName ?? "";
	        var privilages = "Unlimited";

	        if (_spec.LicenseRemark.Any(i => i.LicenseRestriction.FullName.Contains("Radiotelephony operation in English")))
		        privilages = "This holder of this Licence demonstrated to operate R/T equipment on board aircraft in English";

	        var level = "";
	        if (_educations != null && _educations.Any())
	        {
		        var ed = _educations.FirstOrDefault();
		        
		        var last = ed.Settings.LastCompliances.OrderByDescending(i => i.LastDate).FirstOrDefault();
		        if (last != null)
		        {
			        var next = ed.Settings.NextCompliance.NextDate;
			        var lvl =last.LevelId == -1 ? "" : EnglishLevel.GetItemById(last.LevelId).FullName;
			        level = $"English Level {lvl} validity: {next:dd.MM.yyyy}";
		        }
		        
	        }
	        
	        dataSet.Part1Table
		        .AddPart1TableRow(_spec.Images.Sign, licenceNumber,name,dateOfBirth,placeOfBirth
			        ,adress,nationality,issuing,null,valid,countryCode,titleLicense,privilages, level,
			        $"{DateTime.Now:dd.MM.yyyy HH:mm}",_spec.Images.QR
			        , _spec.Images.Photo);


	        
        }
        
        #endregion
    }
}
