using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityCore.Interfaces.ExecutorServices.Arcitecture
{
	#region public enum ExecutionResult
	/// <summary>
	/// Результат выполнения скрипта
	/// </summary>
	public enum ExecutionResult
	{
		/// <summary>
		/// Успешное выполнение скрипта
		/// </summary>
		Successfull,

		/// <summary>
		/// Во время скрипта возникла исключительная ситуация
		/// </summary>
		Exception,
	}
	#endregion

	public class ExecutionResultArgs
	{
		/// <summary>
		/// Результат выполнения скриптов
		/// </summary>
		public ExecutionResult Result = ExecutionResult.Successfull;

		/// <summary>
		/// Исключительная ситуация, которая возникла во время выполнения скрипта
		/// </summary>
		public Exception Exception = null;

		/// <summary>
		/// Информация о запросе, который вызвал ошибку
		/// </summary>
		public String Query = null;
	}
}