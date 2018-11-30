namespace EFCore.DTO.Dictionaries
{
	public class DirectiveTypeDTO : BaseEntity
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string CommonName { get; set; }
    }
}
