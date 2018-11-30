using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;

namespace SmartCore.TransferRec
{
	public interface ITransferRecordCore
	{
		TransferRecordCollection GetPreTransferRecordsFrom(BaseComponent baseComponent);
		TransferRecordCollection GetLastTransferRecordsFrom(Aircraft aircraft);
		TransferRecordCollection GetLastTransferRecordsFrom(BaseComponent baseComponent);
		TransferRecordCollection GetLastTransferRecordsFrom(Store store, SmartCoreType componentType);
		TransferRecordCollection GetLastTransferRecordsFrom(Store store);
		TransferRecordCollection GetLastTransferRecordsFromSuppliers();
		IEnumerable<TransferRecord> GetTransferRecordsFromAndTo(Aircraft aircraft, Store s);

		IEnumerable<TransferRecord> GetTransferRecord(int aircraftId);

		IEnumerable<TransferRecord> GetTransferRecord();
		void Delete(TransferRecord transferRecord);
		TransferRecordCollection GetLastTransferRecordsFromSpecialist();
	}
}