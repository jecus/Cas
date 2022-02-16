using System.Collections.Generic;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Model
{
    public class RevisionAudit
    {
        [JsonProperty("AuditId")]
        public IEnumerable<int> AuditId { get; set; }
        
        [JsonProperty("NewAudit")]
        public IEnumerable<RevisionNewAudit> NewAudit { get; set; }
    }

    public class RevisionNewAudit
    {
        [JsonProperty("OpttionId")]
        public int OpttionId { get; set; }
        
        [JsonProperty("CheckListId")]
        public int CheckListId { get; set; }
        
        [JsonProperty("OptionNumber")]
        public int OptionNumber { get; set; }
        
        [JsonProperty("Remark")]
        public string Remark { get; set; }
    }
    
    
}