namespace EFCore.DTO.Dictionaries
{
	//AircraftModel
	//[Condition("IsDeleted", "0")]
	//[Condition("ModelingObjectTypeId", "7")]	
	//
	
	
    public class ModelDTO : BaseEntity
    {
        public string Model { get; set; }

        public string SubModel { get; set; }

		public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Designer { get; set; }

        public string Manufacturer { get; set; }

        public int? ModelingObjectTypeId { get; set; }

        public int? ModelingObjectSubTypeId { get; set; }
    }
}
