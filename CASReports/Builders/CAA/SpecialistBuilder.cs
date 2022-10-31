using System;
using System.Linq;
using Auxiliary;
using CASReports.Datasets.CAA;
using CASReports.ReportTemplates;
using CASReports.ReportTemplates.CAA;
using CASTerms;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using ATLBDataSet = CASReports.Datasets.ATLBDataSet;

namespace CASReports.Builders.CAA
{
    /// <summary>
    /// ����������� ������ �� ��������� ������� ��
    /// </summary>
    public class SpecialistBuilder : AbstractReportBuilder
    {
	    private readonly Specialist _spec;
	    
	    public SpecialistBuilder(Specialist spec)
	    {
		    _spec = spec;
	    }

        #region Methods

        #region public override object GenerateReport()
        
        public override object GenerateReport()
        {
	        CAASpecReportPart1 report = new CAASpecReportPart1();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private ATLBDataSet GenerateDataSet()

        private SpecialistDataSet GenerateDataSet()
        {
	        SpecialistDataSet dataSet = new SpecialistDataSet();
            AddSpecialistInformation(dataSet);
            
            return dataSet;
        }

        #endregion

        #region private void AddATLBInformation(ATLBDataSet dataSet)

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
	        var valid = $"{_license?.ValidToDate:dd.MM.yyyy}" ?? String.Empty;
	        var countryCode = licenseCaa.Caa.ShortName;
	        
	        dataSet.Part1Table
		        .AddPart1TableRow(_spec.Sign, licenceNumber,name,dateOfBirth,placeOfBirth
			        ,adress,nationality,issuing,null,valid,countryCode,titleLicense);
        }

        #endregion
        
        #endregion
    }
}
