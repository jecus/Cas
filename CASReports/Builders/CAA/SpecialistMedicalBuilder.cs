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
    public class SpecialistMedicalBuilder : AbstractReportBuilder
    {
	    private readonly Specialist _spec;
	    private readonly Specialist _reporter;

	    public SpecialistMedicalBuilder(Specialist spec, Specialist reporter)
	    {
		    _spec = spec;
		    _reporter = reporter;
	    }
	    
        
        public override object GenerateReport()
        {
	        CAASpecMedical report = new CAASpecMedical();
            //report.SetDataSource(GenerateDataSet());
            return report;
        }
        
        

        private SpecialistDataSet GenerateDataSet()
        {
	        SpecialistDataSet dataSet = new SpecialistDataSet();
	        return dataSet;
        }
    }
}
