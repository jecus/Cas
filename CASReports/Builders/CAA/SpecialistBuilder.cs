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
	        //dataSet.Part1Table.AddPart1TableRow();
        }

        #endregion
        
        #endregion
    }
}
