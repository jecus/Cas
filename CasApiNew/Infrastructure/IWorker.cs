using System;

namespace CAS.API.Infrastructure
{
	public interface IWorker : IDisposable
	{
		void Start();
	}
}