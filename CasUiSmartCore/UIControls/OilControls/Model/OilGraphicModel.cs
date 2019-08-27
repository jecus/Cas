using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.OilControls.Model
{
	public class OilGraphicModel
	{
		public OilGraphicModel()
		{
			Graph = new Dictionary<BaseComponent, Dictionary<Lifelength, double>>();
		}

		public Dictionary<BaseComponent, Dictionary<Lifelength, double>>  Graph { get; set; }
		public double Min { get; set; }
		public double Max { get; set; }
		public double Normal { get; set; }
	}
}