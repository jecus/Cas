using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Management;

namespace SmartCore.Tests.Serialization
{
	[TestClass]
	public class Serialization
	{
		[TestMethod]
		public void Serialize()
		{
			var env = GetEnviroment();

			var locations = env.GetDictionary<AirportsCodes>().Cast<AirportsCodes>().ToArray();

			var formatter = new XmlSerializer(typeof(AirportsCodes[]));

			// получаем поток, куда будем записывать сериализованный объект
			using (var fs = new FileStream("H:\\Locations.xml", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, locations);

				Trace.WriteLine("Объект сериализован");
			}
		}


		[TestMethod]
		public void DeSerialize()
		{
			var formatter = new XmlSerializer(typeof(AirportsCodes[]));
			using (FileStream fs = new FileStream("H:\\Locations.xml", FileMode.OpenOrCreate))
			{
				var start = Stopwatch.StartNew();
				var newpeople = (AirportsCodes[])formatter.Deserialize(fs);
				start.Stop();

				Trace.WriteLine(newpeople.Length);
				Trace.WriteLine(start.Elapsed);
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "casadmin", "casadmin001", "ScatDBTest");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}