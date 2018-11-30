using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{
    /// <summary>
    /// ЭУ для отображения основной информации о полете
    /// </summary>
    public partial class FlightGeneralInformatonControlLight : EditObjectControl
    {
        ///<summary>
        /// Возвращает редактируемый полет
        ///</summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }

        #region  public FlightGeneralInformatonControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public FlightGeneralInformatonControlLight()
        {
            InitializeComponent();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {

            BeginUpdate();
            if (Flight != null)
            {
                foreach (Control c in Controls)
                {
                    EditObjectControl cc = c as EditObjectControl;
                    if (cc != null) cc.AttachedObject = AttachedObject;
                }

	            documentControl1.CurrentDocument = Flight.Document;
	            documentControl1.Added += DocumentControl1_Added;
			}
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Сохраняет данные текущей директивы
        /// </summary>
        public override bool CheckData()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    if (!cc.CheckData()) return false;
            }
            // Все проверки завершились успешно
            return true;
        }

        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Вызывает метод ApplyChanges у каждого контрола
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null) cc.ApplyChanges();
            }
        }
        #endregion


        /* 
         *  Реагирование на события
         */

        #region private void FlightDateRouteControl1FlightDateChanget(Auxiliary.Events.DateChangedEventArgs e)

        private void FlightDateRouteControl1FlightDateChanget(DateChangedEventArgs e)
        {
            InvokeFlightDateChanget(e);
        }
        #endregion

        #region private void FlightDateRouteControl1FlightStationFromChanget(ValueChangedEventArgs e)
        private void FlightDateRouteControl1FlightStationFromChanget(ValueChangedEventArgs e)
        {
            InvokeFlightStationFromChanget(e);
        }
        #endregion

        #region private void FlightTimeControl1LDGTimeChanget(DateChangedEventArgs e)
        private void FlightTimeControl1LDGTimeChanget(DateChangedEventArgs e)
        {
            InvokeLDGTimeChanget(e.Date);
        }
        #endregion

        #region private void FlightTimeControl1TakeOffTimeChanget(DateChangedEventArgs e)
        private void FlightTimeControl1TakeOffTimeChanget(DateChangedEventArgs e)
        {
            InvokeTakeOffTimeChanget(e.Date);
        }
		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

	    private void DocumentControl1_Added(object sender, EventArgs e)
	    {
		    var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("ATLB") as DocumentSubType;
		    var newDocument = new Document
		    {
			    Parent = Flight,
			    ParentId = Flight.ItemId,
			    ParentTypeId = Flight.SmartCoreObjectType.ItemId,
			    DocType = DocumentType.TechnicalRecords,
			    DocumentSubType = docSubType,
			    IsClosed = true,
			    ContractNumber = $"{Flight.PageNo}",
			    Description = Flight.ParentATLB.ATLBNo,
			    IssueDateValidFrom = Flight.FlightDate,
				ParentAircraftId = Flight.AircraftId
			};

		    var form = new DocumentForm(newDocument, false);
		    if (form.ShowDialog() == DialogResult.OK)
		    {
			    Flight.Document = newDocument;
			    documentControl1.CurrentDocument = newDocument;

		    }
	    }

	    #endregion

		#region Events

		///<summary>
		/// Возникает во время изменения даты полета
		///</summary>
		[Category("Flight data")]
        [Description("Возникает в время изменения даты полета")]
        public event DateChangedEventHandler FlightDateChanget;

        ///<summary>
        /// Возникает во время изменения станции отбытия полета
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает во время изменения станции отбытия полета")]
        public event ValueChangedEventHandler FlightStationFromChanget;

        ///<summary>
        /// Возникает при изменении времени взлета
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени взлета")]
        public event DateChangedEventHandler TakeOffTimeChanget;

        ///<summary>
        /// Возникает при изменении времени посадки
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает при изменении времени посадки")]
        public event DateChangedEventHandler LDGTimeChanget;

        ///<summary>
        /// Сигнализирует об изменени даты полета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeFlightDateChanget(DateChangedEventArgs e)
        {
            DateChangedEventHandler handler = FlightDateChanget;
            if (handler != null) handler(e);
        }

        ///<summary>
        /// Сигнализирует об изменени даты полета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeFlightStationFromChanget(ValueChangedEventArgs e)
        {
            ValueChangedEventHandler handler = FlightStationFromChanget;
            if (handler != null) handler(e);
        }

        ///<summary>
        /// Сигнализирует об изменении времени ввода в ангар
        ///</summary>
        ///<param name="e"></param>
        private void InvokeTakeOffTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = TakeOffTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }

        ///<summary>
        /// Сигнализирует об изменении времени посадки
        ///</summary>
        ///<param name="e"></param>
        private void InvokeLDGTimeChanget(DateTime e)
        {
            DateChangedEventHandler handler = LDGTimeChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }
        

        #endregion
    }
}
