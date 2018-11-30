using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace TempUIExtentions
{
	public static class ComponentExtentions
	{
		public static string GetParentAircraftRegNumber(this Component component)
		{
			if (component.ParentAircraftId == 0)
				return "";

			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentAircraftId);
			return parentAircraft.RegistrationNumber;
		}
	}
}