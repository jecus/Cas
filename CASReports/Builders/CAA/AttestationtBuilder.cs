using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets.CAA;
using CASReports.ReportTemplates.CAA;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.General.Personnel;

namespace CASReports.Builders.CAA
{
    /// <summary>
    /// ����������� ������ �� ��������� ������� ��
    /// </summary>
    public class AttestationtBuilder : AbstractReportBuilder
    {
	    private readonly Specialist _spec;
	    private readonly Specialist _reporter;


	    public AttestationtBuilder(Specialist spec, Specialist reporter)
	    {
		    _spec = spec;
		    _reporter = reporter;
	    }

        #region Methods

        #region public override object GenerateReport()
        
        public override object GenerateReport()
        {
	        CAASpecAttestation report = new CAASpecAttestation();
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

            return dataSet;
        }

        private void AddAdditionalInformation(SpecialistDataSet dataSet)
        {
	        var caa = GlobalObjects.CaaEnvironment.Operators.FirstOrDefault();
	        dataSet.AdditionalInfo.AddAdditionalInfoRow(caa.Name, caa.Settings?.ShortName ?? "",_reporter.FirstName, _reporter.LastName, _reporter.Images.Sign, _reporter.Images.Stamp);
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
	        
	        dataSet.Part1Table
		        .AddPart1TableRow(_spec.Images.Sign, licenceNumber,name,dateOfBirth,placeOfBirth
			        ,adress,nationality,issuing,null,valid,countryCode,titleLicense,privilages, level, $"{DateTime.Today:dd.MM.yyyy}",_spec.Images.QR
			        , _spec.Images.Photo);


	        
        }

        #endregion
        


        
        
        #endregion
    }
}
