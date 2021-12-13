using System;
using System.Threading.Tasks;

namespace CasApiNew.Infrastructure
{
	public interface IWorker : IDisposable
	{
		Task Start();
	}
}