using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;

namespace CASReports.Builders
{
    public class AirFleetBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly List<Aircraft> _aircrafts;

        #endregion

        #region Constructor

        #region public AirFleetBuilder(Aircraft aircraft)

        /// <summary>
        /// Создается построитель отчета по MonthlyUtilization
        /// </summary>
        public AirFleetBuilder(List<Aircraft> aircrafts)
        {
            _aircrafts = aircrafts;
        }

        #endregion

        #endregion
        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            AirFleetReport report = new AirFleetReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private AirFleetDataSet GenerateDataSet()

        private AirFleetDataSet GenerateDataSet()
        {
            AirFleetDataSet dataSet = new AirFleetDataSet();
            AddGeneralDataToDataSet(dataSet);
            AddItems(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddGeneralDataToDataSet(AirFleetDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddGeneralDataToDataSet(AirFleetDataSet destinationDateSet)
        {
			var op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _aircrafts[0].OperatorId);

			var logo = op.LogoTypeWhite;
            var dateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ReportFooterLink"].ToString();
            var operat = op.Name;
            destinationDateSet.GeneralInformation.AddGeneralInformationRow(logo, dateAsOf, reportFooter,
                                                                           reportFooterPrepared, reportFooterLink,operat);

        }

        #endregion

        #region private void AddItems(AirFleetDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddItems(AirFleetDataSet destinationDateSet)
        {
            for(int i =0;i<_aircrafts.Count;i++)
                AddItemToDataset(_aircrafts[i],destinationDateSet);
        }

        #endregion

        #region public void AddItemToDataset(Aircraft currentAircraft, AirFleetDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemToDataset(Aircraft currentAircraft, AirFleetDataSet destinationDataSet)
        {
            string model = currentAircraft.Model.ToString();
            string serialNumber = currentAircraft.SerialNumber;
            string manufactureDate = currentAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string registrationNumber = currentAircraft.RegistrationNumber;
            string engineCaption1 = "";
            string engineCaption2 = "";
            string apuCaption = "";

	        var engine = GlobalObjects.ComponentCore.GetAircraftEngines(currentAircraft.ItemId);
	        var apu = GlobalObjects.ComponentCore.GetAircraftApu(currentAircraft.ItemId);

			if (engine.Length > 0 && engine[0] != null)
                engineCaption1 = engine[0].Model + "\r\nS/N " + engine[0].SerialNumber;
            if (engine.Length > 1 && engine[1] != null)
                engineCaption2 = engine[1].Model + "\r\nS/N " + engine[1].SerialNumber;
            if (apu != null)
                apuCaption = apu.Model + "\r\nS/N " + apu.SerialNumber;

                string lineNumber = (currentAircraft).LineNumber;
                string variableNumber = (currentAircraft).VariableNumber;

            string deliveryDate = "";
            if (currentAircraft.DeliveryDate!=null)
                deliveryDate = ((DateTime)currentAircraft.DeliveryDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string acceptanceDate = "";
            if (currentAircraft.AcceptanceDate!=null)
                acceptanceDate =((DateTime) currentAircraft.AcceptanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString());

            destinationDataSet.ItemData.AddItemDataRow(model, serialNumber, registrationNumber, lineNumber,
                                                       variableNumber, manufactureDate, deliveryDate, acceptanceDate,
                                                       apuCaption, engineCaption1, engineCaption2);

        }

        #endregion

        #endregion
    }
}
