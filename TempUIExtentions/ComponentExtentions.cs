using CASTerms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;

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

		public static string GetParentAircraftRegNumber(this Directive directive)
		{
			if (directive.ParentAircraftId == 0)
				return "";

			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentAircraftId);
			return parentAircraft.RegistrationNumber;
		}
	}
}