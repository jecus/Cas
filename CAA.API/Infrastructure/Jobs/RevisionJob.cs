using System;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using CAA.Entity.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                
                var currentRevisions = await context.CheckListRevisionDtos
                    .Where(i => !i.IsDeleted 
                                              && i.Status == (byte)EditionRevisionStatus.Temporary || i.Status == (byte)EditionRevisionStatus.Current
                                              && i.Type ==  (byte)RevisionType.Revision
                                              && i.EffDate.Date <= DateTime.Today.Date).ToListAsync();

                foreach (var currentRevision in currentRevisions.Where(i => i.Status == (byte)EditionRevisionStatus.Current))
                {
                    currentRevision.Status = (byte)EditionRevisionStatus.Previous;
                    await context.SaveChangesAsync();
                }
                
                
                foreach (var currentRevision in currentRevisions.Where(i => i.Status == (byte)EditionRevisionStatus.Temporary))
                {
                    if (currentRevision != null)
                {
                    currentRevision.Status = (byte)EditionRevisionStatus.Current;
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

                            if (check.CheckUIType == CheckUIType.Iosa)
                            {
                                var settings = JsonConvert.DeserializeObject<CheckListSettings>(check.SettingsJSON);


                                if (rec.Settings.ModData.ContainsKey("Source"))
                                    check.Source = (string)rec.Settings.ModData["Source"];

                                if (rec.Settings.ModData.ContainsKey("Reference"))
                                    settings.Reference = (string)rec.Settings.ModData["Reference"];


                                if (rec.Settings.ModData.ContainsKey("Level"))
                                    settings.LevelId = (int)rec.Settings.ModData["Level"];

                                if (rec.Settings.ModData.ContainsKey("Phase"))
                                    settings.Phase = (string)rec.Settings.ModData["Phase"];

                                if (rec.Settings.ModData.ContainsKey("Requirement"))
                                    settings.Requirement = (string)rec.Settings.ModData["Requirement"];

                                if (rec.Settings.ModData.ContainsKey("Section"))
                                {
                                    var data = ((string)rec.Settings.ModData["Section"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.SectionNumber = data.FirstOrDefault();
                                    settings.SectionName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("Part"))
                                {
                                    var data = ((string)rec.Settings.ModData["Part"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.PartNumber = data.FirstOrDefault();
                                    settings.PartName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("Subpart"))
                                {
                                    var data = ((string)rec.Settings.ModData["Subpart"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.SubPartNumber = data.FirstOrDefault();
                                    settings.SubPartName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("Item"))
                                {
                                    var data = ((string)rec.Settings.ModData["Item"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.ItemNumber = data.FirstOrDefault();
                                    settings.ItemtName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("MH"))
                                    settings.MH = (int)rec.Settings.ModData["MH"];

                                if (rec.Settings.ModData.ContainsKey("Audit"))
                                {
                                    var revAudit = JsonConvert.DeserializeObject<RevisionAudit>((string)rec.Settings.ModData["Audit"]);
                                    if (revAudit != null)
                                    {
                                        if (revAudit.AuditId != null)
                                        {
                                            var checkRecords = await context.CheckListRecordDtos
                                                .Where(i => i.CheckListId == check.ItemId)
                                                .ToListAsync();

                                            foreach (var r in checkRecords)
                                            {
                                                var find = revAudit.AuditId.Any(i => i == r.ItemId);
                                                if (find)
                                                    continue;

                                                r.IsDeleted = true;
                                            }
                                        }

                                        if (revAudit.NewAudit != null)
                                        {
                                            context.CheckListRecordDtos.AddRange(revAudit.NewAudit.Select(i => new CheckListRecordDTO()
                                            {
                                                OptionNumber = i.OptionNumber,
                                                Remark = i.Remark,
                                                Option = i.OpttionId,
                                                CheckListId = i.CheckListId
                                            }));
                                        }
                                    }
                                }

                                check.SettingsJSON = JsonConvert.SerializeObject(settings);
                            }
                            else if (check.CheckUIType == CheckUIType.Iosa)
                            {
                                var settings = JsonConvert.DeserializeObject<CheckListSettingsSAFA>(check.SettingsJSON);
                                
                                if (rec.Settings.ModData.ContainsKey("Source"))
                                    check.Source = (string)rec.Settings.ModData["Source"];

                                if (rec.Settings.ModData.ContainsKey("Inspection Item"))
                                {
                                    var data = ((string)rec.Settings.ModData["Inspection Item"]).Split(new[]{"||"}, StringSplitOptions.None);
                                    settings.Item = data.FirstOrDefault();
                                    settings.ItemNumber = data.LastOrDefault();
                                }
                                
                                if (rec.Settings.ModData.ContainsKey("Inspection Title"))
                                    settings.Title = (string)rec.Settings.ModData["Inspection Title"];
                                
                                if (rec.Settings.ModData.ContainsKey("Standard"))
                                    settings.Standard = (string)rec.Settings.ModData["Standard"];
                                
                                if (rec.Settings.ModData.ContainsKey("Standard Ref"))
                                    settings.StandardRef = (string)rec.Settings.ModData["Standard Ref"];
                                
                                if (rec.Settings.ModData.ContainsKey("PDF Code"))
                                    settings.PdfCode = (string)rec.Settings.ModData["PDF Code"];
                                
                                if (rec.Settings.ModData.ContainsKey("Standard Text"))
                                    settings.StandardText = (string)rec.Settings.ModData["Standard Text"];
                                
                                if (rec.Settings.ModData.ContainsKey("Finding"))
                                    settings.PreDescribedFinding = (string)rec.Settings.ModData["Finding"];
                                
                                if (rec.Settings.ModData.ContainsKey("Instruction"))
                                    settings.Instruction = (string)rec.Settings.ModData["Instruction"];
                                
                                if (rec.Settings.ModData.ContainsKey("MH"))
                                    settings.MH = (int)rec.Settings.ModData["MH"];
                                
                                if (rec.Settings.ModData.ContainsKey("Category"))
                                    settings.LevelId = (int)rec.Settings.ModData["Category"];
                                
                                check.SettingsJSON = JsonConvert.SerializeObject(settings);
                            }
                            else if (check.CheckUIType == CheckUIType.Icao)
                            {
                                var settings = JsonConvert.DeserializeObject<CheckListICAOSettings>(check.SettingsJSON);


                                if (rec.Settings.ModData.ContainsKey("Source"))
                                    check.Source = (string)rec.Settings.ModData["Source"];

                                if (rec.Settings.ModData.ContainsKey("Reference"))
                                    settings.Reference = (string)rec.Settings.ModData["Reference"];


                                if (rec.Settings.ModData.ContainsKey("Level"))
                                    settings.LevelId = (int)rec.Settings.ModData["Level"];
                                

                                if (rec.Settings.ModData.ContainsKey("Standard"))
                                    settings.Standard = (string)rec.Settings.ModData["Standard"];

                                if (rec.Settings.ModData.ContainsKey("AnnexRef"))
                                    settings.AnnexRef = (string)rec.Settings.ModData["AnnexRef"];

                                if (rec.Settings.ModData.ContainsKey("Part"))
                                {
                                    var data = ((string)rec.Settings.ModData["Part"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.PartNumber = data.FirstOrDefault();
                                    settings.PartName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("Chapter"))
                                {
                                    var data = ((string)rec.Settings.ModData["Chapter"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.ChapterNumber = data.FirstOrDefault();
                                    settings.ChapterName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("Item"))
                                {
                                    var data = ((string)rec.Settings.ModData["Item"]).Split(new[] { "||" }, StringSplitOptions.None);
                                    settings.ItemNumber = data.FirstOrDefault();
                                    settings.ItemtName = data.LastOrDefault();
                                }

                                if (rec.Settings.ModData.ContainsKey("MH"))
                                    settings.MH = (int)rec.Settings.ModData["MH"];
                                
                                check.SettingsJSON = JsonConvert.SerializeObject(settings);
                            }


                        }
                    }

                    await context.SaveChangesAsync();
                }
                }

                
                
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}