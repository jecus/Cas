using System;

namespace EntityCore.DTO.Dictionaries
{
	public class BiWeeklieDTO : BaseEntity
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public byte[] Report { get; set; }

        public DateTime? RecievedDate { get; set; }

        public string RealName { get; set; }
    }
}
