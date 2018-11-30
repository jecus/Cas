namespace EFCore.DTO.Dictionaries
{
	public class MaintenanceCheckTypeDTO : BaseEntity
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public int Priority { get; set; }
    }
}
