using System;

namespace CasAPI.Infrastructure
{
	public interface IWorker : IDisposable
	{
		void Start();
	}
}