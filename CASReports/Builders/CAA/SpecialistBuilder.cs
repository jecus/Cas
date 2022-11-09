using System;
using System.Linq;
using CASReports.Datasets.CAA;
using CASReports.ReportTemplates.CAA;
using CASTerms;
using SmartCore.Entities.General.Personnel;

namespace CASReports.Builders.CAA
{
    /// <summary>
    /// ����������� ������ �� ��������� ������� ��
    /// </summary>
    public class SpecialistBuilder : AbstractReportBuilder
    {
	    private readonly Specialist _spec;
	    private readonly Specialist _reporter;

	    public SpecialistBuilder(Specialist spec,  Specialist reporter)
	    {
		    _spec = spec;
		    _reporter = reporter;
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
            AddAdditionalInformation(dataSet);
            AddTableData(dataSet);
            
            return dataSet;
        }

        private void AddTableData(SpecialistDataSet dataSet)
        {
	        string i1= "", i11= "", i2= "", i22= "", i3= "", i33= "", i4= "", i44 = "";
	        string e1= "", e11= "", e2= "", e22= "", e3= "", e33= "", e4= "", e44 = "";
	        string o1= "", o11= "", o2= "", o22= "", o3= "", o33= "", o4= "", o44 = "";
	        
	        
	        dataSet.TableData.AddTableDataRow(i1, i11, i2, i22, i3, i33, i4, i44,
		        e1, e11, e2, e22, e3, e33, e4, e44,
		        o1, o11, o2, o22, o3, o33, o4, o44 );
        }

        private void AddAdditionalInformation(SpecialistDataSet dataSet)
        {
	        var caa = GlobalObjects.CaaEnvironment.Operators.FirstOrDefault();
	        dataSet.AdditionalInfo.AddAdditionalInfoRow(caa.Name, caa.Settings?.ShortName ?? "",_reporter.FirstName, _reporter.LastName, _reporter.Sign, _reporter.Stamp);
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
