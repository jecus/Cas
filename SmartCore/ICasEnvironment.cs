using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using CAS.UI.Helpers;
using Entity.Abstractions;
using SmartCore.Aircrafts;
using SmartCore.AuditMongo.Repository;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Entities.NewLoader;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore
{
    public interface IBaseEnvironment
    {
        OperatorCollection Operators { get; }
		IAuditRepository AuditRepository { get; set; }
		ApiProvider ApiProvider { get; set; }
        INewLoader NewLoader { get; }
        INewKeeper NewKeeper { get; }


        DataSet Execute(string sql);
        DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);
        DataSet Execute(string query, SqlParameter[] parameters);

		void Connect(String serverName, String userName, String pass, String database);
        IIdentityUser IdentityUser { get; }
        void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState);
        void UpdateUser(string password);

    }

	public interface ICasEnvironment : IBaseEnvironment
	{
		/// <summary>
		/// Свойства
		/// </summary>
        
		CommonCollection<Vehicle> Vehicles { get; }
		CommonCollection<Store> Stores { get; }
		CommonCollection<Hangar> Hangars { get; }
		CommonCollection<WorkShop> WorkShops { get; }
		CommonCollection<WorkStation> WorkStations { get; }
		BaseComponentCollection BaseComponents { get; }
		Dictionary<string, ICommonCollection> TempCollections { get; }
		ReasonCollection Reasons { get; }
        ILoader Loader { get; }
        Calculator Calculator { get; set; }
		Keeper Keeper { get; }
		Manipulator Manipulator { get; }


		/// <summary>
		/// Методы
		/// </summary>

        void Disconnect();
		string GetCorrector(int id);
		string GetCorrector(IBaseEntityObject entity);

		

		IDictionaryCollection GetDictionary<T>() where T : IDictionaryItem;

		IDictionaryCollection GetDictionary(Type type);

		void ClearDictionaries();

		void AddDictionary(Type t, IDictionaryCollection dictionary);

		void Reset();

        void OpenFile(AttachedFile attachedFile, out string message);

		void SaveAsFile(AttachedFile attachedFile, string filePath, out string message);

        void SetAircraftCore(IAircraftsCore aircraftsCore);
        void SetComponentCore(IComponentCore componentCore);


		void FirstLoad();
        void GetDictionaries();

        void SetParentsToStores();

        IList<DamageChart> GetDamageChartsByAircraftModel(AircraftModel aircraftModel);

        AttachedFile GetAttachedFileById(int id);

        ICommonCollection<EmployeeSubject> GetEmployeeSubject(params object[] parametres);
        ICommonCollection<ComponentModel> GetComponentModels(params object[] type);

        ICommonCollection<JobCard> GetJobCard(params object[] parametres);

	}
}
