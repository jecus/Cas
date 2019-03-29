using System.Collections.Generic;

namespace SmartCore.Tests.DataAccess
{
    public class NonRoutineJob
    {
		public int ItemId { get; set; }
		public bool IsDeleted { get; set; }
        public int? ATAChapterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? ManHours { get; set; }
        public double? Cost { get; set; }
        public string KitRequired { get; set; }


        public int? FileId { get; set; }
		public ICollection<ItemFileLink> ItemFileLinks { get; set; }


	    public NonRoutineJob()
	    {
		    ItemFileLinks = new List<ItemFileLink>();
	    }
    }
}
