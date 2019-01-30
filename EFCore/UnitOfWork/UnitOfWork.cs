using System;
using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using EFCore.Contract.Dictionaries;
using EFCore.Contract.General;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;
using EFCore.UnitOfWork.Providers;
using BaseEntity = EFCore.DTO.BaseEntity;
using IRunUpService = EFCore.Contract.General.IRunUpService;
using RunUpDTO = EFCore.DTO.General.RunUpDTO;

namespace EFCore.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IConnectProvider _connectProvider;

		public UnitOfWork(IConnectProvider connectProvider)
		{
			_connectProvider = connectProvider;
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			return _connectProvider.GetRepository<T>();
		}
	}
}