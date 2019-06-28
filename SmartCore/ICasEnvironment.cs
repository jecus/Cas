using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using CAS.UI.Helpers;
using EFCore.Contract;
using EFCore.DTO.General;
using EFCore.UnitOfWork;
using Microsoft.SqlServer.Management.Smo;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Entities.NewLoader;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore
{
	public interface ICasEnvironment
	{
		/// <summary>
		/// Свойства
		/// </summary>
		DatabaseManager DatabaseManager { get; }
		ApiProvider ApiProvider { get; }
		OperatorCollection Operators { get; }
		CommonCollection<Vehicle> Vehicles { get; }
		CommonCollection<Store> Stores { get; }
		CommonCollection<Hangar> Hangars { get; }
		CommonCollection<WorkShop> WorkShops { get; }
		BaseComponentCollection BaseComponents { get; }
		Dictionary<string, ICommonCollection> TempCollections { get; }
		ReasonCollection Reasons { get; }
		IIdentityUser IdentityUser { get; }
		ILoader Loader { get; }
		INewLoader NewLoader { get; }
		INewKeeper NewKeeper { get; }
		Calculator Calculator { get; }
		Keeper Keeper { get; }
		Manipulator Manipulator { get; }
		UnitOfWork UnitOfWork { get; }


		DataSet Execute(string sql);
		DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);
		DataSet Execute(String query, SqlParameter[] parameters);

		/// <summary>
		/// Методы
		/// </summary>
		void Disconnect();

		void Connect(String serverName, String userName, String pass, String database);

		ILoginService GetSeviceUser();

		string GetCorrector(int id);

		void UpdateUser(string password);

		void CheckTablesFor(Type type);

		void CreateTablesFor(Type type);

		IDictionaryCollection GetDictionary<T>() where T : IDictionaryItem;

		IDictionaryCollection GetDictionary(Type type);

		void ClearDictionaries();

		void AddDictionary(Type t, IDictionaryCollection dictionary);

		void Reset();

		void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState);

		void OpenFile(AttachedFile attachedFile, out string message);

		void SaveAsFile(AttachedFile attachedFile, string filePath, out string message);

		T CloneObject<T>(T source);

		void SetAircraftCore(IAircraftsCore aircraftsCore);

	}
}
