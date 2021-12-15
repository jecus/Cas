using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("aircraftflight")]
	public class AircraftFlightController : BaseController<AircraftFlightDTO>
	{
        private readonly DataContext _context;

        public AircraftFlightController(DataContext context, ILogger<BaseController<AircraftFlightDTO>> logger) : base(context, logger)
        {
            _context = context;
        }


        public override async Task<ActionResult<AircraftFlightDTO>> GetObject(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
        {
            try
            {
                var res = await _repository.GetObjectAsync(filters, loadChild, getDeleted, getAll);

                var stations = new List<AirportCodeDTO>();
                var flightNumbers = new List<FlightNumDTO>();
                var levels = new List<CruiseLevelDTO>();
                var reasons = new List<ReasonDTO>();


                var stationIds = new List<int?>() {res.StationFromId, res.StationToId};
                if (stationIds.Any())
                {
                    stations = await _context.AirportCodeDtos
                        .Where(i => !i.IsDeleted && stationIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }
                

                var flNumberIds = new List<int?>() { res.FlightNumberId};
                if (flNumberIds.Any())
                {
                    flightNumbers = await _context.FlightNumDtos
                        .Where(i => !i.IsDeleted && flNumberIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var levelIds = new List<int?>() { res.LevelId };
                if (levelIds.Any())
                {
                    levels = await _context.CruiseLevelDtos
                        .Where(i => !i.IsDeleted && levelIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }
                    

                var reasonIds = new List<int?>() { res.CancelReasonId, res.DelayReasonId };
                if (levelIds.Any())
                {
                    reasons = await _context.ReasonDtos
                        .Where(i => !i.IsDeleted && reasonIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }

                res.FlightNumber = flightNumbers.FirstOrDefault(i => i.ItemId == res.FlightNumberId);
                res.Level = levels.FirstOrDefault(i => i.ItemId == res.LevelId);
                res.StationFromDto = stations.FirstOrDefault(i => i.ItemId == res.StationFromId);
                res.StationToDto = stations.FirstOrDefault(i => i.ItemId == res.StationToId);
                res.DelayReason = reasons.FirstOrDefault(i => i.ItemId == res.DelayReasonId);
                res.CancelReason = reasons.FirstOrDefault(i => i.ItemId == res.CancelReasonId);



                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { Error = e.Message, InnerError = e.InnerException?.Message });
            }
        }


        public override async Task<ActionResult<List<AircraftFlightDTO>>> GetObjectList(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
        {
            try
            {
                var res = await _repository.GetObjectListAsync(filters, loadChild, getDeleted);

                var stations = new List<AirportCodeDTO>();
                var flightNumbers = new List<FlightNumDTO>();
                var levels = new List<CruiseLevelDTO>();
                var reasons = new List<ReasonDTO>();


                var stationIds = new List<int?>();
                stationIds.AddRange(res.Select(i => i.StationFromId));
                stationIds.AddRange(res.Select(i => i.StationToId));
                stationIds = stationIds.Distinct().ToList();
                if (stationIds.Any())
                {
                    stations = await _context.AirportCodeDtos
                        .Where(i => !i.IsDeleted && stationIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var flNumberIds = new List<int?>();
                flNumberIds.AddRange(res.Select(i => i.FlightNumberId));
                flNumberIds = flNumberIds.Distinct().ToList();
                if (flNumberIds.Any())
                {
                    flightNumbers = await _context.FlightNumDtos
                        .Where(i => !i.IsDeleted && flNumberIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var levelIds = new List<int?>();
                levelIds.AddRange(res.Select(i => i.LevelId));
                levelIds = levelIds.Distinct().ToList();
                if (levelIds.Any())
                {
                    levels = await _context.CruiseLevelDtos
                        .Where(i => !i.IsDeleted && levelIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var reasonIds = new List<int?>();
                reasonIds.AddRange(res.Select(i => i.CancelReasonId));
                reasonIds.AddRange(res.Select(i => i.DelayReasonId));
                reasonIds = reasonIds.Distinct().ToList();
                if (levelIds.Any())
                {
                    reasons = await _context.ReasonDtos
                        .Where(i => !i.IsDeleted && reasonIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }

                foreach (var fl in res)
                {
                    fl.FlightNumber = flightNumbers.FirstOrDefault(i => i.ItemId == fl.FlightNumberId);
                    fl.Level = levels.FirstOrDefault(i => i.ItemId == fl.LevelId);
                    fl.StationFromDto = stations.FirstOrDefault(i => i.ItemId == fl.StationFromId);
                    fl.StationToDto = stations.FirstOrDefault(i => i.ItemId == fl.StationToId);
                    fl.DelayReason = reasons.FirstOrDefault(i => i.ItemId == fl.DelayReasonId);
                    fl.CancelReason = reasons.FirstOrDefault(i => i.ItemId == fl.CancelReasonId);
                }

                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { Error = e.Message, InnerError = e.InnerException?.Message });
            }
        }


        public override async Task<ActionResult<List<AircraftFlightDTO>>> GetObjectListAll(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false)
        {
            try
            {
                var res = await _repository.GetObjectListAllAsync(filters, loadChild, getDeleted);

                var stations = new List<AirportCodeDTO>();
                var flightNumbers = new List<FlightNumDTO>();
                var levels = new List<CruiseLevelDTO>();
                var reasons = new List<ReasonDTO>();


                var stationIds = new List<int?>();
                stationIds.AddRange(res.Select(i => i.StationFromId));
                stationIds.AddRange(res.Select(i => i.StationToId));
                if (stationIds.Any())
                {
                    stations = await _context.AirportCodeDtos
                        .Where(i => !i.IsDeleted && stationIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var flNumberIds = new List<int?>();
                flNumberIds.AddRange(res.Select(i => i.FlightNumberId));
                if (flNumberIds.Any())
                {
                    flightNumbers = await _context.FlightNumDtos
                        .Where(i => !i.IsDeleted && flNumberIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var levelIds = new List<int?>();
                levelIds.AddRange(res.Select(i => i.LevelId));
                if (levelIds.Any())
                {
                    levels = await _context.CruiseLevelDtos
                        .Where(i => !i.IsDeleted && levelIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }


                var reasonIds = new List<int?>();
                reasonIds.AddRange(res.Select(i => i.CancelReasonId));
                reasonIds.AddRange(res.Select(i => i.DelayReasonId));
                if (levelIds.Any())
                {
                    reasons = await _context.ReasonDtos
                        .Where(i => !i.IsDeleted && reasonIds.Contains(i.ItemId))
                        .AsNoTracking()
                        .ToListAsync();
                }

                foreach (var fl in res)
                {
                    fl.FlightNumber = flightNumbers.FirstOrDefault(i => i.ItemId == fl.FlightNumberId);
                    fl.Level = levels.FirstOrDefault(i => i.ItemId == fl.LevelId);
                    fl.StationFromDto = stations.FirstOrDefault(i => i.ItemId == fl.StationFromId);
                    fl.StationToDto = stations.FirstOrDefault(i => i.ItemId == fl.StationToId);
                    fl.DelayReason = reasons.FirstOrDefault(i => i.ItemId == fl.DelayReasonId);
                    fl.CancelReason = reasons.FirstOrDefault(i => i.ItemId == fl.CancelReasonId);
                }
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { Error = e.Message, InnerError = e.InnerException?.Message });
            }
        }

    }
}