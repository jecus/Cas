using System;

namespace API.Abstractions.Abstractions.Workers
{
	public interface IWorker : IDisposable
	{
		void Start();
	}
}