using System;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;

namespace CAA.API.Infrastructure.Jobs
{
    public class RevisionJob: IJob
    {
        private readonly ILogger<RevisionJob> _logger;
        private readonly IServiceProvider _provider;

        public RevisionJob(ILogger<RevisionJob> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }
        
        public async Task Execute(IJobExecutionContext c)
        {
            try
            {
                var context = _provider.GetService<DataContext>();
                
                var currentRevision = await context.CheckListRevisionDtos
                    .FirstOrDefaultAsync(i => !i.IsDeleted 
                                              && i.Status == (byte)EditionRevisionStatus.Temporary 
                                              && i.Type ==  (byte)RevisionType.Revision
                                              && i.EffDate.Date <= DateTime.Today.Date);

                if (currentRevision != null)
                {
                    currentRevision.Status = (byte)EditionRevisionStatus.Close;
                    var records = await context.CheckListRevisionRecordDtos
                        .Where(i => !i.IsDeleted && i.ParentId == currentRevision.ItemId)
                        .ToListAsync();

                    var checkListIds = records.Select(i => i.CheckListId);
                    var checkList = await context.CheckListDtos.Where(i => checkListIds.Contains(i.ItemId)).ToListAsync();
                    
                    foreach (var rec in records)
                    {
                        var check = checkList.FirstOrDefault(i => i.ItemId == rec.CheckListId);
                        if(check == null)
                            continue;

                        if (rec.Settings.RevisionCheckType == RevisionCheckType.New)
                            check.EditionId = rec.ParentId;
                        else if (rec.Settings.RevisionCheckType == RevisionCheckType.Del)
                            check.IsDeleted = true;
                        else if (rec.Settings.RevisionCheckType == RevisionCheckType.Mod)
                        {
                             if (rec.Settings.ModData.ContainsKey("Source"))
                                 check.Source = (string)rec.Settings.ModData["Source"];

                             if (rec.Settings.ModData.ContainsKey("Reference"))
                                 check.Settings.Reference = (string)rec.Settings.ModData["Reference"];

                             if (rec.Settings.ModData.ContainsKey("Findings"))
                                 check.Settings.Described = (string)rec.Settings.ModData["Findings"];

                             if (rec.Settings.ModData.ContainsKey("Instructions"))
                                 check.Settings.Instructions = (string)rec.Settings.ModData["Instructions"];

                             if (rec.Settings.ModData.ContainsKey("Check/ValidTo"))
                                 check.Settings.RevisonValidToDate = (DateTime)rec.Settings.ModData["Check/ValidTo"];

                             if (rec.Settings.ModData.ContainsKey("Notify"))
                                 check.Settings.RevisonValidToNotify = (int)rec.Settings.ModData["Notify"];

                             if (rec.Settings.ModData.ContainsKey("Level"))
                                 check.Settings.LevelId = (int)rec.Settings.ModData["Level"];

                             if (rec.Settings.ModData.ContainsKey("Phase"))
                                 check.Settings.Phase = (string)rec.Settings.ModData["Phase"];
                             
                             if (rec.Settings.ModData.ContainsKey("Requirement"))
                                 check.Settings.Requirement = (string)rec.Settings.ModData["Requirement"];

                             if (rec.Settings.ModData.ContainsKey("Section"))
                            {
                                var data = ((string)rec.Settings.ModData["Section"]).Split(new[]{"||"}, StringSplitOptions.None);
                                check.Settings.SectionNumber = data.FirstOrDefault();
                                check.Settings.SectionName = data.LastOrDefault();
                            }
                            
                            if (rec.Settings.ModData.ContainsKey("Part"))
                            {
                                var data = ((string)rec.Settings.ModData["Part"]).Split(new[]{"||"}, StringSplitOptions.None);
                                check.Settings.PartNumber = data.FirstOrDefault();
                                check.Settings.PartName = data.LastOrDefault();
                            }
                            
                            if (rec.Settings.ModData.ContainsKey("Subpart"))
                            {
                                var data = ((string)rec.Settings.ModData["Subpart"]).Split(new[]{"||"}, StringSplitOptions.None);
                                check.Settings.SubPartNumber = data.FirstOrDefault();
                                check.Settings.SubPartName = data.LastOrDefault();
                            }
                            
                            if (rec.Settings.ModData.ContainsKey("Item"))
                            {
                                var data = ((string)rec.Settings.ModData["Item"]).Split(new[]{"||"}, StringSplitOptions.None);
                                check.Settings.ItemNumber = data.FirstOrDefault();
                                check.Settings.ItemtName = data.LastOrDefault();
                            }
                            
                            if (rec.Settings.ModData.ContainsKey("MH"))
                                check.Settings.MH = (int)rec.Settings.ModData["MH"];
                        }
                    }

                    await context.SaveChangesAsync();
                }
                
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}