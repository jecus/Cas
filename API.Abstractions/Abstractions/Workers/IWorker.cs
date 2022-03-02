using System;
using System.Threading.Tasks;

namespace API.Abstractions.Abstractions.Workers
{
	public interface IWorker : IDisposable
	{
		Task Start();
	}
}