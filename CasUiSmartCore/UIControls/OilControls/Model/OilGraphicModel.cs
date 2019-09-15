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
			Limits = new Dictionary<BaseComponent, OilLimits>();
		}

		public Dictionary<BaseComponent, Dictionary<Lifelength, double>>  Graph { get; set; }
		public Dictionary<BaseComponent, OilLimits>  Limits { get; set; }

	}
	public class OilLimits
	{
		public double Min { get; set; }
		public double Max { get; set; }
		public double Normal { get; set; }
	}
}